<?php
include 'koneksi.php';

header('Content-Type: application/json');

$response = ['success' => false, 'message' => ''];

if (!isset($_SESSION['logInUser'])) {
    $response['message'] = 'User not logged in.';
    echo json_encode($response);
    exit();
}

$currentUserId = $_SESSION['logInUser']['id'];
$friendId = $_POST['friendId'] ?? null;
$messageText = $_POST['message'] ?? null;

if (!$friendId || !$messageText) {
    $response['message'] = 'Missing friend ID or message.';
    echo json_encode($response);
    exit();
}

// Insert pesan baru ke tabel direct_messages
// is_read di-default ke FALSE untuk penerima.
$sql = "INSERT INTO direct_messages (sender_id, receiver_id, message) VALUES (?, ?, ?)";
$stmt = $conn->prepare($sql);

if ($stmt->execute([ $currentUserId, $friendId, $messageText])) {
    $response['success'] = true;
    $response['message'] = 'Message sent successfully.';
} else {
    $response['message'] = 'Failed to send message: ';
}

echo json_encode($response);
?>
