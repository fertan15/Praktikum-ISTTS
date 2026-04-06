<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>Discord Register</title>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css">
  <link rel="stylesheet" href="register.css" />
  <script src="https://code.jquery.com/jquery-3.7.1.js" integrity="sha256-eKhayi8LEQwp4NKxN+CfCh+3qOVUtJn3QNZ0TciWLP4=" crossorigin="anonymous"></script>

</head>
<body>
  <!-- Top-left Logo -->
  <div class="top-logo">
    <img src="discordLogo.png" alt="Discord Logo">
    <span>Discord</span>
  </div>

  <!-- Background -->
  <div class="background"></div>

  <!-- Register Box -->
  <div class="register-container">
    <h2>Create an account</h2>
    <p class="subtitle">Join millions of others on Discord!</p>

    <div class="message">
    </div>

    <form id="regis">
      <label>Username <span>*</span></label>
      <input type="text" placeholder="Enter your username" name="username" required>

      <label>Email <span>*</span></label>
      <input type="email" placeholder="Enter your email" name="email" required>

      <label>Password <span>*</span></label>
      <input type="password" placeholder="Enter your password" name="password" required>

      <label>Confirm Password <span>*</span></label>
      <input type="password" placeholder="Confirm your password" name="confirm_password" required>

      <div class="checkbox">
        <input type="checkbox" id="tos" required>
        <label for="tos">
          By registering, you agree to Discord's 
          <a href="#">Terms of Service</a> and 
          <a href="#">Privacy Policy</a>.
        </label>
      </div>

      <button type="submit">Create Account</button>

      <p class="login-link">Already have an account? <a href="login.php">Login</a></p>
    </form>
  </div>


  <script>
    $('#regis').on('submit', function(e) {
      
      console.log( $(this).serialize());
      e.preventDefault();
      $.ajax({
        type: "post",
        url: "regis.php",
        data: $(this).serialize(),
        dataType: "json",
        success: function (response) {
          if (response.success) {
              console.log("Registration successful");
              window.location.href = "login.php";
          } else {
              console.log("Registration failed: " + response.message);
              $('.message').html(
                  '<div class="alert"> <i class="fa fa-exclamation-circle"></i> ' + response.message + '</div>'
              );
          }

        }
      });
    });
  </script>
</body>
</html>
