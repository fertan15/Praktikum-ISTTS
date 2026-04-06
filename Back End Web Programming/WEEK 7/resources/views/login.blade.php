@extends('template.template')

{{-- Ini adalah section untuk CSS khusus halaman login --}}
@section('styles')
        .login-container {
            width: 100%;
            max-width: 450px;
            margin: 50px auto;
            padding: 40px;
            background-color: #2b2b2b;
            border-radius: 8px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.5);
            color: #ccc;

        }
        .login-container h1 {
            text-align: center;
            margin-bottom: 10px;
        }
        .login-container p {
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
        .form-group input[type="email"] {
            width: 100%;
            padding: 12px;
            background-color: #333;
            border: 1px solid #555;
            border-radius: 5px;
            color: white;
            box-sizing: border-box; /* Untuk padding yang benar */
        }
        
        /* Container untuk password agar bisa ditaruh ikon */
        .password-container {
            position: relative;
        }
        
        /* Input password di dalam container */
        .password-container input {
            width: 100%;
            padding: 12px;
            padding-right: 45px; /* Memberi ruang untuk ikon mata */
            background-color: #333;
            border: 1px solid #555;
            border-radius: 5px;
            color: white;
            box-sizing: border-box; 
        }

        /* Ikon mata (toggle password) */
        .toggle-password {
            position: absolute;
            right: 15px;
            top: 50%;
            transform: translateY(-50%);
            cursor: pointer;
            color: #999;
        }

        .form-options {
            display: flex;
            justify-content: space-between;
            align-items: center;
            font-size: 14px;
            margin-bottom: 20px;
        }
        .form-options label {
            font-weight: normal;
        }
        .form-options a {
            color: #5cb85c;
        }
        .btn-signin {
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
        .btn-signin:hover {
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
        
        /* Box untuk menampilkan error validasi */
        .error-box {
            background-color: #c0392b; /* Merah tua */
            color: white;
            padding: 15px;
            border-radius: 5px;
            margin-bottom: 20px;
            font-size: 14px;
        }
        .error-box ul {
            margin: 0;
            padding-left: 15px; /* Indentasi untuk list */
            list-style-type: disc;
        }
        .error-box li {
            margin-bottom: 5px;
        }
@endsection


{{-- Ini adalah section untuk konten utama halaman --}}
@section('content')
    <div class="login-container">
        <!-- Logo (Sesuai Gambar) -->
        <img src="{{ asset('assets/minecraft.png') }}" alt="Minecraft Logo" style="width: 250px; display: block; margin: 0 auto 30px auto;">

        <h1>Welcome Back</h1>
        <p>Sign in to your Minecraft account</p>

        <!-- 
          Blok ini akan muncul jika ada error validasi dari Controller.
          Sesuai aturan: "Form input tidak boleh kosong" & "Credentials benar"
        -->
        @if ($errors->any())
            <div class="error-box">
                <ul>
                    @foreach ($errors->all() as $error)
                        <li>{{ $error }}</li>
                    @endforeach
                </ul>
            </div>
        @endif

        <!-- 
          Form ini akan mengirim data ke Rute POST.
          Pastikan kamu membuat Rute POST di web.php nanti.
          Contoh: Route::post('/Login', [LoginController::class, 'authenticate'])->name('login.post');
        -->
        <form action="#" method="POST">
            @csrf <!-- Token Keamanan Laravel (WAJIB) -->
            
            <div class="form-group">
                <label for="email"><i class="fas fa-envelope" style="margin-right: 8px;"></i>Email Address</label>
                <input type="email" id="email" name="email" placeholder="Enter your email" required value="{{ old('email') }}" required>
            </div>
            
            <div class="form-group">
                <label for="password"><i class="fas fa-lock" style="margin-right: 8px;"></i>Password</label>
                <!-- Container untuk Password & Ikon Mata -->
                <div class="password-container">
                    <input type="password" id="password" name="password" placeholder="Enter your password" required>
                    <!-- Ikon ini dari Font Awesome (sudah ada di template) -->
                    <i class="fas fa-eye toggle-password" id="togglePassword"></i>
                </div>
            </div>
            
            <div class="form-options">
                <div>
                    <!-- Aturan: "remember me jika di checklist maka akan set cookie selama 1 jam" -->
                    <input type="checkbox" id="remember" name="remember">
                    <label for="remember">Remember me</label>
                </div>
                <a href="#">Forgot password?</a>
            </div>
            
            <button type="submit" class="btn-signin">
                <i class="fas fa-sign-in-alt"></i> Sign In
            </button>
        </form>
        
        <p style="text-align: center; margin-top: 20px;">
            Don't have an account? <a href="{{ route('register') }}" style="color: #5cb85c;">Create account</a>
        </p>
        
        <div class="divider">Or continue with</div>

        <!-- Aturan: "Untuk bagian Google dan Microsoft hanya tampilan saja" -->
        <div class="social-login">
            <div class="social-btn"><i class="fab fa-google"></i> Google</div>
            <div class="social-btn"><i class="fab fa-microsoft"></i> Microsoft</div>
        </div>
    </div>
@endsection