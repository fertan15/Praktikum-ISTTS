@extends('template.template')

@section('styles')
    /* Reset dasar */
    body, h1, h2, h3, p, ul {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
    }

    body {
        font-family: 'Inter', sans-serif;
        background-color: white; /* Background gelap */
        color: #f4f4f5; /* Teks terang */
    }

    main { 
        display: block; 
    }

    /* --- BAGIAN HERO FILM BARU (CSS-Only) --- */
    
    /* 1. Layer Foreground (Logo) - Akan scroll ke atas */
    .hero-foreground-scroll {
        height: 100vh; /* Set tinggi agar memenuhi layar */
        background-image: url("{{ asset('assets/Logo.avif') }}");
        
        /* --- PERUBAHAN DI SINI --- */
        background-size: 80vh auto; /* Tinggi gambar 80% dari viewport, lebar otomatis */
        /* background-size: contain; // Atau coba ini jika ingin seluruh gambar selalu terlihat */
        /* background-size: 1000px auto; // Atau coba nilai piksel spesifik */
        
        background-position: center center; /* Posisikan di tengah elemen */
        background-repeat: no-repeat;
        position: relative; /* Untuk z-index */
        z-index: 10; /* Tampil paling depan */
    }

    /* 2. Layer Background (Pemandangan) - Ini akan "Sticky" */
    .hero-background-sticky {
        height: 100vh; /* Set tinggi agar memenuhi layar */
        background-image: url("{{ asset('assets/AMM_Parallax-Desktop_Focus_1920x1057.webp') }}");
        background-position: center top;
        background-size: cover;
        background-repeat: no-repeat;
        
        position: sticky; /* Kunci utamanya! */
        top: 0; /* Menempel di bagian atas viewport */
        
        /* Tarik ke atas agar berada di belakang .hero-foreground-scroll */
        margin-top: -100vh; 
        
        z-index: 1; /* Tampil di belakang logo dan konten */
    }
    
    /* 3. Bagian Konten */
    .dummy-content {
        padding: 60px 24px;
        max-width: 1100px;
        margin: auto;
        min-height: 500px;
        
        position: relative; /* Untuk z-index */
        z-index: 5; /* Tampil di atas background sticky */
    }

    .dummy-content h2 {
        font-size: 2.25rem;
        font-weight: 900;
        margin-bottom: 24px;
    }

    .dummy-content p {
        font-size: 1.1rem;
        line-height: 1.7;
        margin-bottom: 20px;
    }
@endsection

@section('content')
    
    <section class="hero-foreground-scroll">
        <!-- Konten kosong, hanya background-image dari CSS --></section>

    <section class="hero-background-sticky">
        <!-- Konten kosong, hanya background-image dari CSS --></section>

    <section class="dummy-content">
    </section>

@endsection

