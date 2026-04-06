<?php

    header('Content-Type: application/json');
    include 'koneksi.php';

    if(!isset($_POST['username']) || !isset($_POST['email']) || !isset($_POST['password']) || !isset($_POST['confirm_password'])) {
        echo json_encode(['success' => false, 'message' => 'Please fill in all fields.']);
        exit;
    }

    if($_POST['password'] !== $_POST['confirm_password']) {
        echo json_encode(['success' => false, 'message' => 'Passwords do not match.']);
        exit;
    }

    $randomInt = random_int(0, 4);

    if($randomInt == 0){
        $randomStatus = 'Online';
    } else if($randomInt == 1){
        $randomStatus = 'away';
    } else if($randomInt == 2){
        $randomStatus = 'busy';
    } else{
        $randomStatus = 'offline';
    } 
    $username = $_POST['username'];
    $email = $_POST['email'];
    $password = $_POST['password'];

    try {
        $stmt = $conn->prepare("insert into users (username, email, password, status) values (:username, :email, :password, :status)");
        $stmt->execute([':username' => $username, ':email' => $email, ':password' => $password, ':status' => $randomStatus]);

        echo json_encode(['success' => true]);
    } catch (Exception $e) {
        echo json_encode(['success' => false, 'message' => 'Server error, please try again later.']);
    }


?>