const { Sequelize } = require("sequelize");

const sequelize = new Sequelize("db_m3_materi", "root", "", {
  host: "localhost",
  dialect: "mysql",
});

// - ORM itu membuat tabel-tabel yang ada di database menjadi objek, dan memudahkan kita untuk berinteraksi dengan
//   database tanpa perlu query SQL manual.
// - ORM ini memudahkan kita untuk melakukan CRUD di databasenya kita.

// tes database connection
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
