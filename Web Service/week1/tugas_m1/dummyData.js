const users = [
  {
    id: 1,
    username: "budi_s",
    email: "budi@mail.com",
    phone_number: "081234567890",
    address: "Jl. Manyar No. 7, Surabaya",
    balance: 150000
  },
  {
    id: 2,
    username: "siti_m",
    email: "siti@mail.com",
    phone_number: "082233445566",
    address: "Jl. Anggrek No. 5, Bandung",
    balance: 0
  },
  {
    id: 3,
    username: "joko_w",
    email: "joko@mail.com",
    phone_number: "083344556677",
    address: "Jl. Klamis No. 10, Surabaya",
    balance: 50000
  }
];

const products = [
  {
    id: 101,
    name: "Beras Pandan Wangi 5kg",
    category: "Sembako",
    price: 75000,
    stock: 20,
    weight_gram: 5000
  },
  {
    id: 102,
    name: "Minyak Goreng Sawit 2L",
    category: "Sembako",
    price: 35000,
    stock: 15,
    weight_gram: 2000
  },
  {
    id: 103,
    name: "Gula Pasir 1kg",
    category: "Sembako",
    price: 15000,
    stock: 0,
    weight_gram: 1000
  },
  {
    id: 104,
    name: "Kopi Bubuk 250gr",
    category: "Minuman",
    price: 22000,
    stock: 10,
    weight_gram: 250
  },
  {
    id: 105,
    name: "Mie Instan Goreng",
    category: "Makanan",
    price: 3000,
    stock: 40,
    weight_gram: 85
  }
];

let nextUserId = 4;
let nextProductId = 106;
let nextTransactionId = 4;

module.exports = {
  users,
  products,
  nextUserId,
  nextProductId,
  nextTransactionId
};