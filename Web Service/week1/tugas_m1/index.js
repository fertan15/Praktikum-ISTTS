const express = require("express");
const app = express();
const port = 3001;

app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// Pastikan file dummyData.js mengekspor ini dan let/var untuk ID agar bisa di-increment (++)
const { users, products } = require("./dummyData");

let { nextUserId, nextProductId, nextTransactionId } = require("./dummyData");

// 1. Register user baru
app.post("/api/users/register", function (req, res) {
  const { username, email, phone_number, address } = req.body;

  // cek field
  if (!username || !email || !phone_number || !address) {
    return res
      .status(400)
      .json({ status: "error", message: "Semua field wajib diisi!" });
  }

  // email kembar
  const emailfounded = users.find((user) => user.email === email);
  if (emailfounded) {
    return res
      .status(400)
      .json({ status: "error", message: "Email sudah terdaftar!" });
  }

  // format hp bukan number
  if (isNaN(phone_number)) {
    return res
      .status(400)
      .json({ status: "error", message: "Nomor telepon harus berupa angka!" });
  }

  // simpan user baru
  const newUser = {
    id: nextUserId++,
    username,
    email,
    phone_number,
    address,
    balance: 0,
  };
  users.push(newUser);

  res.status(201).json({
    status: "success",
    message: "User berhasil didaftarkan",
    data: newUser,
  });
});

// 2. Lihat daftar user
app.get("/api/users", (req, res) => {
  const { username, address } = req.query;

  let filteredUsers = users;

  if (username) {
    filteredUsers = filteredUsers.filter((user) =>
      user.username.toLowerCase().includes(username.toLowerCase()),
    );
  }

  if (address) {
    filteredUsers = filteredUsers.filter((user) =>
      user.address.toLowerCase().includes(address.toLowerCase()),
    );
  }

  if (filteredUsers.length === 0) {
    return res.status(404).json({
      status: "error",
      message: "User tidak ditemukan berdasarkan filter tersebut",
    });
  }

  return res.status(200).json({
    status: "success",
    data: filteredUsers,
  });
});

// 3. Topup saldo
app.put("/api/users/:id/topup", (req, res) => {
  const id = Number(req.params.id);
  const amount = Number(req.body.amount);

  // error input minus or nol
  if (amount <= 0) {
    return res.status(400).json({
      status: "error",
      message: "Nominal topup harus lebih dari 0!",
    });
  }

  // error input bukan angka
  if (isNaN(amount)) {
    return res.status(400).json({
      status: "error",
      message: "Nominal topup harus berupa angka!",
    });
  }

  // user tidak ada
  const userIndex = users.findIndex((user) => user.id === id);
  if (userIndex === -1) {
    return res.status(404).json({
      status: "error",
      message: "User dengan ID " + id + " tidak ditemukan!",
    });
  }

  // success topup
  users[userIndex].balance += amount;
  return res.status(200).json({
    status: "success",
    message: "Topup berhasil",
    data: {
      id: users[userIndex].id,
      balance: users[userIndex].balance,
    },
  });
});

// 4. Delete user
app.delete("/api/users/:id", function (req, res) {
  const { id } = req.params;
  const userIndex = users.findIndex((user) => user.id === Number(id));

  if (userIndex === -1) {
    return res.status(404).json({
      status: "error",
      message: "User tidak ditemukan!",
    });
  }

  const deletedUser = users[userIndex].username;
  users.splice(userIndex, 1);
  return res.status(200).json({
    status: "success",
    message: "User " + deletedUser + " berhasil dihapus",
  });
});

// 5. Tambah produk
app.post("/api/products", function (req, res) {
  const { name, category, price, stock, weight_gram } = req.body;

  // Cek field (Sesuai request Anda, tetapi ditambahkan pengecualian stock === undefined
  // agar error message "stok boleh 0" dari soal tetap bisa dites dan lolos validasi isNaN)
  if (!name || !category || !price || stock === undefined || !weight_gram) {
    return res
      .status(400)
      .json({ status: "error", message: "Semua field produk wajib diisi!" });
  }

  // cek validasi angka
  if (
    isNaN(price) ||
    isNaN(stock) ||
    isNaN(weight_gram) ||
    Number(price) <= 0 ||
    Number(stock) < 0 ||
    Number(weight_gram) <= 0
  ) {
    return res.status(400).json({
      status: "error",
      message:
        "Harga, stok, dan berat harus berupa angka lebih dari 0 (stok boleh 0)!",
    });
  }

  // simpan produk baru
  const newProduct = {
    id: nextProductId++,
    name,
    category,
    price: Number(price),
    stock: Number(stock),
    weight_gram: Number(weight_gram),
  };
  products.push(newProduct);

  res.status(201).json({
    status: "success",
    data: newProduct,
  });
});

