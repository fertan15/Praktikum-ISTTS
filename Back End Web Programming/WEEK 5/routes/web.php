<?php

use Illuminate\Support\Facades\Route;



Route::get('/Silksong', function () {
    return view('index');
});

//default kalo misal nya yang diakses selain silksong -> ama pake session flash 
Route::fallback(function () {
    return redirect('/Silksong')->with('error', 'Halaman tidak ditemukan, dialihkan ke beranda.');
});


