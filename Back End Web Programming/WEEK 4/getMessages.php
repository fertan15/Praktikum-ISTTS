<?php
include 'koneksi.php';

header('Content-Type: application/json');

$response = ['success' => false, 'messages' => [], 'message' => ''];

if (!isset($_SESSION['logInUser'])) {
    $response['message'] = 'User not logged in.';
    echo json_encode($response);
    exit();
}

$currentUserId = $_SESSION['logInUser']['id'];
$friendId = $_POST['friendId'] ?? null;

if (!$friendId) {
    $response['message'] = 'Missing friend ID.';
    echo json_encode($response);
    exit();
}

// Query untuk mengambil pesan antara currentUserId dan friendId
// Pesan diurutkan berdasarkan created_at ASC (pesan tertua di atas)
$sql = "
    SELECT 
        sender_id, message AS text, created_at AS timestamp 
    FROM 
        direct_messages 
    WHERE 
        (sender_id = ? AND receiver_id = ?) 
        OR (sender_id = ? AND receiver_id = ?)
    ORDER BY 
        created_at ASC
";

try {
    $stmt = $conn->prepare($sql);
    // PDO execute expects an array of parameters
    $stmt->execute([$currentUserId, $friendId, $friendId, $currentUserId]);
    $result = $stmt->fetchAll();

    $messages = [];
    foreach ($result as $row) {
        $messages[] = $row;
    }

    $response['success'] = true;
    $response['messages'] = $messages;
    echo json_encode($response);
    exit();

} catch (PDOException $e) {
    error_log('getMessages error: ' . $e->getMessage());
    $response['message'] = 'Database error while fetching messages.';
    echo json_encode($response);
    exit();
}
foreach ($result as $row) {
    $messages[] = $row;
}

$response['success'] = true;
$response['messages'] = $messages;
echo json_encode($response);
?>
