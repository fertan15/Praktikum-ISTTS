"use strict";
const { Model } = require("sequelize");
module.exports = (sequelize, DataTypes) => {
  class Penyewaan extends Model {
    static associate(models) {
      // Relasi balik dari Junction Table ke masing-masing master
      Penyewaan.belongsTo(models.Kamar, {
        foreignKey: "KamarId", //yang di penyewaan
        targetKey: "id", // yang di kamar
      });

      Penyewaan.belongsTo(models.Penyewa, {
        foreignKey: "PenyewaId",
        targetKey: "id",
      });
    }
  }
  Penyewaan.init(
    {
      id: {
        type: DataTypes.INTEGER,
        autoIncrement: true,
        primaryKey: true,
      },
      durasi_bulan: {
        type: DataTypes.INTEGER,
        allowNull: false,
      },
      total_harga: {
        type: DataTypes.INTEGER,
        allowNull: false,
      },
      status_sewa: {
        type: DataTypes.ENUM("Aktif", "Selesai", "Batal"),
        allowNull: false,
      },
      KamarId: {
        type: DataTypes.INTEGER,
        allowNull: false,
      },
      PenyewaId: {
        type: DataTypes.INTEGER,
        allowNull: false,
      },
    },
    {
      sequelize,
      modelName: "Penyewaan",
      tableName: "Penyewaan",
      timestamps: true,
      // name: {
      //   singular: "Penyewaan",
      //   plural: "Penyewaan",
      // },
    },
  );
  return Penyewaan;
};
