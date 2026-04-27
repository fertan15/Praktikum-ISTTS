"use strict";
const { Model } = require("sequelize");
module.exports = (sequelize, DataTypes) => {
  class TipeKamar extends Model {
    static associate(models) {
      TipeKamar.hasMany(models.Kamar, {
        foreignKey: "TipeKamarId", //foreign key di tabel Kamar
        sourceKey: "id", // menunjuk ke PK di tabel TipeKamar
      });
    }
  }
  TipeKamar.init(
    {
      id: {
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true,
      },
      nama_tipe: {
        type: DataTypes.STRING,
        allowNull: false,
      },
      harga_per_bulan: {
        type: DataTypes.INTEGER,
        allowNull: false,
      },
    },
    {
      sequelize,
      modelName: "TipeKamar",
      tableName: "tipekamar",
      timestamps: true,
      name: {
        singular: "TipeKamar",
        plural: "TipeKamar",
      },
    },
  );
  return TipeKamar;
};
