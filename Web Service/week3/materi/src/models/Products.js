const { DataTypes } = require("sequelize");
const sequelize = require("../config/database");

const Product = sequelize.define(
  "Product",
  {
    id: {
      type: DataTypes.INTEGER,
      primaryKey: true,
      autoIncrement: true,
    },
    sku_code: {
      type: DataTypes.STRING,
      allowNull: false,
      unique: true,
    },
    name: {
      type: DataTypes.STRING,
      allowNull: false,
    },
    category: {
      type: DataTypes.STRING,
      allowNull: false,
    },
    base_price: {
      type: DataTypes.INTEGER,
      allowNull: false,
    },
    discount_percentage: {
      type: DataTypes.INTEGER,
      allowNull: false,
      defaultValue: 0,
    },
    final_price: {
      type: DataTypes.INTEGER,
      allowNull: false,
    },
    stock: {
      type: DataTypes.INTEGER,
      allowNull: false,
    },
    is_flash_sale: {
      type: DataTypes.BOOLEAN,
      allowNull: false,
      defaultValue: false,
    },
  },
  {
    sequelize, // agar terhubung dengan fungsi-fungsi dari sequelize
    modelName: "Products", // nama model
    tableName: "products", // nama tabel di database (jika tidak diisi, sequelize bakal otomatis buatkan tabel baru dengan menambahkan 's' di akhir nama model, jadi kalau modelnya 'Products' maka tabelnya menjadi 'Productss')
    timestamps: true, // untuk otomatis menambahkan field createdAt dan updatedAt
    // paranoid: true, // untuk fitur soft delete + otomatis menambahkan field deletedAt
  },
);

module.exports = Product;
