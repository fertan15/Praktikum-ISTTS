const database = require("../config/database");
const { DataTypes } = require("sequelize");

// 1. Import semua file model
const Kamar = require("./Kamar");
const TipeKamar = require("./TipeKamar");
const Penyewa = require("./Penyewa");
const Penyewaan = require("./Penyewaan");

const db = {};

// 2. Inisialisasi model dengan mengirimkan instance database dan DataTypes
db.Kamar = Kamar(database, DataTypes);
db.TipeKamar = TipeKamar(database, DataTypes);
db.Penyewa = Penyewa(database, DataTypes);
db.Penyewaan = Penyewaan(database, DataTypes);

// 3. Jalankan fungsi associate() untuk membentuk relasi antar tabel
for (const key of Object.keys(db)) {
  if (db[key].associate) {
    db[key].associate(db);
  }
}
// 4. Masukkan instance database ke dalam object db agar bisa dipakai untuk Transaction
db.sequelize = database;

module.exports = db;
