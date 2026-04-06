<?php
include 'koneksi.php';
header('Content-Type: application/json');

$Friendid = isset($_REQUEST['id']) ? trim($_REQUEST['id']) : '';
$userId = $_SESSION['logInUser']['id'] ?? null;
$status = isset($_REQUEST['status']) ? trim($_REQUEST['status']) : '';

if (!$conn) {
    echo json_encode(['success' => false, 'message' => 'Database connection error']);
    exit;
}

if (!$userId || !$Friendid || !$status) {
    echo json_encode(['success' => false, 'message' => 'Missing parameters', 'received' => ['userId' => $userId, 'friendId' => $Friendid, 'status' => $status]]);
    exit;
}

try {
    // Try update where current user is the owner of the request
    $sql = "UPDATE friends SET status = :status WHERE user_id = :friendId AND friend_id = :userId";
    $stmt = $conn->prepare($sql);
    $stmt->execute([':status' => $status, ':userId' => $userId, ':friendId' => $Friendid]);

    $updated = $stmt->rowCount();

    if ($updated > 0) {
        // If accepted, ensure reciprocal relationship exists (insert if missing)
        if ($status === 'accepted') {
            $ins = $conn->prepare("INSERT INTO friends (user_id, friend_id, status) VALUES (:userId, :friendId, 'accepted')");
            $ins->execute([':friendId' => $Friendid, ':userId' => $userId]);
        
        }

        echo json_encode(['success' => true, 'message' => 'Status teman berhasil diperbarui', 'updated_rows' => $updated]);
    } else {
        // Diagnostic: fetch any existing rows between the two users (both directions)
        try {
            $diag = $conn->prepare("SELECT id, user_id, friend_id, status, created_at FROM friends WHERE (user_id = :userId AND friend_id = :friendId) OR (user_id = :friendId AND friend_id = :userId)");
            $diag->execute([':userId' => $userId, ':friendId' => $Friendid]);
            $rows = $diag->fetchAll(PDO::FETCH_ASSOC);
        } catch (Exception $e) {
            $rows = [];
        }

        echo json_encode([
            'success' => false,
            'message' => 'Tidak ada perubahan yang dilakukan atau ID tidak ditemukan',
            'received' => ['userId' => $userId, 'friendId' => $Friendid],
            'existing_rows' => $rows
        ]);
    }

} catch (PDOException $e) {
    error_log('updateFriendStatus error: ' . $e->getMessage());
    echo json_encode(['success' => false, 'message' => 'Server error, please try again later.', 'error' => $e->getMessage()]);
}

?>
