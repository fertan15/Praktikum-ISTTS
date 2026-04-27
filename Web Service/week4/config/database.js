const { Sequelize } = require("sequelize");

const sequelize = new Sequelize("kos_amanah", "root", "", {
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
