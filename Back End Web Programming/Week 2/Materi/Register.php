<?php require_once 'util.php'; 

$_SESSION['error'] = "";
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $username = $_POST['username'];
    $password = $_POST['password'];
    $Kpassword = $_POST['Kpassword'];
    $email = $_POST['email'];
    
    if($password !== $Kpassword) {
        $_SESSION['error'] = "Konfirmasi password tidak sesuai!";
        goto showForm;
    }

    // Check if username exists
    foreach ($_SESSION['users'] as $user) {
        if ($user['username'] === $username) {
            $_SESSION['error'] = "Username sudah ada!";
            goto showForm;
        }
    }
    
    // Add new user
    $newId = count($_SESSION['users']) + 1;
    $_SESSION['users'][] = ['id' => $newId, 'username' => $username, 'password' => $password, 'email' => $email, 'admin' => false, 'banned' => false, 'orders' => [], 'cart' => []];
    $_SESSION['users'] = array_values($_SESSION['users']);
    
    header("Location: login.php");
    exit();
}

    showForm:
?>



<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
</head>
<body>
    <h1>Halaman Register</h1>
    <form method="POST">
        <table>
            <tr>
                <td><p>Username:</p></td>
                <td><p><input type="text" name="username" required></p></td>
            </tr>
            <tr>
                <td><p>Email:</p></td>
                <td><p><input type="email" name="email" required></p></td>
            </tr>
            <tr>
                <td><p>Password:</p></td>
                <td><p><input type="password" name="password" required></p></td>
            </tr>
            <tr>
                <td><p>Konfirmasi Password:</p></td>
                <td><p><input type="password" name="Kpassword" required></p></td>
            </tr>
        </table>
        <p><input type="submit" value="Register"></p>
    </form>
    <p>Sudah punya akun? <a href="login.php">login di sini</a></p>
    <?php showError($_SESSION['error']);?>
</body>
</html>