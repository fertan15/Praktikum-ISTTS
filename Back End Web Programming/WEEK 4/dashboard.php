<?php
// Catatan: File ini harus dijalankan melalui server web lokal (seperti XAMPP/MAMP)
// dan disimpan dengan ekstensi .php.
include 'koneksi.php';


// Tambahkan pengamanan sederhana: Redirect jika pengguna belum login
if (!isset($_SESSION['logInUser'])) {
    header('Location: login.php');
    exit();
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Discord-Style UI Clone</title>
    <!-- Load Tailwind CSS -->
    <script src="https://cdn.tailwindcss.com"></script>
    <!-- Load Lucide Icons -->
    <script src="https://unpkg.com/lucide@latest"></script>
    <!-- Load jQuery (required for the AJAX below) -->
    <script src="https://code.jquery.com/jquery-3.7.1.js" integrity="sha256-eKhayi8LEQwp4NKxN+CfCh+3qOVUtJn3QNZ0TciWLP4=" crossorigin="anonymous"></script>
    
    <style>
        /* Custom colors to match Discord's dark theme */
        :root {
            --bg-darker: #1e1f22; /* Server Bar */
            --bg-dark: #2b2d31;   /* Channel/DM List */
            --bg-medium: #313338; /* Main Content Area */
            --text-primary: #f2f3f5;
            --text-secondary: #949ba4;
            --accent-purple: #5865f2;
            --online-green: #3ba55d;
        }

        .server-bar { background-color: var(--bg-darker); }
        .sidebar-dm { background-color: var(--bg-dark); }
        .main-content { background-color: var(--bg-medium); }

        body {
            font-family: 'Inter', sans-serif;
            color: var(--text-primary);
            overflow: hidden; /* Prevent body scroll */
        }
        
        /* Utility to make icons from Lucide work */
        .icon {
            display: inline-block;
            stroke-width: 2;
            stroke-linecap: round;
            stroke-linejoin: round;
        }

        /* Styling for the blue chat bubble (outgoing) */
        .chat-bubble-self {
            background-color: var(--accent-purple);
            color: var(--text-primary);
            max-width: 70%;
            border-radius: 8px 8px 0 8px; /* Top-left, Top-right, Bottom-left, Bottom-right */
        }

        /* Styling for the dark chat bubble (incoming) */
        .chat-bubble-friend {
            background-color: #2f3136; /* Slightly lighter dark gray */
            color: var(--text-primary);
            max-width: 70%;
            border-radius: 8px 8px 8px 0;
        }
    </style>
    <script>
        tailwind.config = {
            theme: {
                extend: {
                    colors: {
                        'server-bar': 'var(--bg-darker)',
                        'sidebar-dm': 'var(--bg-dark)',
                        'main-content': 'var(--bg-medium)',
                        'text-secondary': 'var(--text-secondary)',
                        'accent-purple': 'var(--accent-purple)',
                        'online-green': 'var(--online-green)',
                    }
                }
            }
        }
    </script>
</head>
<body class="h-screen w-screen flex">

    <!-- 1. Server Bar (Far Left) -->
    <div class="server-bar flex flex-col items-center py-3 space-y-2 w-16 h-full flex-shrink-0">
        <!-- Home Icon -->
        <div class="group relative w-12 h-12 flex items-center justify-center rounded-2xl bg-accent-purple hover:rounded-xl transition-all duration-200 cursor-pointer">
            <i data-lucide="compass" class="icon w-6 h-6 text-white"></i>
        </div>

        <div class="h-0.5 w-8 bg-gray-700 rounded-full"></div>

        <!-- Server Icons -->
        <div class="server-icon w-12 h-12 bg-gray-700 hover:bg-online-green rounded-full hover:rounded-xl transition-all duration-200 cursor-pointer flex items-center justify-center text-lg font-bold">
            <i data-lucide="plus" class="icon w-6 h-6 text-online-green hover:text-white"></i>
        </div>
        <div class="server-icon w-12 h-12 bg-gray-700 hover:bg-online-green rounded-full hover:rounded-xl transition-all duration-200 cursor-pointer flex items-center justify-center text-lg font-bold">
            <i data-lucide="rocket" class="icon w-6 h-6 text-online-green hover:text-white"></i>
        </div>
    </div>

    <!-- 2. DM/Channel Sidebar (Middle Left) -->
    <div class="sidebar-dm flex flex-col w-60 h-full flex-shrink-0 border-r border-black/20">

        <!-- Search Header -->
        <div class="p-3 shadow-md border-b border-black/10">
            <div class="relative">
                <input type="text" placeholder="Find or start a conversation" class="w-full bg-gray-900/40 text-sm text-text-primary placeholder-text-secondary rounded-md p-1.5 focus:outline-none focus:ring-1 focus:ring-accent-purple">
                <i data-lucide="search" class="icon w-4 h-4 absolute right-2 top-1/2 -translate-y-1/2 text-text-secondary"></i>
            </div>
        </div>

        <!-- Navigation Links -->
        <div class="flex-grow overflow-y-auto pt-2 px-2 space-y-1">
            <div class="flex items-center space-x-3 p-2 rounded-lg bg-gray-900/30 text-text-primary font-semibold cursor-pointer transition duration-150">
                <i data-lucide="user" class="icon w-5 h-5"></i>
                <span>Friends</span>
            </div>
            <div class="flex items-center space-x-3 p-2 rounded-lg text-text-secondary hover:bg-gray-900/30 font-semibold cursor-pointer transition duration-150">
                <i data-lucide="crown" class="icon w-5 h-5 text-yellow-500"></i>
                <span>Nitro</span>
            </div>
            <div class="flex items-center space-x-3 p-2 rounded-lg text-text-secondary hover:bg-gray-900/30 font-semibold cursor-pointer transition duration-150">
                <i data-lucide="store" class="icon w-5 h-5"></i>
                <span>Shop</span>
            </div>

            <!-- Direct Messages Section -->
            <div class="pt-4 pb-2">
                <h2 class="text-xs font-semibold uppercase text-text-secondary tracking-wide flex justify-between items-center px-2">
                    Direct Messages
                    <i data-lucide="plus" class="icon w-4 h-4 hover:text-text-primary cursor-pointer"></i>
                </h2>
                <h2 class="text-xs font-semibold uppercase text-text-secondary tracking-wide px-2 mt-1">Online — <span id="jumlahOnline">2</span></h2>
            </div>

            
            <div class="dmUserList dm-friend">
                <!-- // Direct messages will be populated here via JavaScript YEAH -->
            </div>

            
        </div>

        <!-- User Panel (Bottom) -->
        <div class="p-2 user-panel bg-black/30 flex items-center justify-between flex-shrink-0 relative">
            <div class="flex items-center space-x-2">
                <div class="w-8 h-8 rounded-full bg-green-500 flex items-center justify-center text-sm font-bold text-white relative">
                    <?= $_SESSION['logInUser']['username'][0] ?? '?' ?>
                    <span class="absolute right-0 bottom-0 w-3 h-3 bg-online-green rounded-full border-2 border-black/30"></span>
                </div>
                <div>
                    <p class="text-sm font-semibold leading-none"><?= $_SESSION['logInUser']['username'] ?? 'Log In' ?></p>
                    <p class="text-xs text-gray-400"><?= $_SESSION['logInUser']['status'] ?? 'Online' ?></p>
                </div>
            </div>
            <div class="flex space-x-2 text-text-secondary">
                <!-- DIBUNGKUS DENGAN SPAN SEBAGAI FIX UNTUK FIREFOX/SAFARI CLICK ISSUE -->
                <span><i data-lucide="mic" class="icon w-5 h-5 cursor-pointer hover:text-text-primary"></i></span>
                <span><i data-lucide="headphones" class="icon w-5 h-5 cursor-pointer hover:text-text-primary"></i></span>
                <span id="settingsBtn"><i data-lucide="settings" class="icon w-5 h-5 cursor-pointer hover:text-text-primary"></i></span>
            </div>
            <!-- Logout Popup -->
            <div id="logoutPopup" class="absolute bottom-12 right-2 z-[99] bg-gray-700/95 backdrop-blur-sm rounded-lg shadow-xl px-4 py-3 flex items-center space-x-3 border border-gray-600 w-40 transition-opacity duration-150" style="display:none; transform: translateY(-4px);">
                <i data-lucide="log-out" class="icon w-5 h-5 text-red-400"></i>
                <button id="logoutBtn" class="text-red-400 font-semibold text-sm hover:text-red-300">Logout</button>
            </div>
        </div>
    </div>

    <!-- 3. Main Content Area (Right Panel) -->
    <div id="mainContentPanel" class="main-content flex flex-col flex-auto h-full">
        <!-- Top Header for Main Content (Initial Friends List Header) -->
        <div id="mainHeader" class="flex items-center justify-between p-3 border-b border-black/20 shadow-lg flex-shrink-0">
            <!-- Default Content: Friends Header -->
            <div class="flex items-center space-x-4">
                <div class="flex items-center space-x-2">
                    <i data-lucide="user-check" class="icon w-5 h-5 text-text-secondary"></i>
                    <h1 class="text-lg font-semibold whitespace-nowrap">Friends</h1>
                </div>
                
                <div class="h-6 w-px bg-gray-700"></div>

                <div class="flex items-center space-x-2 text-sm">
                    <button class="p-1.5 rounded-lg font-medium bg-gray-900/30 cursor-pointer" id="all">All</button>
                    <button class="p-1.5 rounded-lg text-text-secondary hover:bg-gray-900/30 cursor-pointer" id="pending">Pending</button>
                    <button id="addFriendBtn" class="bg-online-green text-white font-medium px-3 py-1 rounded-full text-xs transition duration-200 hover:bg-green-700 whitespace-nowrap">
                        Add Friend
                    </button>
                </div>
            </div>
            
            <!-- Right Side: Search and Icons -->
            <div class="flex items-center space-x-4">
                <div class="relative">
                    <input type="text" placeholder="Search" class="w-36 bg-gray-900/40 text-sm text-text-primary placeholder-text-secondary rounded-md p-1.5 focus:outline-none focus:ring-1 focus:ring-accent-purple">
                    <i data-lucide="search" class="icon w-4 h-4 absolute right-2 top-1/2 -translate-y-1/2 text-text-secondary"></i>
                </div>
                <i data-lucide="message-square" class="icon w-6 h-6 text-text-secondary cursor-pointer hover:text-text-primary"></i>
                <i data-lucide="more-vertical" class="icon w-6 h-6 text-text-secondary cursor-pointer hover:text-text-primary"></i>
            </div>
        </div>

        <!-- Main Content List -->
        <div id="mainContentArea" class="flex-grow overflow-y-auto p-4" >
            <div id="main" class="dm-friend">
                <!-- Content will be replaced by Friend List or Chat Interface -->
            </div>
        </div>
    </div>

    <!-- ADD FRIEND MODAL STRUCTURE -->
    <div id="addFriendModal" class="fixed inset-0 z-[100] bg-black/70 backdrop-blur-sm hidden items-center justify-center">
        <!-- Modal Content -->
        <div class="bg-sidebar-dm w-full max-w-md rounded-lg shadow-2xl overflow-hidden transform transition-all duration-300 scale-95 opacity-0" id="addFriendModalContent">
            
            <!-- Header -->
            <div class="flex justify-between items-center p-4 border-b border-black/20">
                <h2 class="text-xl font-semibold text-text-primary">Add Friend</h2>
                <i data-lucide="x" class="icon w-6 h-6 text-text-secondary cursor-pointer hover:text-text-primary" id="closeAddFriendModalX"></i>
            </div>
            
            <!-- Body: Search Form -->
            <div class="p-4">
                <label for="friendSearch" class="block text-sm font-semibold text-text-secondary mb-2">Search by username or email</label>
                <div class="relative mb-4">
                    <input 
                        type="text" 
                        id="friendSearch" 
                        placeholder="Search for a user..." 
                        class="w-full bg-gray-900/40 text-base text-text-primary placeholder-text-secondary rounded-lg p-3 pr-10 focus:outline-none focus:ring-2 focus:ring-accent-purple"
                        onkeyup="searchFriends($(this).val())"
                    >
                    <i data-lucide="search" class="icon w-5 h-5 absolute right-3 top-1/2 -translate-y-1/2 text-text-secondary"></i>
                </div>
                
                <!-- Search Results Container -->
                <div id="friendSearchResults" class="space-y-3 max-h-64 overflow-y-auto">
                    <!-- Results will be dynamically generated by searchFriends -->
                </div>
            </div>

            <!-- Footer -->
            <div class="flex justify-end p-4 bg-black/10">
                <button id="closeAddFriendModalBtn" class="bg-gray-700 hover:bg-gray-600 text-text-primary font-medium px-6 py-2 rounded-lg transition">Close</button>
            </div>
        </div>
    </div>
    <!-- END ADD FRIEND MODAL STRUCTURE -->


    <!-- Script to initialize Lucide icons -->
    <script>
        let friends = [];
        let friendsPage = [];
        let currentChatFriendId = null; // Menyimpan ID teman yang sedang chatting
        lucide.createIcons();

        // =========================================================
        // === CHAT/MESSAGE RENDER FUNCTIONS =======================
        // =========================================================

        /**
         * Merender tampilan Chat (Header, Area Pesan, Input Footer)
         * @param {number} friendId ID teman yang akan diajak chat
         */
        function enterChat(friendId) {
            // 1. Dapatkan detail teman
            const friend = friends.find(f => f.friend_id == friendId);
            currentChatFriendId = friendId;
            
            if (!friend) {
                console.error("Friend not found for ID:", friendId);
                return;
            }

            // 2. Buat Header Chat
            const chatHeaderHTML = `
                <div class="flex items-center space-x-4">
                    <div class="flex items-center space-x-2">
                        <!-- Tombol Kembali ke Friends List -->
                        <i data-lucide="arrow-left" class="icon w-5 h-5 text-text-secondary cursor-pointer hover:text-text-primary mr-2" onclick="showFriendsList()"></i>
                        
                        <div class="w-8 h-8 rounded-full bg-blue-500 flex items-center justify-center text-sm font-bold text-white relative flex-shrink-0">
                            ${friend.username.charAt(0).toUpperCase()}
                            <span class="absolute right-0 bottom-0 w-3 h-3 ${friend.status === 'online' ? 'bg-online-green' : 'bg-gray-500'} rounded-full border-2 border-main-content"></span>
                        </div>
                        <h1 class="text-lg font-semibold whitespace-nowrap">${friend.username}</h1>
                    </div>
                </div>
                
                <div class="flex items-center space-x-4 text-text-secondary">
                    <i data-lucide="phone" class="icon w-5 h-5 cursor-pointer hover:text-text-primary"></i>
                    <i data-lucide="video" class="icon w-5 h-5 cursor-pointer hover:text-text-primary"></i>
                    <i data-lucide="user-plus" class="icon w-5 h-5 cursor-pointer hover:text-text-primary"></i>
                    <div class="h-6 w-px bg-gray-700"></div>
                    <i data-lucide="search" class="icon w-5 h-5 cursor-pointer hover:text-text-primary"></i>
                    <i data-lucide="more-vertical" class="icon w-5 h-5 cursor-pointer hover:text-text-primary"></i>
                </div>
            `;

            // 3. Buat Chat Footer (Input Area)
            const chatFooterHTML = `
                <div id="chatFooter" class="p-4 flex-shrink-0">
                    <div class="relative flex items-center bg-gray-700/50 rounded-lg p-2">
                        <i data-lucide="plus-circle" class="icon w-6 h-6 text-text-secondary cursor-pointer hover:text-text-primary mr-2"></i>
                        <input type="text" id="messageInput" placeholder="Message @${friend.username}" class="flex-grow bg-transparent text-text-primary placeholder-text-secondary focus:outline-none p-1.5" onkeydown="handleMessageInput(event, ${friendId})">
                        <i data-lucide="send" class="icon w-6 h-6 text-text-secondary cursor-pointer hover:text-text-primary ml-2" onclick="sendMessage(${friendId})"></i>
                    </div>
                </div>
            `;
            
            // 4. Ganti seluruh kontainer utama dengan Area Pesan dan Footer yang baru
            $("#mainContentPanel").html(`
                <div id="mainHeaderContainer" class="flex-shrink-0"></div>
                <!-- Area Pesan yang akan di-scroll -->
                <div id="chatMessages" class="main-content flex-grow overflow-y-auto px-4 pb-4 flex flex-col justify-end">
                    <!-- Messages will be loaded here via AJAX -->
                    <div class="flex justify-center text-sm text-gray-400 p-4">Loading messages...</div>
                </div>
                ${chatFooterHTML}
            `);

            // Pindahkan header yang sudah dibuat ke dalam kontainer header baru
            // Kami mengganti konten header di sini karena elemen #mainHeader sekarang berada di DOM lagi
            $("#mainHeaderContainer").html(`<div id="mainHeader" class="flex items-center justify-between p-3 border-b border-black/20 shadow-lg flex-shrink-0"></div>`);
            $("#mainHeader").html(chatHeaderHTML);


            // 5. Panggil AJAX untuk memuat pesan
            loadMessages(friendId);

            lucide.createIcons();
        }

        /**
         * Memuat pesan dari server melalui AJAX.
         * @param {number} friendId ID teman.
         */
        function loadMessages(friendId) {
            $.ajax({
                type: "post",
                url: "getMessages.php", // File PHP untuk mengambil pesan
                data: { friendId: friendId },
                dataType: "json",
                success: function (response) {
                    if (response.success && response.messages) {
                        renderMessages(response.messages);
                    } else {
                        $("#chatMessages").html('<div class="flex justify-center text-sm text-gray-400 p-4">Start chatting! No messages found.</div>');
                        console.error("Error loading messages:", response.message);
                    }
                },
                error: function (xhr, status, error) {
                    $("#chatMessages").html('<div class="flex justify-center text-sm text-red-400 p-4">AJAX Error: Could not load messages. (Check getMessages.php)</div>');
                    console.error("AJAX error calling getMessages.php:", status, error);
                }
            });
        }


        /**
         * Merender daftar pesan di area chat.
         * @param {Array<Object>} messages Daftar pesan. Format: { id, text, isSelf, timestamp }
         */
        function renderMessages(messages) {
            let messagesHTML = '';
            // Anda mungkin perlu menyesuaikan logic isSelf berdasarkan ID pengguna saat ini
            const currentUserId = <?= $_SESSION['logInUser']['id'] ?? 'null' ?>; 
            
            messages.forEach(msg => {
                // Asumsi msg memiliki property 'sender_id'
                const isSelf = msg.sender_id == currentUserId; 
                
                const alignment = isSelf ? 'justify-end' : 'justify-start';
                const bubbleClass = isSelf ? 'chat-bubble-self' : 'chat-bubble-friend';
                const timestampAlignment = isSelf ? 'self-end text-right' : 'self-start text-left';
                
                // Konversi timestamp (jika dari database)
                const displayTime = msg.timestamp || new Date().toLocaleTimeString('en-US', { hour: '2-digit', minute: '2-digit' });

                messagesHTML += `
                <div class="flex ${alignment} my-1">
                    <div class="p-2 ${bubbleClass} rounded-lg text-sm">${msg.text}</div>
                </div>
                <div class="flex ${alignment} text-xs text-gray-400 mb-2 ${timestampAlignment}">
                    ${displayTime}
                </div>
                `;
            });
            $("#chatMessages").html(messagesHTML);

            // Scroll ke bawah setelah rendering
            const messageArea = document.getElementById('chatMessages');
            if(messageArea) {
                messageArea.scrollTop = messageArea.scrollHeight;
            }
        }

        /**
         * Menangani pengiriman pesan.
         * @param {number} friendId ID teman tujuan.
         */
        function sendMessage(friendId) {
            const input = $("#messageInput");
            const messageText = input.val().trim();

            if (messageText === "") return;

            // 1. Simulasikan pengiriman pesan (Tambahkan ke UI)
            const newMessage = {
                id: Date.now(),
                text: messageText,
                sender_id: <?= $_SESSION['logInUser']['id'] ?? 'null' ?>, // ID Pengguna Saat Ini
                timestamp: new Date().toLocaleTimeString('en-US', { hour: '2-digit', minute: '2-digit' })
            };
            
            // 2. Kosongkan input
            input.val("");
            
            // 3. Panggil AJAX untuk menyimpan pesan ke database
            $.ajax({
                type: "post",
                url: "saveMessage.php", // File PHP untuk menyimpan pesan
                data: { friendId: friendId, message: messageText },
                dataType: "json",
                success: function(response) {
                    if (response.success) {
                        console.log("Message sent successfully!");
                        // Muat ulang pesan untuk melihat pesan yang baru (dan pesan balasan jika ada)
                        loadMessages(friendId); 
                    } else {
                        console.error("Error saving message:", response.message);
                    }
                },
                error: function(xhr, status, error) {
                    console.error("AJAX error calling saveMessage.php:", status, error);
                    // Tambahkan pesan error di UI jika perlu
                }
            });
        }
        
        /**
         * Mengaktifkan pengiriman pesan saat tombol Enter ditekan.
         */
        function handleMessageInput(event, friendId) {
            if (event.key === 'Enter') {
                sendMessage(friendId);
                event.preventDefault(); // Mencegah baris baru di input
            }
        }


        /**
         * Mengembalikan tampilan ke daftar teman.
         */
        function showFriendsList() {
            // 1. Mengembalikan header ke tampilan Friends
            const friendsHeader = `
                <!-- Left Side: Friends Header & Tabs -->
                <div class="flex items-center space-x-4">
                    <div class="flex items-center space-x-2">
                        <i data-lucide="user-check" class="icon w-5 h-5 text-text-secondary"></i>
                        <h1 class="text-lg font-semibold whitespace-nowrap">Friends</h1>
                    </div>
                    
                    <div class="h-6 w-px bg-gray-700"></div>

                    <div class="flex items-center space-x-2 text-sm">
                        <button class="p-1.5 rounded-lg font-medium bg-gray-900/30 cursor-pointer" id="all">All</button>
                        <button class="p-1.5 rounded-lg text-text-secondary hover:bg-gray-900/30 cursor-pointer" id="pending">Pending</button>
                        <button id="addFriendBtn" class="bg-online-green text-white font-medium px-3 py-1 rounded-full text-xs transition duration-200 hover:bg-green-700 whitespace-nowrap">
                            Add Friend
                        </button>
                    </div>
                </div>
                
                <!-- Right Side: Search and Icons -->
                <div class="flex items-center space-x-4">
                    <div class="relative">
                        <input type="text" placeholder="Search" class="w-36 bg-gray-900/40 text-sm text-text-primary placeholder-text-secondary rounded-md p-1.5 focus:outline-none focus:ring-1 focus:ring-accent-purple">
                        <i data-lucide="search" class="icon w-4 h-4 absolute right-2 top-1/2 -translate-y-1/2 text-text-secondary"></i>
                    </div>
                    <i data-lucide="message-square" class="icon w-6 h-6 text-text-secondary cursor-pointer hover:text-text-primary"></i>
                    <i data-lucide="more-vertical" class="icon w-6 h-6 text-text-secondary cursor-pointer hover:text-text-primary"></i>
                </div>
            `;
            

            // 2. Mengganti konten utama kembali ke daftar teman
            $("#mainContentPanel").html(`
                <div id="mainHeader" class="flex items-center justify-between p-3 border-b border-black/20 shadow-lg flex-shrink-0"></div>
                <div id="mainContentArea" class="flex-grow overflow-y-auto p-4" >
                    <div id="main" class="dm-friend"></div>
                </div>
            `);
            $("#mainHeader").html(friendsHeader).removeClass("justify-start").addClass("justify-between");


            // 3. Memuat ulang daftar teman dan memastikan tombol 'All' aktif
            getFriends('accepted', false);
            // Re-select elements because they were dynamically replaced
            $("#mainHeader #all").addClass("bg-gray-900/30 font-medium text-white").removeClass("text-text-secondary hover:bg-gray-900/30");
            $("#mainHeader #pending").removeClass("bg-gray-900/30 font-medium text-white").addClass("text-text-secondary hover:bg-gray-900/30");


            lucide.createIcons();
            // Memastikan event handler untuk tombol Add Friend diregister ulang
            $("#mainHeader").off('click').on('click', "#addFriendBtn", showAddFriendModal);
            
            currentChatFriendId = null;
        }

        // =========================================================
        // === FRIEND MODAL FUNCTIONS ==============================
        // =========================================================

        function searchFriends(query) {
            console.log("Searching for:", query);

            $.ajax({
                type: "post",
                url: "getUser.php",
                data: { search : query },
                dataType: "json",
                success: function (response) {
                    console.log("keluar dari php");
                    if (response.success) {
                        console.log("Search results:", response.users);
                        // Render hasil pencarian
                        let userList = '';
                        response.users.forEach(user => {
                            // Pemberian warna random untuk avatar background
                            const randomColorClass = ['bg-red-500', 'bg-blue-500', 'bg-purple-500', 'bg-green-500'][Math.floor(Math.random() * 4)];

                        userList += `
                            <div class="flex items-center justify-between p-2 hover:bg-black/20 rounded-lg transition">
                            <div class="flex items-center space-x-3">
                            <div class="w-10 h-10 rounded-full ${randomColorClass} flex items-center justify-center text-sm font-bold text-white">${user.username.charAt(0).toUpperCase()}</div>
                            <div>
                            <p class="font-semibold leading-none">${user.username}</p>
                            <p class="text-xs text-gray-400">${user.email}</p>
                            </div>
                            </div>
                            <!-- Tombol Add Friend dikaitkan ke fungsi addFriend(ID) -->
                            <button onclick="addFriend(${user.id})" class="bg-accent-purple hover:bg-indigo-600 text-white font-medium px-4 py-1.5 rounded transition text-sm">Add Friend</button>
                            </div>
                            
                            `;

                        });
                        $("#friendSearchResults").html(userList);


                    }
                },
                error: function(xhr, status, error){
                    console.error("AJAX error calling getUser.php ->", status, error);
                    $("#friendSearchResults").html(`<div class="text-sm text-red-400 p-2">Error searching users. Check getUser.php.</div>`);
                }
                });


        }
        function addFriend(friendId) {
            
            $.ajax({
                type: "post",
                url: "addFriend.php",
                data: { id: friendId },
                dataType: "json",
                success: function (response) {
                    
                    if (response.success) {
                        console.log("Friend request sent successfully to ID:", friendId);
                        hideAddFriendModal();
                        // Setelah add friend, muat ulang daftar pending untuk melihat permintaan yang baru dikirim
                        getFriends('pending', true);
                    } else {
                        console.error("Failed to send friend request:", response.message);
                    }
                },
                error: function(xhr, status, error){
                    console.error("AJAX error calling addFriend.php ->", status, error);
                }
            });

        }

        // =========================================================
        // === MODAL CONTROL FUNCTIONS =============================
        // =========================================================
        
        function showAddFriendModal() {
            const modal = $("#addFriendModal");
            const content = $("#addFriendModalContent");
            modal.removeClass('hidden').addClass('flex');
            // Menambahkan efek transisi
            setTimeout(() => {
                content.removeClass('scale-95 opacity-0').addClass('scale-100 opacity-100');
            }, 10);
            lucide.createIcons();
            // Fokuskan ke input pencarian
            $("#friendSearch").focus();
            searchFriends("");
        }

        function hideAddFriendModal() {
            const modal = $("#addFriendModal");
            const content = $("#addFriendModalContent");
            // Menghapus efek transisi
            content.removeClass('scale-100 opacity-100').addClass('scale-95 opacity-0');
            setTimeout(() => {
                modal.removeClass('flex').addClass('hidden');
                // Kosongkan input pencarian
                $("#friendSearch").val("");
                // Kosongkan hasil pencarian
                $("#friendSearchResults").empty(); 
            }, 300); // Sesuaikan dengan durasi transisi CSS
        }


        $(document).ready(function() {
            // Initial load: show accepted friends via AJAX
            getFriends('accepted', false);

            // =========================================================
            // === EVENT HANDLERS ======================================
            // =========================================================

            // --- Friends Tabs (Using Delegation as Header is replaced) ---
            $("#mainContentPanel").on("click", "#all", function(){
                // Cleanup kelas yang tidak diperlukan
                $("#mainHeader #pending").removeClass("bg-gray-900/30 font-medium text-white").addClass("text-text-secondary hover:bg-gray-900/30");
                $(this).addClass("bg-gray-900/30 font-medium text-white").removeClass("text-text-secondary hover:bg-gray-900/30");
                getFriends('accepted', false); 
            });

            $("#mainContentPanel").on("click", "#pending", function(){
                // Cleanup kelas yang tidak diperlukan
                $("#mainHeader #all").removeClass("bg-gray-900/30 font-medium text-white").addClass("text-text-secondary hover:bg-gray-900/30");
                $(this).addClass("bg-gray-900/30 font-medium text-white").removeClass("text-text-secondary hover:bg-gray-900/30");
                getFriends('pending', true);
            });

            // --- Friend List Clicks ---
            // Menggunakan event delegation pada elemen statis yang menampung daftar teman
            $(".dmUserList").on("click", ".friend-item", function(){
                console.log("Clicked friend item -> id : " + $(this).data("friend-id"));
                enterChat( $(this).data("friend-id"));
            });
            
            // Event delegation untuk item teman di Main Content (untuk chat)
            $("#mainContentPanel").on("click", ".friend-item", function(){
                console.log("Clicked friend item (main) -> id : " + $(this).data("friend-id"));
                enterChat( $(this).data("friend-id"));
            });


            $("#mainContentPanel").on("click", ".acc", function(){
                let friendId = $(this).data("friend-id");
                updateFriendStatus(friendId, 'accepted');
            });

            $("#mainContentPanel").on("click", ".dec", function(){
                let friendId = $(this).data("friend-id");
                updateFriendStatus(friendId, 'blocked');
            });

            // --- Logout Popup Handlers ---
            $("#settingsBtn").on("click", function(e){
                console.log("Settings button clicked! Toggling logout popup."); // DEBUG LOG
                e.stopPropagation();
                $("#logoutPopup").toggle(); 
                lucide.createIcons();
            });
            
            // Hide popup when clicking outside the settings button/popup area but within the sidebar-dm
            $(".sidebar-dm").on("click", function(e){
                if (!$(e.target).closest("#logoutPopup, #settingsBtn").length) {
                    $("#logoutPopup").hide();
                }
            });


            $("#logoutBtn").on("click", function(){
                console.log("Logout button clicked. Redirecting to login.php...");
                window.location.href = "login.php"; // Harusnya ke logout.php
            });

            // --- Add Friend Modal Handlers ---
            // Using delegation for addFriendBtn because the header is rebuilt
            $("#mainContentPanel").on("click", "#addFriendBtn", showAddFriendModal);
            $("#closeAddFriendModalX").on("click", hideAddFriendModal);
            $("#closeAddFriendModalBtn").on("click", hideAddFriendModal);
            
            // Tutup modal jika overlay diklik (tapi bukan kontennya)
            $("#addFriendModal").on("click", function(e) {
                if (e.target.id === 'addFriendModal') {
                    hideAddFriendModal();
                }
            });

            // Tutup modal dengan tombol ESC
            $(document).on('keydown', function(e) {
                if (e.key === 'Escape' && $("#addFriendModal").hasClass('flex')) {
                    hideAddFriendModal();
                }
            });
        });


        // =========================================================
        // === CORE AJAX/RENDER FUNCTIONS ==========================
        // =========================================================

        function updateFriendStatus(friendId, newStatus){
            console.log('updateFriendStatus called with', { friendId, newStatus });
            
            // Perhatian: Fungsi AJAX ini memerlukan file PHP yang sesuai
            //reload left bar
            $.ajax({
                type: "post",
                url: "updateFriendStatus.php",
                data: { id: friendId, status: newStatus },
                dataType: "json",
                success: function (response) {
                    console.log('updateFriendStatus response', response);
                    if (response.success) {
                        console.log("Friend status updated successfully");
                        // Setelah status diupdate, ambil ulang daftar teman yang sudah di accept (untuk sidebar kiri)
                        $.ajax({
                            type: "post",
                            url: "getFriend.php",
                            data: { status: 'accepted', onlyPage: false },
                            dataType: "json",
                            success: function (response) {
                                if (response.success) {
                                    friends = response.friends || []; 
                                    setLeftSideBar();
                                } else {
                                    friends = []; 
                                    console.error("Error fetching friends (AJAX):", response.message);
                                }
                            },
                            error: function (xhr, status, error) {
                                console.error("AJAX error: Pastikan getFriend.php ada.", status, error);
                            }
                        });
                        // Dan refresh list di panel utama (misalnya kembali ke 'pending')
                        getFriends('pending', true); 
                    } else {
                        console.error("Error updating friend status:", response.message);
                    }
                },
                error: function (xhr, status, error) {
                    console.error("AJAX error while updating friend status:", status, error);
                }
            });
        }


        function setFriendsList(isPending){
            // Fungsi ini merender daftar teman di Panel Utama (Main Content)
            let friendPageData = "";
            let onlineCount = 0;
            const currentList = isPending ? friendsPage : friendsPage.filter(f => f.status !== 'pending' && f.status !== 'blocked');


            if (isPending) {
                // Tampilan Pending (Permintaan Pertemanan)
                console.log("Rendering pending friends:", currentList);
                friendPageData += `<h2 class="text-xs font-semibold uppercase text-text-secondary tracking-wide mb-2">Pending — ${currentList.length}</h2>`;
                currentList.forEach(friend => {
                    friendPageData += `
                    <div class="flex items-center justify-between bg-gray-700 rounded-lg px-6 py-5 mb-4 border-t border-black/10" >
                        <div class="flex items-center gap-4 min-w-0">
                            <div class="w-12 h-12 rounded-full bg-gray-600 flex items-center justify-center text-lg font-bold text-white flex-shrink-0">
                                ${friend.username.charAt(0).toUpperCase()}
                            </div>
                            <div class="min-w-0">
                                <p class="font-semibold text-lg">${friend.username}</p>
                                <p class="text-sm text-gray-300">${friend.email || ''}</p>
                                <p class="text-xs text-gray-400">Sent ${friend.created_at || ''}</p>
                            </div>
                        </div>
                        <div class="flex items-center gap-2">
                            <button class="bg-green-500 hover:bg-green-600 text-white px-4 py-1 rounded font-semibold transition acc" data-friend-id ="${friend.user_id}" >Accept</button>
                            <button class="bg-red-500 hover:bg-red-600 text-white px-4 py-1 rounded font-semibold transition dec" data-friend-id ="${friend.user_id}" >Decline</button>
                        </div>
                    </div>
                    `;
                });
            } else {
                // Tampilan All (Teman Diterima)
                onlineCount = currentList.filter(friend => friend.status === 'online').length;
                friendPageData += `<h2 class="text-xs font-semibold uppercase text-text-secondary tracking-wide mb-2">Online — ${onlineCount}</h2>`;

                console.log("Rendering accepted friends:", currentList);
                currentList.forEach(friend => {
                    const statusDotClass = friend.status === 'online'? 'bg-online-green' : 'bg-gray-500';
                    const statusTextClass = friend.status === 'online'? 'text-online-green' : 'text-gray-400';

                    friendPageData += `
                    <div class="flex items-center justify-between p-3 rounded-lg hover:bg-black/10 transition duration-150 border-t border-black/10">
                        <div class="flex items-center space-x-3">
                            <div class="w-10 h-10 rounded-full bg-blue-500 flex items-center justify-center text-base font-bold text-white relative flex-shrink-0">
                                ${friend.username.charAt(0).toUpperCase()}
                                <span class="absolute right-0 bottom-0 w-3 h-3 ${statusDotClass} rounded-full border-2 border-main-content"></span>
                            </div>
                            <div>
                                <p class="font-semibold leading-none">${friend.username}</p>
                                <p class="text-sm ${statusTextClass}">${friend.status}</p>
                            </div>
                        </div>
                        <div class="flex space-x-3 text-text-secondary">
                            <div class="flex items-center justify-center w-8 h-8 rounded-full bg-black/20 hover:bg-black/40 cursor-pointer transition duration-100 ">
                                <i data-lucide="phone" class="icon w-5 h-5"></i>
                            </div>
                            <div class="flex items-center justify-center w-8 h-8 rounded-full bg-black/20 hover:bg-black/40 cursor-pointer transition duration-100 friend-item" data-friend-id ="${friend.friend_id}">
                                <i data-lucide="message-square" class="icon w-5 h-5"></i>
                            </div>
                            <div class="flex items-center justify-center w-8 h-8 rounded-full bg-black/20 hover:bg-black/40 cursor-pointer transition duration-100">
                                <i data-lucide="more-vertical" class="icon w-5 h-5"></i>
                            </div>
                        </div>
                    </div>
                    `;
                });
            }

            // set friend list yang ditengah
            if (currentList.length === 0 && !isPending) {
                // Tampilan Wumpus jika tidak ada teman
                $("#main").html(`
                    <div class="flex flex-col items-center justify-center h-full pt-24">
                        <div class="rounded-full bg-gray-800 flex items-center justify-center" style="width:120px;height:120px;">
                            <svg width="64" height="64" fill="none" viewBox="0 0 64 64"><circle cx="32" cy="32" r="32" fill="#23272A"/><circle cx="24" cy="28" r="6" fill="#36393F"/><circle cx="40" cy="28" r="6" fill="#36393F"/><ellipse cx="32" cy="44" rx="12" ry="6" fill="#36393F"/></svg>
                        </div>
                        <h2 class="mt-8 text-lg font-semibold text-text-primary text-center">No one's around to play with Wumpus.</h2>
                        <p class="mt-2 text-sm text-gray-400 text-center">When you have friends to talk to, they'll appear here.</p>
                    </div>
                `);
            } else {
                $("#main").html(friendPageData);
            }
            lucide.createIcons();

        }


        function setLeftSideBar(){
            // Fungsi ini merender daftar teman di Sidebar Kiri (Direct Messages)
            const acceptedFriends = friends.filter(friend => friend.status !== 'blocked' && friend.status !== 'pending');

            $(".dmUserList").html("");
            let data = `
            <!-- Discord Official (Contoh) -->
            <div class="dm-item flex items-center space-x-3 p-2 rounded-lg text-text-secondary hover:bg-gray-900/30 cursor-pointer transition duration-150 relative">
                <div class="w-8 h-8 rounded-full bg-purple-500 flex items-center justify-center text-sm font-bold text-white relative">
                    D
                <span class="absolute right-0 bottom-0 w-3 h-3 bg-gray-500 rounded-full border-2 border-sidebar-dm"></span>
                </div>
                <span class="text-text-primary font-bold">Discord <span class="text-xs text-green-400">OFFICIAL</span></span>
            </div>
            `;

            acceptedFriends.forEach(friend => {
                const statusDotClass = friend.status === 'online'? 'bg-online-green' : 'bg-gray-500';
                data += `
                <div class="dm-item flex items-center space-x-3 p-2 rounded-lg text-text-secondary hover:bg-gray-900/30 cursor-pointer transition duration-150 relative friend-item" data-friend-id ="${friend.friend_id}">
                <div class="w-8 h-8 rounded-full bg-blue-500 flex items-center justify-center text-sm font-bold text-white relative"> 
                    ${friend.username.charAt(0).toUpperCase()}
                    <span class="absolute right-0 bottom-0 w-3 h-3 ${statusDotClass} rounded-full border-2 border-sidebar-dm"></span>
                </div>
                <span class="text-text-primary">${friend.username}</span>
                </div>
                `;
            });

            //ini friend list yang di kiri
            $(".dmUserList").html(data);
            //set jumlah online
            $("#jumlahOnline").html(acceptedFriends.filter(friend => friend.status === 'online').length);

            lucide.createIcons();
        }


        function getFriends(status, onlyPage){
            // Fungsi AJAX untuk mengambil data dari server
            $.ajax({
                type: "post",
                url: "getFriend.php",
                data: { status: status, onlyPage: onlyPage },
                dataType: "json",
                success: function (response) {
                    if (response.success) {
                        friendsPage = response.friends || [];
                        if (!onlyPage) {
                            friends = response.friends || []; 
                        }
                    } else {
                        if (!onlyPage) { friends = []; }
                        friendsPage = [];
                        console.error("Error fetching friends (AJAX):", response.message);
                    }
                    
                    setFriendsList(status === 'pending');
                    setLeftSideBar();
                },
                error: function (xhr, status, error) {
                    // Masalah koneksi ke getFriend.php
                    if (!onlyPage) { friends = []; }
                    friendsPage = [];
                    setFriendsList(status === 'pending');
                    setLeftSideBar();
                    console.error("AJAX error: Pastikan getFriend.php ada dan server PHP berjalan.", status, error);
                }
            });
        }

    </script>
</body>
</html>
