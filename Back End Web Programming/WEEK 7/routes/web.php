<?php

use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider and all of them will
| be assigned to the "web" middleware group. Make something great!
|
*/

// Mengarahkan halaman utama ke /Minecraft
Route::get('/', function () {
    return redirect('/Minecraft');
});

// Rute untuk halaman utama Minecraft (menampilkan view 'index')
Route::get('/Minecraft', function () {
    return view('index');
})->name('minecraft');

// --- RUTE AUTENTIKASI ---

// Menampilkan halaman login
Route::get('/Login', function () {
    return view('login');
})->name('login');

// Menangani data dari form login
Route::post('/Login', function () {
    // Di sini akan ada logika validasi.
    // Untuk saat ini, kita kembalikan ke login dengan pesan error (sesuai aturan)
    return redirect()->back()->withErrors(['email' => 'GAGAL LOGIN']);
})->name('login.post');

// Menampilkan halaman register
Route::get('/Register', function () {
    return view('register');
})->name('register');

// Menangani data dari form register
Route::post('/Register', function () {
    // Di sini akan ada logika validasi.
    // Untuk saat ini, kita kembalikan saja.
    return redirect()->route('login')->with('success', 'Registration successful! Please login.');
})->name('register.post');


// --- RUTE HALAMAN LAIN ---

// Rute untuk halaman Choose Game
Route::get('/Choose-game', function () {
    return view('choose-game');
})->name('choose-game');

// Rute untuk halaman Cart
Route::get('/Cart', function () {
    return view('cart');
})->name('cart');

// Rute untuk halaman Library
Route::get('/Library', function () {
    return view('library');
})->name('library');

// Rute untuk link Header (placeholder)
Route::get('/Shop', function () {
    return view('shop');
})->name('shop');

Route::get('/News', function () {
    return view('news');
})->name('news');

Route::get('/Support', function () {
    return view('support');
})->name('support');