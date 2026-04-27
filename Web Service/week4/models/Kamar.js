"use strict";
const { Model } = require("sequelize");
module.exports = (sequelize, DataTypes) => {
  class Kamar extends Model {
    static associate(models) {
      Kamar.belongsTo(models.TipeKamar, {
        foreignKey: "TipeKamarId", // menunjuk ke FK di tabel Kamar
        targetKey: "id", // menunjuk ke PK di tabel TipeKamar
      });

      // WAJIB PAKAI belongsToMany untuk relasi Many to Many
      Kamar.belongsToMany(models.Penyewa, {
        through: models.Penyewaan,
        foreignKey: "KamarId", // foreignKey menunjuk ke modelnya sendiri (Kamar) yang di junction table
        otherKey: "PenyewaId", // otherKey menunjuk ke model target (Penyewa) yang di junction table
      });

      // Relasi 1:N langsung ke tabel junction agar mudah di-include secara nested
      Kamar.hasMany(models.Penyewaan, {
        foreignKey: "KamarId",
      });
    }
  }
  Kamar.init(
    {
      id: {
        type: DataTypes.INTEGER,
        autoIncrement: true,
        primaryKey: true,
      },
      nomor_kamar: {
        type: DataTypes.STRING,
        allowNull: false,
      },
      status: {
        type: DataTypes.ENUM("Tersedia", "Dihuni", "Renovasi"),
        defaultValue: "Tersedia",
      },
      TipeKamarId: {
        type: DataTypes.INTEGER,
        allowNull: false,
      },
    },
    {
      sequelize,
      modelName: "Kamar",
      tableName: "kamar",
      timestamps: true,
      name: {
        singular: "Kamar",
        plural: "Kamar",
      },
    },
  );
  return Kamar;
};
