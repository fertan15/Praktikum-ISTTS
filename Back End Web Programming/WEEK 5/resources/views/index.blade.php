<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.css">

    <style>
        .video-background {
            /* position: fixed; */
            top: 0;
            left: 0;
            width: 100vw;
            height: 100vh;
            z-index: -1;
            overflow: hidden;
        }
        
        .video-background iframe {
            pointer-events: none; /* Prevent clicks */
            /* position: absolute; */
            top: 50%;
            left: 50%;
            width: 100vw;
            height: 56.25vw; /* 16:9 ratio */
            min-height: 100vh;
            min-width: 177.77vh; /* 9/16 * 100vh */
            /* transform: translate(-50%, -50%); */
            border: none; /* Remove border */
        }

    

        .logo {
            transition: color 0.7s, text-shadow 0.7s;
            padding: 5px 10px;
            border-radius: 8px;
        }

        .logo-biru:hover {
            color: rgb(0, 123, 255);
            text-shadow: 0 0 10px rgba(0, 123, 255, 0.7);
        }

        .logo-merah:hover {
            color: #ff5733;
            text-shadow: 0 0 10px #ff5733;
        }
    </style>
</head>
<body>
    <!-- all content -->
    <div class="fluid-container allContent pb-0 mb-0" style="overflow: hidden; background-color: black; margin-bottom:0; padding-bottom:0;">
        @if(session('error'))
            <div class="alert alert-danger mx-auto" style="width: 100vw; text-align: center; background-color: red; color:white;" role="alert">
                {{ session('error') }}
            </div>
        @endif

        <!-- 1st page -->
         <div class="fluid-container" >
             <div class="fluid-container video-background" style="height: 100vh; width: 100vw; overflow: hidden;">
                <iframe width= 100% height= 100% src="https://www.youtube.com/embed/KIKcHuEqPWc?autoplay=1&mute=1&loop=1&playlist=KIKcHuEqPWc&controls=0&showinfo=0&rel=0&iv_load_policy=3&modestbranding=1&enablejsapi=1" frameborder="0" allow="autoplay;" ></iframe>
                <!-- content nya 1st page  -->
                <div class="text-center text-white" style="position: absolute; top: 50%; left: 50%; transform: translate(-50%, -50%);">
                    <h1 class="display-1 fw-bold">Hollow Knight</h1>
                    <h3 class="display-4 fw-light mb-4">Silksong</h3>
                    <div class="d-flex justify-content-center gap-4 fs-1">
                        <i class="bi bi-twitter-x logo logo-biru"></i>
                        <i class="bi bi-youtube logo logo-merah"></i>
                        <i class="bi bi-facebook logo logo-biru"></i>
                        <i class="bi bi-steam logo logo-biru"></i>
                    </div>
    
                </div>
             </div>
         </div>

         <!-- second page and strusnya yeah -->
         <div class="bg-black mb-5 pb-5">
    
            <div class="fluid-container text-center text-white" style=" overflow: hidden; padding-left: 10%; padding-right: 10%;">
                <h1 class="text-center mt-5 mb-4 pb-4">Ascend to the Peak of a Haunted Kingdom</h1>
                    <div>
                        <!-- 1st section -->
                        <div class="row mt-5 gap-5 pb-4">
    
                            <!-- gambar kiri -->
                            <div class="col">
                                <img src="{{asset('assets/screen_small_03.webp')}}" alt="ss_03" width="100%">
                            </div>
                            <!-- tulisan -->
                            <div class="col" style="text-align:left;">
                                <h2>Captured and Taken to a Distant Land</h2><br>
                                <p>The lethal hunter Hornet finds herself alone in a vast, unfamiliar kingdom. <br><br>
                                She must battle foes, seek out allies, and solve mysteries as she ascends on a deadly pilgrimage to the kingdom’s peak. <br><br>
                                Bound by her lineage and guided by echoes of her past, Hornet will adventure through mossy grottos, coral forests and shining citadels to unravel a deadly thread that threatens this strange new land.<br><br>
                                </p>
                            </div>
                        </div>

                        <!-- 2st section -->
                        <div class="row mt-5 gap-5 pb-4">

                            <!-- tulisan -->
                            <div class="col" style="text-align:left;">
                                <h2>Lethal Acrobatic Action</h2><br>
                                <p>Hornet must master a whole new suite of powerful moves to survive. She'll unleash devastating attacks, learn incredible silken abilities, and craft deadly tools in order to overcome the kingdom's challenges. <br><br>
                                    Over 200 ferocious foes stand between Hornet and the shining citadel crowning the kingdom. Beasts and hunters, assassins and kings, monsters and knights - Hornet must face them all with bravery and skill! <br><br>
                                </p>
                            </div>

                            <!-- gambar -->
                            <div class="col">
                                <img src="{{asset('assets/screen_small_02.webp')}}" alt="ss_02" width="100%">
                            </div>

                        </div>

                        <!-- 3st section -->
                        <div class="row mt-5 gap-5 pb-4 mb-5">
    
                            <!-- gambar kiri -->
                            <div class="col">
                                <img src="{{asset('assets/screen_small_01.webp')}}" alt="ss_01" width="100%">
                            </div>
                            <!-- tulisan -->
                            <div class="col" style="text-align:left;">
                                <h2>Beauty and Wonder in a Haunted World</h2><br>
                                <p>The vast interconnected world of Hollow Knight: Silksong is brought vividly to life in a traditional, hand-crafted, 2D style. Gilded cities, lakes of fire, and misted moors are illustrated in exquisite detail, all accompanied by a vibrant orchestral score. <br><br>
                                    In her search for the truth behind her capture, Hornet will befriend surprising strangers, discover shocking secrets and solve ancient mysteries in a haunted kingdom full of wonders. <br><br>
                                </p>
                            </div>
                        </div>



                    </div>




            </div>

            <!-- buat link youtube -->
             <div class="d-flex justify-content-center pd-4 mb-4">
                <iframe width="1120" height="630" src="https://www.youtube.com/embed/6XGeJwsUP9c?si=I1uJBADyZ_-9idkA" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" referrerpolicy="strict-origin-when-cross-origin" allowfullscreen></iframe>
             </div>
            
             <!-- footer -->
            <div>
                <!-- bagian atasnya -->
                <div class="d-flex justify-content-between m-4 p-4 text-white">
                    <!-- bagian kiri -->
                    <div>
                        <h2 style=" margin-bottom: 30px;">DEVELOPER INFO</h2>
                        <div class="row fw-light fs-small gap-5">
                            <div class="col">Nama : Ferlinda Tanwio</div>
                            <div class="col">NRP : 224117127</div>
                        </div>
                        <div class="row fw-light fs-small gap-5">
                            <div class="col">Hobby : Baca Komik & Tidur</div>
                            <div class="col">Favorite Game : Tidur</div>
                        </div>
                    </div>

                    <div class="mb-3">
                        <h2 style="text-align:right; margin-bottom: 30px;">Supported By</h2>
                        <div class="row">
                            <div class="col"><img width="130px" src="{{asset('assets/store_logos__0004_Layer-8.webp')}}" alt="steam"></div>
                            <div class="col"><img width="130px" src="{{asset('assets/store_logos__0006_Layer-3.webp')}}" alt="gogcom"></div>
                            <div class="col"><img width="130px" src="{{asset('assets/XboxGamePass_2020.webp')}}" alt="xbox"></div>
                            <div class="col"><img width="130px" src="{{asset('assets/store_logos__0003_Layer-4.webp')}}" alt="humleStore"></div>
                        </div>
                         <div class="row">
                            <div class="col"><img width="130px" src="{{asset('assets/switch_logo_new.webp')}}" alt="switch"></div>
                            <div class="col"><img width="130px" src="{{asset('assets/switch2_logo_new.webp')}}" alt="switch2"></div>
                            <div class="col"><img width="130px" src="{{asset('assets/PS4_Logo.webp')}}" alt="PS4"></div>
                            <div class="col"><img width="130px" src="{{asset('assets/PS5_Logo_White.webp')}}" alt="PS5"></div>
                        </div>
                        
                    </div>

                </div>

                    <hr style="color:white;">

                    <!-- bagian bawah -->
                    <div>
                        <p class="text-center text-white fw-light" style="overflow: hidden;">Copyright SilkSong © 2025</p>
                    </div>

            </div>

         </div>    


    </div>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</body>
</html>