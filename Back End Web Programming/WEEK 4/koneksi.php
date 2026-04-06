<?php
// Mulai session
session_start();

// Parameter koneksi database
$host = "localhost";
$db = "discordLite"; 
$user = "root";
$pass = "";

// Opsi untuk PDO agar menampilkan error dan fetch data dalam bentuk array asosiatif
$opt = [
    PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION, 
    PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC 
];

// Membuat koneksi ke database menggunakan PDO
try {
    $conn = new PDO("mysql:host=$host;dbname=$db", $user, $pass, $opt);
} catch (PDOException $e) {
    error_log('Koneksi gagal: ' . $e->getMessage());
    $conn = null;
}

?>