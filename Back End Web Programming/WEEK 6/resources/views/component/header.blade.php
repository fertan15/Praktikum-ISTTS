<header style="background-color: #1a1a1a; color: #ffffff; padding: 20px 40px; display: flex; justify-content: space-between; align-items: center; font-family: Arial, sans-serif; 
    
    /* --- TAMBAHAN DI SINI --- */
    position: sticky; 
    top: 0; 
    z-index: 1000;
    /* --- SELESAI --- */
    ">
    
    <div style="display: flex; align-items: center;">
        <img src="{{ asset('assets/minecraft.png') }}" alt="Your Logo" style="width: 240px; height: auto;">
    </div>
    
    <nav>
        <ul style="list-style: none; margin: 0; padding: 0; display: flex; gap: 25px;">
            <li><a href="{{ url('/Minecraft') }}" style="color: #ffffff; text-decoration: none; font-weight: bold; font-size: 14px;">GAMES</a></li>
            <li><a href="{{ url('/Shop') }}" style="color: #ffffff; text-decoration: none; font-weight: bold; font-size: 14px;">SHOP</a></li>
            <li><a href="{{ url('/News') }}" style="color: #ffffff; text-decoration: none; font-weight: bold; font-size: 14px;">NEWS</a></li>
            <li><a href="{{ url('/Support') }}" style="color: #ffffff; text-decoration: none; font-weight: bold; font-size: 14px;">SUPPORT</a></li>
        </ul>
    </nav>
    
    <div style="display: flex; align-items: center; gap: 25px;">
        <a href="#" style="background-color: #5cb85c; color: #ffffff; padding: 10px 20px; border-radius: 5px; text-decoration: none; font-weight: bold; font-size: 14px;">BUY NOW</a>
        <a href="#" style="color: #ffffff; font-weight: bold; font-size: 14px; text-decoration: none;">ACCOUNT</a>
    </div>
    
</header>