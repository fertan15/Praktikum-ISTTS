<?php

include 'koneksi.php';
$_SESSION['logInUser'] = null;  

?>

<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>Discord Login</title>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css">
  <link rel="stylesheet" href="login.css" />
  <script src="https://code.jquery.com/jquery-3.7.1.js" integrity="sha256-eKhayi8LEQwp4NKxN+CfCh+3qOVUtJn3QNZ0TciWLP4=" crossorigin="anonymous"></script>

</head>
<body>
  <!-- Logo -->
  <div class="top-logo">
    <img src="discordLogo.png" alt="Discord Logo">
    <span>Discord</span>
  </div>

  <!-- Background -->
  <div class="background"></div>

  <!-- Login box -->
  <div class="login-container">
    <h2>Welcome back!</h2>
    <p class="subtitle">We're so excited to see you again!</p>

      <div class="message">
    </div>


    <form id="form">
  <label>Email or Phone Number <span>*</span></label>
  <input type="text" id="user" name="user" placeholder="Enter your email or phone number" />

  <label>Password <span>*</span></label>
  <input type="password" id="pass" name="pass" placeholder="Enter your password" />

      <a href="#" class="forgot">Forgot your password?</a>

      <button type="submit">Log In</button>

      <p class="register">Need an account? <a href="register.php">Register</a></p>
    </form>
  </div>
</body>

<script>

    $('#form').on('submit', function(event) {
        event.preventDefault();
        $.ajax({
            type: "post",
            url: "cekLogin.php",
            data: $(this).serialize(),
            dataType: "json",
            success: function (response) {
                if (response.success) {
                    window.location.href = "dashboard.php";
                } else {
                    $('.message').html(
                        '<div class="alert"> <i class="fa fa-exclamation-circle"></i> ' + response.message + '</div>'
                    );
                }
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    });
</script>

</html>

