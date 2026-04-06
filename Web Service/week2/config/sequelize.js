const { Sequelize } = require("sequelize");

const db = new Sequelize("T2_224117127", "root", "", {
  host: "localhost",
  dialect: "mysql",
  logging: true,
});

async function testDB() {
  try {
    await db.authenticate();
    console.log("Database connected!");
  } catch (error) {
    console.error("Connection error:", error);
  }
}

testDB();

module.exports = { db };
