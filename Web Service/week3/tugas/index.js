const express = require("express");
const port = 3003;

const app = express();
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

const sistemRouter = require("./src/routes/routes");

app.use("/api", sistemRouter);

app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});
