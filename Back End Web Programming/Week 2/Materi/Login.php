<?php require_once 'util.php'; 

    $_SESSION['error'] = "";
    if (isset($_GET['error']) && $_GET['error'] === 'direct') {
        $_SESSION['error'] = "access denied. This page is for logged in users only.";
    }
    if (isset($_GET['error']) && $_GET['error'] === 'directadmin') {
        $_SESSION['error'] = "access denied. Please login as admin.";
    }

    if ($_SERVER['REQUEST_METHOD'] === 'POST') {
        $username = $_POST['username'];
        $password = $_POST['password'];
        $remember = isset($_POST['remember']);
        
        foreach ($_SESSION['users'] as $user) {
            if ($user['username'] === $username && $user['password'] === $password) {
                if($user['banned'] == true) {
                    $_SESSION['error'] = "Akun anda dibanned. Silahkan hubungi admin.";
                    goto showForm;
                }


                $_SESSION['Logged_in_user'] = $user;
                $_SESSION['logged_in'] = true;
                $_SESSION['username'] = $username;   
                $_SESSION['cart'] = $user['cart'];
                if($user['admin'] == true) {
                    header("Location: admin.php");
                    exit();
                }
                header("Location: index.php");
                exit();
            }
        }
        $_SESSION['error'] = "Username atau password salah!";
        
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
    <h1>Halaman Login</h1>
    <form method="POST">
        <p>Username: <input type="text" name="username" required></p>
        <p>Password: <input type="password" name="password" required></p>
        <p><input type="submit" value="Login"></p>
    </form>
    <p>Belum punya akun? <a href="register.php">Daftar di sini</a></p>
    <?php showError($_SESSION['error']);?>
</body>
</html>