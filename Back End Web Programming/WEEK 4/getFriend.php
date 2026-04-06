<?php
include 'koneksi.php';
header('Content-Type: application/json');

// Validate session / authentication
if (empty($_SESSION['logInUser']) || !isset($_SESSION['logInUser']['id'])) {
    echo json_encode(['success' => false, 'message' => 'blom login, id tidak ditemukan']);
    exit;
}

$idUser = $_SESSION['logInUser']['id'];
$status = isset($_REQUEST['status']) ? $_REQUEST['status'] : '';

try {
    if(isset($_REQUEST['onlyPage']) && $_REQUEST['onlyPage'] === 'true') {
        $stmt = $conn->prepare("SELECT * FROM friends join users ON friends.user_id = users.id WHERE friends.friend_id = :idUser and friends.status=:pstatus");

    }else{

        $stmt = $conn->prepare("SELECT * FROM friends join users ON friends.friend_id = users.id WHERE friends.user_id = :idUser AND friends.status = :pstatus");
    }

    $stmt->execute([':idUser' => $idUser, ':pstatus' => $status]);
    $friends = $stmt->fetchAll(PDO::FETCH_ASSOC);

    echo json_encode(['success' => true, 'friends' => $friends]);
} catch (Exception $e) {
    error_log('getFriend error: ' . $e->getMessage());
    echo json_encode(['success' => false, 'message' => 'Server error, please try again later.']);
}

?>