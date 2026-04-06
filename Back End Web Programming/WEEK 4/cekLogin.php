<?php
    header('Content-Type: application/json');
    include 'koneksi.php';


    if(!isset($_POST['user']) || !isset($_POST['pass']) || empty($_POST['user']) || empty($_POST['pass'])) {
        echo json_encode(['success' => false, 'message' => 'Please fill in all fields.']);
        exit;
    }

    $user = $_POST['user'];
    $pass = $_POST['pass'];

    try {
        // First fetch user row by email or username
        $stmt = $conn->prepare("SELECT * FROM users WHERE (email = :user OR username = :user) and password = :pass LIMIT 1");
        $stmt->execute([':user' => $user, ':pass' => $pass]);
        $result = $stmt->fetch(PDO::FETCH_ASSOC);

        if ($result) {
            echo json_encode(['success' => true]);
            $_SESSION['logInUser'] = $result;
        } else {
            echo json_encode(['success' => false, 'message' => 'No account found with that email or username.']);
        }
    } catch (Exception $e) {
        echo json_encode(['success' => false, 'message' => 'Server error, please try again later.']);
    }



?>
