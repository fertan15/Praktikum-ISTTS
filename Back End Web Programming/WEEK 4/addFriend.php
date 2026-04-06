<?php
    require 'koneksi.php';
    header('Content-Type: application/json');

    if (!$conn) {
        echo json_encode(['success' => false, 'message' => 'Database connection failed.']);
        exit;
    }


try{
    $stmt = $conn->prepare("INSERT INTO friends (user_id, friend_id, status) VALUES (:user_id, :friend_id, 'pending')");
    $stmt->execute([
        ':user_id' => $_SESSION['logInUser']['id'],
        ':friend_id' => $_POST['id']
    ]);

    echo json_encode(['status' => 'success']);
} catch (Exception $e) {
    echo json_encode(['status' => 'error', 'message' => $e->getMessage()]);
}

?>