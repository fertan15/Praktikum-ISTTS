"use strict";
const { Model } = require("sequelize");
module.exports = (sequelize, DataTypes) => {
  class ClassBookings extends Model {
    static associate(models) {
      ClassBookings.belongsTo(models.Members, {
        foreignKey: "member_id",
        targetKey: "member_id",
      });
    }
  }
  ClassBookings.init(
    {
      id: {
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true,
      },
      member_id: {
        type: DataTypes.STRING,
        allowNull: false,
      },
      class_type: {
        type: DataTypes.ENUM("YOGA", "ZUMBA", "LIFTING"),
        allowNull: false,
      },
      schedule_date: {
        type: DataTypes.DATEONLY,
        allowNull: false,
      },
      bring_guest: {
        type: DataTypes.BOOLEAN,
        allowNull: false,
        defaultValue: false,
      },
      guest_name: {
        type: DataTypes.STRING,
        allowNull: true,
      },
      promo_code: {
        type: DataTypes.STRING,
        allowNull: true,
      },
      payment_method: {
        type: DataTypes.ENUM("CASH", "CASHLESS"),
        allowNull: false,
      },
    },
    {
      sequelize,
      modelName: "ClassBookings",
      tableName: "class_bookings",
      timestamps: false,
      name: {
        singular: "ClassBookings",
        plural: "ClassBookings",
      },
    },
  );
  return ClassBookings;
};
