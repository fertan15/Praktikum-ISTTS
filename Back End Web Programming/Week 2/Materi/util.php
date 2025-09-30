<?php
    
session_start();
require_once 'dummy.php';

// error handling
function showError($message) {
    echo "<p style='color:red'>$message</p>";
}

// data dummy
if (!isset($_SESSION['users'])) {
    $_SESSION['users'] = [
        ['id' => 1, 'username' => 'admin', 'password' => 'admin123', 'email' => 'admin@example.com', 'admin' => true, 'banned' => false, 'orders' => [], 'cart' => []],
        ['id' => 2, 'username' => 'ferfer', 'password' => '123', 'email' => 'ferfer@example.com', 'admin' => false, 'banned' => false, 'orders' => [], 'cart' => []],
        ['id' => 3, 'username' => 'fed', 'password' => '123', 'email' => 'fed@example.com', 'admin' => false, 'banned' => false, 'orders' => [], 'cart' => []],
    ];
}

if(!isset($_SESSION['Allorders'])) {
    $_SESSION['Allorders'] = [];
}


function getUserDetails($userId) {
    foreach ($_SESSION['users'] as $user) {
        if ($user['id'] === $userId) {
            return $user;
        }
    }
    return null;
}

?>