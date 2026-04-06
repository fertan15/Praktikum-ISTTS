@extends('template.template')

@section('styles')
    /* Basic Reset */
    body, h1, h2, h3, p, ul {
        margin: 0;
        padding: 0;
        box-sizing: border-box; /* Include padding and border in element's total width and height */
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
        height: 70vh;
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

    /* --- HOW TO PLAY SECTION STYLES START (Adjusted for exact match) --- */
    .how-to-play-section {
        background-color: #fdf7e3; /* Light cream background from image */
        padding: 60px 0; /* Adjusted padding */
        color: #333; /* Dark text for this section */
    }
    .container {
        max-width: 1100px; /* Container width */
        margin-left: auto;
        margin-right: auto;
        padding-left: 24px;  /* Spacing */
        padding-right: 24px;
    }
    .how-to-play-section h2 {
        font-size: 2.25rem; /* ~36px */
        font-weight: 900;
        text-align: center;
        margin-bottom: 50px; /* Adjusted spacing */
        letter-spacing: 0.5px; /* Slight letter spacing */
        color: #2a2a2a; /* Darker title color */
    }
    .how-to-grid {
        display: grid;
        grid-template-columns: 1fr; /* 1 column by default */
        gap: 30px; /* Gap between cards */
        justify-items: center; /* Center cards horizontally on smaller screens */
    }

    /* Responsive grid for tablets and desktops */
    @media (min-width: 768px) {
        .how-to-grid {
            grid-template-columns: repeat(3, 1fr); /* 3 columns on larger screens */
            gap: 20px; /* Smaller gap on larger screens */
        }
    }
    @media (min-width: 1024px) {
        .how-to-grid {
            gap: 40px; /* Wider gap on very large screens */
        }
    }


    .how-to-card {
        text-align: left;
        padding-bottom: 25px; /* Padding at the bottom of the card content */
        border-radius: 8px; /* Slightly rounded corners */
        overflow: hidden; /* Ensures image corners are rounded */
        max-width: 320px; /* Limit card width to match image proportion */
    }

    .how-to-card img {
        width: 100%;
        height: auto; /* Maintain aspect ratio */
        display: block;
        margin-bottom: 25px; /* Space between image and text */
    }
    .how-to-card h3 {
        font-size: 1.3rem; /* Adjusted font size */
        font-weight: 700;
        margin-bottom: 10px;
        color: #333;
        padding: 0 25px; /* Inner padding for text */
    }
    .how-to-card p {
        font-size: 0.95rem; /* Adjusted font size */
        color: #666; /* Slightly darker grey text */
        margin-bottom: 15px;
        line-height: 1.5;
        padding: 0 25px; /* Inner padding for text */
    }
    .how-to-card a {
        color:black;
        font-weight: bold; /* Bold like the image */
        text-decoration: underline; /* No underline by default */
        font-size: 0.875rem; /* 14px */
        padding: 0 25px; /* Inner padding for link */
        display: inline-block; /* To allow padding and margin */
        position: relative;
        text-transform: uppercase; /* Uppercase like the image */
        letter-spacing: 0.5px;
    }
    .how-to-card a:hover {
        text-decoration: underline; /* Underline on hover */
    }
    /* --- HOW TO PLAY SECTION STYLES END --- */
@endsection

@section('content')
    <!-- --- NEW SECTION HTML START --- -->
     <div style="background-color: #1a1a1a; text-align: center; padding : 40px 0px">
             <h2>HOW TO PLAY MINECRAFT</h2>
     </div>
     <section class="how-to-play-section">
        <div class="container">
            
            <div class="how-to-grid">
                
                <!-- Card 1: Getting Started --><div class="how-to-card">
                    <img src="{{ asset('assets/Onboarding_Card-A_Getting-Started_600x600.avif') }}" alt="Getting Started">
                    <h3>Getting Started</h3>
                    <p>Everything you need to know before you start playing Minecraft.</p>
                    <a href="#">START NOW</a>
                </div>

                <!-- Card 2: For Beginners --><div class="how-to-card">
                    <img src="{{ asset('assets/Onboarding_Card-A_For-Beginners_600x600.webp') }}" alt="For Beginners">
                    <h3>For Beginners</h3>
                    <p>Nifty tips and tricks for surviving and creating in the Overworld and beyond.</p>
                    <a href="#">EXPLORE TIPS</a>
                </div>

                <!-- Card 3: Level Up! --><div class="how-to-card">
                    <img src="{{ asset('assets/Onboarding_Card-A_Level-Up_600x600.webp') }}" alt="Level Up!">
                    <h3>Level Up!</h3>
                    <p>For players looking to take their experience to the next dimension.</p>
                    <a href="#">LEARN MORE</a>
                </div>

            </div>
        </div>
    </section>
    <!-- --- NEW SECTION HTML END --- -->
     @endsection

