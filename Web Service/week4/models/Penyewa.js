"use strict";
const { Model } = require("sequelize");
module.exports = (sequelize, DataTypes) => {
  class Penyewa extends Model {
    static associate(models) {
      // WAJIB PAKAI belongsToMany untuk relasi Many to Many
      Penyewa.belongsToMany(models.Kamar, {
        through: models.Penyewaan,
        foreignKey: "PenyewaId", // foreignKey menunjuk ke modelnya sendiri (Penyewa)
        otherKey: "KamarId", // otherKey menunjuk ke model target (Kamar)
      });

      // Relasi 1:N langsung ke tabel junction
      Penyewa.hasMany(models.Penyewaan, {
        foreignKey: "PenyewaId",
      });
    }
  }
  Penyewa.init(
    {
      id: {
        type: DataTypes.INTEGER,
        autoIncrement: true,
        primaryKey: true,
      },
      nama_lengkap: {
        type: DataTypes.STRING,
        allowNull: false,
      },
      nik: {
        type: DataTypes.STRING(16),
        allowNull: false,
      },
      saldo_dompet: {
        type: DataTypes.INTEGER,
        defaultValue: 0,
      },
    },
    {
      sequelize,
      modelName: "Penyewa",
      tableName: "penyewa",
      timestamps: true,
      name: {
        singular: "Penyewa",
        plural: "Penyewa",
      },
    },
  );
  return Penyewa;
};
