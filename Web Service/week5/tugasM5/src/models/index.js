const database = require("../config/database");
const { DataTypes } = require("sequelize");

//import model
const Members = require("./Members");
const ClassBookings = require("./ClassBookings");

const db = {};

db.Members = Members(database, DataTypes);
db.ClassBookings = ClassBookings(database, DataTypes);
for (const key of Object.keys(db)) {
  db[key].associate(db);
}
db.sequelize = database;
module.exports = db;
