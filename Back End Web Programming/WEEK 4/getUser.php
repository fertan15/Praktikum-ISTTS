<?php
require 'koneksi.php';
header('Content-Type: application/json');

// Pastikan koneksi berhasil
if (!$conn) {
    echo json_encode(['success' => false, 'message' => 'Database connection failed.']);
    exit;
}

// Pastikan session dan parameter search tersedia
$userId = $_SESSION['logInUser']['id'] ?? null;
$searchRaw = isset($_POST['search']) ? trim($_POST['search']) : '';

try {
    // Siapkan parameter wildcard untuk LIKE
    $searchParam = '%' . $searchRaw . '%';

    $sql = "SELECT * FROM users
            WHERE id != :id
            AND id NOT IN (SELECT friend_id FROM friends WHERE user_id = :id)
            AND (username LIKE :search OR email LIKE :search)";

    $stmt = $conn->prepare($sql);
    $stmt->execute([':id' => $userId, ':search' => $searchParam]);
    $users = $stmt->fetchAll(PDO::FETCH_ASSOC);

    echo json_encode(['success' => true, 'users' => $users]);

} catch (PDOException $e) {
    // Kembalikan JSON error, hindari menampilkan stack trace HTML
    echo json_encode(['success' => false, 'message' => 'Database error: ' . $e->getMessage()]);
}

?>