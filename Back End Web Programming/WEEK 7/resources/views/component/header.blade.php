<style>
    /* CSS untuk Dropdown Account */
    .account-menu {
        position: relative;
        display: inline-block;
    }

    /* Konten dropdown (hidden by default) */
    .account-dropdown-content {
        display: none;
        position: absolute;
        background-color: #2b2b2b; /* Warna dropdown */
        min-width: 160px;
        box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
        z-index: 1;
        right: 0; /* Align ke kanan */
        border-radius: 5px;
        padding: 10px 0;
    }

    /* Link di dalam dropdown */
    .account-dropdown-content a {
        color: #f1f1f1;
        padding: 12px 16px;
        text-decoration: none;
        display: block;
        font-size: 14px;
    }

    /* Warna link saat di-hover */
    .account-dropdown-content a:hover {
        background-color: #444;
    }

    /* Tampilkan dropdown saat .account-menu di-hover */
    .account-menu:hover .account-dropdown-content {
        display: block;
    }

    /* Style untuk link header */
    .header-link {
        color: #ffffff; 
        text-decoration: none; 
        font-weight: bold; 
        font-size: 14px;
    }
    .header-icon {
        color: #ffffff;
        font-size: 18px; /* Ukuran ikon */
    }
</style>

<header style="background-color: #1e1e1e; color: #ffffff; padding: 20px 40px; display: flex; justify-content: space-between; align-items: center; font-family: Arial, sans-serif;
    position: sticky;
    top: 0;
    z-index: 1000;
    border-bottom: 1px solid #333;
    ">
    
    <div style="display: flex; align-items: center; gap: 40px;">
        <a href="{{ route('minecraft') }}">
            <img src="{{ asset('assets/minecraft.png') }}" alt="Minecraft Logo" style="width: 180px; height: auto;">
        </a>
        <nav>
            <ul style="list-style: none; margin: 0; padding: 0; display: flex; gap: 25px;">
                <li><a href="{{ route('minecraft') }}" class="header-link">GAMES</a></li>
                <li><a href="{{ route('shop') }}" class="header-link">SHOP</a></li>
                <li><a href="{{ route('news') }}" class="header-link">NEWS</a></li>
                <li><a href="{{ route('support') }}" class="header-link">SUPPORT</a></li>
            </ul>
        </nav>
    </div>
    
    <div style="display: flex; align-items: center; gap: 25px;">
        <a href="{{ route('choose-game') }}" style="background-color: #5cb85c; color: #ffffff; padding: 10px 20px; border-radius: 5px; text-decoration: none; font-weight: bold; font-size: 14px;">BUY NOW</a>
        
        <a href="#" class="header-icon"><i class="fas fa-search"></i></a>
        <a href="{{ route('cart') }}" class="header-icon" style="position: relative;">
            <i class="fas fa-shopping-cart"></i>
            </a>

        <div class="account-menu">
            <a href="#" class="header-link">ACCOUNT <i class="fas fa-user"></i></a>
            <div class="account-dropdown-content">
                <a href="{{ route('login') }}"><i class="fas fa-sign-in-alt" style="margin-right: 8px;"></i>Login</a> 
                <a href="{{ route('register') }}"><i class="fas fa-user-plus" style="margin-right: 8px;"></i>Register</a>
            </div>
        </div>

        </div>
</header>