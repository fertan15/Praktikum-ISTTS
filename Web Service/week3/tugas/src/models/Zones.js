"use strict";

const { Model, DataTypes } = require("sequelize");
const sequelize = require("../config/sequelize");
class Zones extends Model {
  static associate(models) {}
}

Zones.init(
  {
    id: {
      type: DataTypes.INTEGER,
      primaryKey: true,
      autoIncrement: true,
    },
    zone_code: {
      type: DataTypes.STRING,
      allowNull: false,
      unique: true,
    },
    max_capacity: {
      type: DataTypes.INTEGER,
      allowNull: false,
    },
    current_load: {
      type: DataTypes.INTEGER,
      allowNull: false,
      defaultValue: 0,
    },
  },
  {
    sequelize,
    modelName: "Zones",
    tableName: "zones",
    timestamps: true,
    paranoid: true,
  },
);

module.exports = Zones;
