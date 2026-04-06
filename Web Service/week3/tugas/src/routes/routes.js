const express = require("express");
const router = express.Router();
const Product = require("../models/Products");
const Zone = require("../models/Zones");

// 1. POST /api/zones (Create Zone)
router.post("/zones", async (req, res) => {
  try {
    const { zone_code, max_capacity } = req.body;

    if (!zone_code || typeof zone_code !== "string") {
      return res
        .status(400)
        .json({ status: "error", message: "Invalid zone_code format" });
    }

    const zoneParts = zone_code.split("-");
    if (
      zoneParts.length !== 2 ||
      zoneParts[0] !== "ZON" ||
      zoneParts[1].length !== 1 ||
      zoneParts[1] < "A" ||
      zoneParts[1] > "Z"
    ) {
      return res
        .status(400)
        .json({ status: "error", message: "Invalid zone_code format" });
    }

    if (!max_capacity || max_capacity < 50) {
      return res
        .status(400)
        .json({ status: "error", message: "max_capacity must be at least 50" });
    }

    const newZone = await Zone.create({
      zone_code,
      max_capacity,
    });

    return res.status(201).json({
      status: "success",
      data: {
        zone_code: newZone.zone_code,
        current_load: newZone.current_load,
      },
    });
  } catch (error) {
    return res.status(500).json({ status: "error", message: error.message });
  }
});

// 2. POST /api/products (Create Product & Manual Capacity Check)
router.post("/products", async (req, res) => {
  try {
    const {
      sku_code,
      name,
      category,
      base_price,
      discount_percentage = 0,
      stock,
      is_flash_sale = false,
      zone_code,
    } = req.body;

    // Validasi Kategori
    const validCategories = {
      elektronik: "ELK",
      fashion: "FAS",
      makanan: "MKN",
    };
    if (!validCategories[category])
      return res
        .status(400)
        .json({ status: "error", message: "Invalid category" });

    // Validasi SKU (Materi)
    const prefix = validCategories[category];
    const currentYear = new Date().getFullYear();
    const skuParts = sku_code.split("-");
    if (
      skuParts.length !== 3 ||
      skuParts[0] !== prefix ||
      skuParts[1] !== String(currentYear) ||
      skuParts[2].length !== 5 ||
      isNaN(Number(skuParts[2]))
    ) {
      return res
        .status(400)
        .json({ status: "error", message: "Invalid SKU format or Year" });
    }

    // Validasi Harga dan Flash Sale (Materi)
    if (base_price < 10000 || base_price % 500 !== 0)
      return res.status(400).json({
        status: "error",
        message: "Base price must be a multiple of 500",
      });
    if (is_flash_sale === true && discount_percentage < 30)
      return res.status(400).json({
        status: "error",
        message: "Flash sale items must have at least 30% discount",
      });

    // Validasi Zona & Kapasitas Secara Manual
    const zone = await Zone.findOne({ where: { zone_code: zone_code } });
    if (!zone) {
      return res
        .status(404)
        .json({ status: "error", message: "Target zone not found" });
    }

    if (zone.current_load + stock > zone.max_capacity) {
      return res.status(400).json({
        status: "error",
        message: "Zone capacity exceeded. Cannot store this much stock.",
      });
    }

    const final_price = base_price - (base_price * discount_percentage) / 100;

    // Eksekusi Insert Product
    await Product.create({
      sku_code,
      name,
      category,
      base_price,
      discount_percentage,
      final_price,
      stock,
      is_flash_sale,
      zone_code,
    });

    // Eksekusi Update current_load di tabel Zone
    await zone.update({ current_load: zone.current_load + stock });

    return res.status(201).json({
      status: "success",
      message: "Product saved and Zone capacity updated",
    });
  } catch (error) {
    return res.status(500).json({ status: "error", message: error.message });
  }
});

