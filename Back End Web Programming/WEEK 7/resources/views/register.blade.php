@extends('template.template')

@section('styles')
    {{-- Menggunakan style yang mirip dengan login --}}
        main{
            color: #ffffff;
        }
        .register-container {
            width: 100%;
            max-width: 480px;
            margin: 50px auto;
            padding: 40px;
            background-color: #2b2b2b;
            border-radius: 8px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.5);
        }
        .register-container h1 {
            text-align: center;
            margin-bottom: 10px;
        }
        .register-container p {
            text-align: center;
            color: #ccc;
            margin-bottom: 30px;
        }
        .form-group {
            margin-bottom: 20px;
        }
        .form-group label {
            display: block;
            margin-bottom: 8px;
            font-weight: bold;
            font-size: 14px;
        }
        /* Style untuk input teks dan email */
        .form-group input[type="text"],
        .form-group input[type="email"] {
            width: 100%;
            padding: 12px;
            background-color: #333;
            border: 1px solid #555;
            border-radius: 5px;
            color: white;
            box-sizing: border-box;
        }
        
        /* Container untuk input password */
        .password-container {
            position: relative;
        }
        .password-container input[type="password"] {
            width: 100%;
            padding: 12px;
            padding-right: 45px; /* Ruang untuk ikon mata */
            background-color: #333;
            border: 1px solid #555;
            border-radius: 5px;
            color: white;
            box-sizing: border-box; 
        }
        .toggle-password {
            position: absolute;
            right: 15px;
            top: 50%;
            transform: translateY(-50%);
            cursor: pointer;
            color: #999;
        }
        /* Teks "Password strength" sesuai PDF */
        .form-group .password-strength {
            font-size: 12px;
            color: #888;
            margin-top: 5px;
        }
        
        /* Checkbox "I agree" */
        .form-group-checkbox {
            display: flex;
            align-items: center;
            gap: 10px;
            font-size: 14px;
            margin-bottom: 20px;
        }
        .form-group-checkbox a {
            color: #5cb85c;
        }
        
        /* Tombol "Create Account" */
        .btn-create {
            width: 100%;
            padding: 15px;
            background-color: #5cb85c;
            border: none;
            border-radius: 5px;
            color: white;
            font-weight: bold;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s;
        }
        .btn-create:hover {
            background-color: #4cae4c;
        }
        .divider {
            text-align: center;
            margin: 30px 0;
            color: #888;
        }
        .social-login {
            display: flex;
            gap: 15px;
        }
        .social-btn {
            flex: 1;
            padding: 12px;
            border-radius: 5px;
            background-color: #444;
            text-align: center;
            font-weight: bold;
            cursor: pointer;
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 8px;
        }
@endsection

@section('content')
    <div class="register-container">
        <!-- Logo -->
        <img src="{{ asset('assets/minecraft.png') }}" alt="Minecraft Logo" style="width: 250px; display: block; margin: 0 auto 30px auto;">

        <h1>Join Minecraft</h1>
        <p>Create your account to start your adventure</p>

        <!-- 
          Form ini mengirim data ke rute 'register.post'
          yang ditangani oleh RegisterController.
        -->
        <form action="{{ route('register.post') }}" method="POST">
            @csrf
            
            <div class="form-group">
                <label for="fullname"><i class="fas fa-user" style="margin-right: 8px;"></i>Full Name</label>
                <input type="text" id="fullname" name="fullname" placeholder="Enter your full name" required>
            </div>
            
            <div class="form-group">
                <label for="email"><i class="fas fa-envelope" style="margin-right: 8px;"></i>Email Address</label>
                <input type="email" id="email" name="email" placeholder="Enter your email" required>
            </div>
            
            <div class="form-group">
                <label for="username"><i class="fas fa-at" style="margin-right: 8px;"></i>Username</label>
                <input type="text" id="username" name="username" placeholder="Choose a username" required>
            </div>
            
            <div class="form-group">
                <label for="password"><i class="fas fa-lock" style="margin-right: 8px;"></i>Password</label>
                <div class="password-container">
                    <input type="password" id="password" name="password" placeholder="Create a strong password" required>
                    <i class="fas fa-eye toggle-password" id="togglePassword"></i>
                </div>
                <!-- Sesuai PDF: "Password strength" -->
                <div class="password-strength">Password strength</div>
            </div>
            
            <div class="form-group">
                <label for="confirm_password"><i class="fas fa-check-double" style="margin-right: 8px;"></i>Confirm Password</label>
                <div class="password-container">
                    <!-- 'name' harus "password_confirmation" jika menggunakan validasi Laravel -->
                    <input type="password" id="confirm_password" name="password_confirmation" placeholder="Confirm your password" required>
                    <i class="fas fa-eye toggle-password" id="toggleConfirmPassword"></i>
                </div>
            </div>
            
            <!-- Sesuai PDF: "Checkbox agree harus dicentang" -->
            <div class="form-group-checkbox">
                <input type="checkbox" id="agree" name="agree" required>
                <label for="agree">I agree to the <a href="#">Terms of Service</a> and <a href="#">Privacy Policy</a></label>
            </div>
            
            <button type="submit" class="btn-create"><i class="fas fa-user-plus" style="margin-right: 5px;"></i> Create Account</button>
        </form>
        
        <p style="text-align: center; margin-top: 20px;">
            Already have an account? <a href="{{ route('login') }}" style="color: #5cb85c;">Sign in here</a>
        </p>
        
        <div class="divider">Or register with</div>

        <div class="social-login">
            <div class="social-btn"><i class="fab fa-google"></i> Google</div>
            <div class="social-btn"><i class="fab fa-microsoft"></i> Microsoft</div>
        </div>
    </div>
@endsection