<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <style>
        @hasSection('styles')
            @yield('styles')
        @endif

    </style>
</head>
<body>
    @include('component.header')

    <main class="flex-grow">
        @yield('content')
    </main>

    @include('component.footer')
</body>
</html>     



