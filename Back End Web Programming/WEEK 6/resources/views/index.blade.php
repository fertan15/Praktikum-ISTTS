@extends('template.template')

@section('styles')
    body, h1, h2, h3, p, ul {
        margin: 0;
        padding: 0;
    }

    
    body {
        font-family: 'Inter', sans-serif;
        background-color: #18181b; /* Dark background */
        color: #f4f4f5; /* Light text */
        display: flex;
        flex-direction: column;
        min-height: 100vh;
    }

    main.flex-grow {
        flex-grow: 1; /* Ensures main content pushes footer down */
    }

    /* Hero Section */
    .hero-section {
        background-image: url("{{ asset('assets/Legends-PMP_Hero-Art_FullBleedA_Desktop_2880x1320.jpg') }}");
        background-size: cover;
        background-position: center;
        height: 95vh;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        text-align: center;
        position: relative;
        padding: 0 20px;
    }

    .hero-section::before {
        content: '';
        position: absolute;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        background-color: rgba(0, 0, 0, 0.4); /* Dark overlay */
    }

    .hero-content {
        position: relative;
        z-index: 10;
    }

    .hero-content h1 {
        font-size: 3.5rem; /* 56px */
        font-weight: 900;
        margin-bottom: 24px;
        text-shadow: 2px 2px 8px rgba(0,0,0,0.7);
    }

    /* Custom button style to match the green "BUY NOW" */
    .btn-green {
        background-color: #5cb85c;
        color: white;
        font-weight: bold;
        padding: 12px 30px;
        border-radius: 6px;
        text-decoration: none;
        font-size: 1.125rem; /* 18px */
        transition: background-color 0.3s ease;
    }
    .btn-green:hover {
        background-color: #4cae4c;
    }

 
@endsection

@section('content')
    
    <!-- Hero Section -->
    <section class="hero-section">
        <div class="hero-content">
            <h1>Welcome to Minecraft</h1>
            <a href="#" class="btn-green">
                GET STARTED
            </a>
        </div>
    </section>

@endsection

