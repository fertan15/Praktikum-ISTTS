const express = require("express");
const router = express.Router();
const Product = require("../models/Product");

// 1. POST /api/products (Create Product)
router.post("/", async (req, res) => {
  try {
    const {
      sku_code,
      name,
      category,
      base_price,
      discount_percentage = 0,
      stock,
      is_flash_sale = false,
      expiry_date,
    } = req.body;

    // Validasi Kategori
    const validCategories = {
      elektronik: "ELK",
      fashion: "FAS",
      makanan: "MKN",
    };
    if (!validCategories[category]) {
      return res
        .status(400)
        .json({ status: "error", message: "Invalid category" });
    }

    // VALIDASI SKU
    const prefix = validCategories[category];
    const currentYear = new Date().getFullYear();

    const skuParts = sku_code.split("-");

    if (skuParts.length !== 3) {
      return res
        .status(400)
        .json({ status: "error", message: "Invalid SKU format" });
    }

    const [skuPrefix, skuYear, skuNumber] = skuParts;

    // Prefix Kategori
    if (skuPrefix !== prefix) {
      return res.status(400).json({
        status: "error",
        message: "SKU code prefix does not match the category",
      });
    }

    // Cek Tahun (Wajib tahun saat ini)
    if (skuYear !== String(currentYear)) {
      return res.status(400).json({
        status: "error",
        message: "SKU year must be the current year",
      });
    }

    // Cek 5 Digit Angka
    if (skuNumber.length !== 5 || isNaN(Number(skuNumber))) {
      return res.status(400).json({
        status: "error",
        message: "SKU number must be exactly 5 digits",
      });
    }

    // Validasi Base Price (Minimal 10000 & Kelipatan 500)
    if (base_price < 10000 || base_price % 500 !== 0) {
      return res.status(400).json({
        status: "error",
        message: "Base price must be a multiple of 500",
      });
    }

    // Validasi Flash Sale (Diskon minimal 30%)
    if (is_flash_sale === true && discount_percentage < 30) {
      return res.status(400).json({
        status: "error",
        message: "Flash sale items must have at least 30% discount",
      });
    }

    //  Final_Price
    const final_price = base_price - (base_price * discount_percentage) / 100;

    // Insert ke DB
    const product = await Product.create({
      sku_code,
      name,
      category,
      base_price,
      discount_percentage,
      final_price,
      stock,
      is_flash_sale,
    });

    return res.status(201).json({
      status: "success",
      data: {
        final_price: product.final_price,
        expiry_date: expiry_date || null,
      },
    });
  } catch (error) {
    return res.status(500).json({ status: "error", message: error.message });
  }
});

// 2. GET /api/products
router.get("/", async (req, res) => {
  try {
    // Paginasi
    const page = parseInt(req.query.page) || 1;
    const limit = parseInt(req.query.limit) || 10;
    const offset = (page - 1) * limit;

    const whereCondition = {};

    // Filter Opsional
    if (req.query.category) {
      whereCondition.category = req.query.category;
    }
    if (req.query.is_flash_sale !== undefined) {
      whereCondition.is_flash_sale = req.query.is_flash_sale === "true";
    }

    // Sorting Opsional
    let orderCondition = [];
    if (req.query.sort === "cheapest") {
      orderCondition = [["final_price", "ASC"]];
    } else if (req.query.sort === "expensive") {
      orderCondition = [["final_price", "DESC"]];
    }

    const products = await Product.findAll({
      where: whereCondition,
      limit: limit,
      offset: offset,
      order: orderCondition,
    });

    if (products.length === 0) {
      return res.status(200).json({
        status: "success",
        message: "No products found",
        data: [],
      });
    }

    return res.status(200).json({
      status: "success",
      data: products,
    });
  } catch (error) {
    return res.status(500).json({ status: "error", message: error.message });
  }
});

// 3. PUT /api/products/:id (Update Product)
router.put("/:id", async (req, res) => {
  try {
    const product = await Product.findByPk(req.params.id);
    if (!product) {
      return res
        .status(404)
        .json({ status: "error", message: "Product not found" });
    }

    let { base_price, discount_percentage, stock, is_flash_sale } = req.body;

    const newBasePrice =
      base_price !== undefined ? base_price : product.base_price;
    const newDiscount =
      discount_percentage !== undefined
        ? discount_percentage
        : product.discount_percentage;
    const newStock = stock !== undefined ? stock : product.stock;
    const newIsFlashSale =
      is_flash_sale !== undefined ? is_flash_sale : product.is_flash_sale;

    //  Matikan Flash Sale tapi stok < 50
    if (product.is_flash_sale === true && newIsFlashSale === false) {
      if (product.stock < 50) {
        return res.status(400).json({
          status: "error",
          message: "Cannot end flash sale if stock is less than 50",
        });
      }
    }

    // Validasi: Diskon Flash Sale minimal 30%
    if (newIsFlashSale === true && newDiscount < 30) {
      return res.status(400).json({
        status: "error",
        message: "Flash sale items must have at least 30% discount",
      });
    }

    // Validasi: Harga kelipatan 500
    if (base_price !== undefined) {
      if (newBasePrice < 10000 || newBasePrice % 500 !== 0) {
        return res.status(400).json({
          status: "error",
          message: "Base price must be a multiple of 500",
        });
      }
    }

    // Kalkulasi Ulang Harga Final
    const newFinalPrice = newBasePrice - (newBasePrice * newDiscount) / 100;

    // Update ke DB
    await product.update({
      base_price: newBasePrice,
      discount_percentage: newDiscount,
      stock: newStock,
      is_flash_sale: newIsFlashSale,
      final_price: newFinalPrice,
    });

    return res.status(200).json({
      status: "success",
      message: "Product updated",
      data: {
        final_price: product.final_price,
      },
    });
  } catch (error) {
    return res.status(500).json({ status: "error", message: error.message });
  }
});

// 4. DELETE /api/products/:id (Delete Product)
router.delete("/:id", async (req, res) => {
  try {
    const product = await Product.findByPk(req.params.id);

    if (!product) {
      return res
        .status(404)
        .json({ status: "error", message: "Product not found" });
    }

    // Stock harus 0
    if (product.stock !== 0) {
      return res.status(400).json({
        status: "error",
        message: "Cannot delete product. Stock must be 0.",
      });
    }

    // flash sale = true
    if (product.is_flash_sale === true) {
      return res.status(400).json({
        status: "error",
        message: "Cannot delete product. Flash sale is currently active.",
      });
    }

    // Hapus
    await product.destroy();

    return res.status(200).json({
      status: "success",
      message: "Product permanently deleted",
    });
  } catch (error) {
    return res.status(500).json({ status: "error", message: error.message });
  }
});

module.exports = router;