// 3. GET /api/products (Read All items with Pagination)
router.get("/products", async (req, res) => {
  try {
    const page = parseInt(req.query.page) || 1;
    const limit = parseInt(req.query.limit) || 5;
    const offset = (page - 1) * limit;

    const { count, rows } = await Product.findAndCountAll({
      limit: limit,
      offset: offset,
    });

    const total_pages = Math.ceil(count / limit);

    return res.status(200).json({
      status: "success",
      metadata: {
        total_data: count,
        total_pages: total_pages,
        current_page: page,
      },
      data: rows,
    });
  } catch (error) {
    return res.status(500).json({ status: "error", message: error.message });
  }
});

// 4. PUT /api/products/:id (Update Stock & Kalkulasi Selisih Zona)
router.put("/products/:id", async (req, res) => {
  try {
    const product = await Product.findByPk(req.params.id);
    if (!product)
      return res
        .status(404)
        .json({ status: "error", message: "Product not found" });

    const { base_price, discount_percentage, stock, is_flash_sale } = req.body;

    let updateData = {};
    let stockDiff = 0;

    let currentDiscount =
      discount_percentage !== undefined
        ? discount_percentage
        : product.discount_percentage;
    let currentIsFlashSale =
      is_flash_sale !== undefined ? is_flash_sale : product.is_flash_sale;

    if (
      product.is_flash_sale === true &&
      is_flash_sale === false &&
      product.stock < 50
    ) {
      return res.status(400).json({
        status: "error",
        message: "Cannot end flash sale if stock is less than 50",
      });
    }
    if (currentIsFlashSale === true && currentDiscount < 30) {
      return res.status(400).json({
        status: "error",
        message: "Flash sale items must have at least 30% discount",
      });
    }
    if (base_price !== undefined) {
      if (base_price < 10000 || base_price % 500 !== 0)
        return res.status(400).json({
          status: "error",
          message: "Base price must be a multiple of 500",
        });
      updateData.base_price = base_price;
    }

    // TUGAS Cek Selisih Stok dan Keamanan Zona
    if (stock !== undefined && stock !== product.stock) {
      stockDiff = stock - product.stock;
      const zone = await Zone.findOne({
        where: { zone_code: product.zone_code },
      });

      if (stockDiff > 0 && zone.current_load + stockDiff > zone.max_capacity) {
        return res.status(400).json({
          status: "error",
          message: "Updating stock causes zone capacity overload",
        });
      }

      updateData.stock = stock;
      await zone.update({ current_load: zone.current_load + stockDiff });
    }

    if (discount_percentage !== undefined)
      updateData.discount_percentage = discount_percentage;
    if (is_flash_sale !== undefined) updateData.is_flash_sale = is_flash_sale;

    let currentBasePrice =
      base_price !== undefined ? base_price : product.base_price;
    if (base_price !== undefined || discount_percentage !== undefined) {
      updateData.final_price =
        currentBasePrice - (currentBasePrice * currentDiscount) / 100;
    }

    // Update Product
    await product.update(updateData);

    let message = "Product updated";
    if (stockDiff !== 0) {
      const sign = stockDiff > 0 ? "+" : "";
      message = `Stock updated and Zone load adjusted (${sign}${stockDiff})`;
    }

    return res.status(200).json({
      status: "success",
      message: message,
    });
  } catch (error) {
    return res.status(500).json({ status: "error", message: error.message });
  }
});

// 5. DELETE /api/products/:id (Soft Delete & Restorasi Kapasitas)

router.delete("/products/:id", async (req, res) => {
  try {
    const product = await Product.findByPk(req.params.id);

    if (!product) {
      return res
        .status(404)
        .json({ status: "error", message: "Product not found" });
    }

    const zone = await Zone.findOne({
      where: { zone_code: product.zone_code },
    });

    //  Hapus
    await product.destroy();

    // Kurangi load zona
    if (zone) {
      await zone.update({ current_load: zone.current_load - product.stock });
    }

    return res.status(200).json({
      status: "success",
      message: `Product soft deleted. Zone load decreased by ${product.stock}.`,
    });
  } catch (error) {
    return res.status(500).json({ status: "error", message: error.message });
  }
});

module.exports = router;
