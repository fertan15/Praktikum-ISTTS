<?php

use Illuminate\Support\Facades\Route;

Route::get('/', function () {
    return redirect('/Minecraft');
});

Route::get('/Minecraft', function () {
    return view('index');
});
Route::get('/Shop', function () {
    return view('shop');
});
Route::get('/Support', function () {
    return view('support');
});

Route::get('/News', function () {
    return view('news');
});