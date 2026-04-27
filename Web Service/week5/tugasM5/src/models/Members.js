"use strict";
const { Model } = require("sequelize");
module.exports = (sequelize, DataTypes) => {
  class Members extends Model {
    static associate(models) {
      Members.hasMany(models.ClassBookings, {
        foreignKey: "member_id",
        sourceKey: "member_id",
      });
    }
  }
  Members.init(
    {
      nik: {
        type: DataTypes.STRING,
        primaryKey: true,
        allowNull: false,
      },
      member_id: {
        type: DataTypes.STRING,
        unique: true,
        allowNull: false,
      },
      username: {
        type: DataTypes.STRING,
        allowNull: false,
      },
      email: {
        type: DataTypes.STRING,
        unique: true,
        allowNull: false,
      },
      password: {
        type: DataTypes.STRING,
        allowNull: false,
      },
      birth_date: {
        type: DataTypes.DATEONLY,
        allowNull: false,
      },
      phone_number: {
        type: DataTypes.STRING,
        allowNull: false,
      },
      emergency_phone: {
        type: DataTypes.STRING,
        allowNull: false,
      },
      city: {
        type: DataTypes.STRING,
        allowNull: false,
      },
      postal_code: {
        type: DataTypes.STRING,
        allowNull: false,
      },
      status_member: {
        type: DataTypes.ENUM("ACTIVE", "PAUSED"),
        defaultValue: "ACTIVE",
      },
    },
    {
      sequelize,
      modelName: "Members",
      tableName: "members",
      timestamps: false,
      name: {
        singular: "Members",
        plural: "Members",
      },
    },
  );
  return Members;
};