// 6. Lihat produk
app.get("/api/products", (req, res) => {
  const { category, maxPrice, minPrice, sortBy, search } = req.query;

  // Clone array dengan spread operator agar sort tidak merusak data asli
  let filteredProducts = [...products];

  if (category) {
    filteredProducts = filteredProducts.filter(
      (product) => product.category.toLowerCase() === category.toLowerCase(),
    );
  }

  if (maxPrice) {
    filteredProducts = filteredProducts.filter(
      (product) => product.price <= Number(maxPrice),
    );
  }

  if (minPrice) {
    filteredProducts = filteredProducts.filter(
      (product) => product.price >= Number(minPrice),
    );
  }

  if (sortBy) {
    if (sortBy === "asc") {
      filteredProducts.sort((a, b) => a.price - b.price);
    } else if (sortBy === "desc") {
      filteredProducts.sort((a, b) => b.price - a.price);
    }
  }

  if (search) {
    filteredProducts = filteredProducts.filter((product) =>
      product.name.toLowerCase().includes(search.toLowerCase()),
    );
  }

  return res.status(200).json({
    status: "success",
    data: filteredProducts,
  });
});

// 7. Update data produk
app.put("/api/products/:id", (req, res) => {
  const id = Number(req.params.id);
  const { name, category, price, stock, weight_gram } = req.body;

  // get product
  const productIndex = products.findIndex((product) => product.id === id);
  if (productIndex === -1) {
    return res.status(404).json({
      status: "error",
      message: "Produk tidak ditemukan!",
    });
  }

  if (name) products[productIndex].name = name;
  if (category) products[productIndex].category = category;

  if (price !== undefined) {
    if (isNaN(price)) {
      return res
        .status(400)
        .json({ status: "error", message: "Price harus berupa angka!" });
    }
    products[productIndex].price = Number(price);
  }

  if (stock !== undefined) {
    if (isNaN(stock)) {
      return res
        .status(400)
        .json({ status: "error", message: "Stock harus berupa angka!" });
    }
    products[productIndex].stock = Number(stock);
  }

  if (weight_gram !== undefined) {
    if (isNaN(weight_gram)) {
      return res
        .status(400)
        .json({ status: "error", message: "Weight harus berupa angka!" });
    }
    products[productIndex].weight_gram = Number(weight_gram);
  }

  return res.status(200).json({
    status: "success",
    message: "Produk diupdate",
    data: products[productIndex],
  });
});

// 8. Beli produk
app.post("/api/buy", function (req, res) {
  const { userId, productId, qty } = req.body;

  const numUserId = Number(userId);
  const numProductId = Number(productId);
  const numQty = Number(qty);

  // validasi qty
  if (isNaN(numQty) || numQty <= 0) {
    return res.status(400).json({
      status: "error",
      message: "Quantity pembelian minimal 1!",
    });
  }

  // user tidak ada
  const userIndex = users.findIndex((user) => user.id === numUserId);
  if (userIndex === -1) {
    return res.status(404).json({
      status: "error",
      message: "Transaksi gagal: User tidak ditemukan!",
    });
  }

  // produk tidak ada
  const productIndex = products.findIndex(
    (product) => product.id === numProductId,
  );
  if (productIndex === -1) {
    return res.status(404).json({
      status: "error",
      message: "Transaksi gagal: Produk tidak ditemukan!",
    });
  }

  // stok tidak cukup
  if (products[productIndex].stock < numQty) {
    return res.status(400).json({
      status: "error",
      message:
        "Transaksi gagal: Stok " +
        products[productIndex].name +
        " tidak mencukupi (Sisa: " +
        products[productIndex].stock +
        ")!",
    });
  }

  const totalHarga = Number(products[productIndex].price) * numQty;

  // saldo kurang
  if (totalHarga > Number(users[userIndex].balance)) {
    return res.status(400).json({
      status: "error",
      message: `Transaksi gagal: Saldo tidak mencukupi! Total: ${totalHarga}, Saldo Anda: ${users[userIndex].balance}`,
    });
  }

  // kurang saldo dan stok
  users[userIndex].balance -= totalHarga;
  products[productIndex].stock -= numQty;

  return res.status(200).json({
    status: "success",
    message: "Pembelian berhasil",
    detail: {
      nama_produk: products[productIndex].name,
      total_harga: totalHarga,
      total_berat_gram: Number(products[productIndex].weight_gram) * numQty,
      sisa_saldo_user: users[userIndex].balance,
      sisa_stok_produk: products[productIndex].stock,
    },
  });
});

app.listen(port, () => console.log(`Example app listening on port ${port}!`));
