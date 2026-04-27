const { Sequelize } = require("sequelize");
const sequelize = new Sequelize("db_tugas_m5", "root", "", {
  host: "localhost",
  dialect: "mysql",
});
async function testDB() {
  try {
    await sequelize.authenticate();
    console.log("Database connected!");
  } catch (error) {
    console.error("Connection error:", error);
  }
}
testDB();
module.exports = sequelize;
