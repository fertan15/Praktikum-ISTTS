<?php require('./data.php'); ?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tugas Minggu_1</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">


    <style>
        .truncate {
            display: -webkit-box;
            -webkit-line-clamp: 2; /* Show only 2 lines */
            -webkit-box-orient: vertical;
            overflow: hidden;
            text-overflow: ellipsis;
            max-width: 600px; /* adjust as needed */
        }
    </style>
</head>
<body>
    <div class="min-vh-100 d-flex flex-column" style="background-image: url('./bgYellow.jpg'); background-size:contain; background-position: center; background-repeat: repeat;">

        <!-- header -->
        <header class="text-white py-3" style="background-color: #f87171;">
            <div class="container-fluid">
                <div class="row justify-content-between align-items-center">

                    <div class="col-md-1"></div>

                    <div class="col-md-5">
                        <div class="d-flex align-items-center justify-content-start">

                            <h1 class="h3 mb-0 fw-bold">Pokemon Page</h1>
                        </div>
                    </div>

                    <nav class="col-md-5">
                        <div class="d-flex justify-content-center justify-content-md-end">
                            <a href="#" class="text-white text-decoration-none me-4 hover-underline">Home</a>
                            <a href="#" class="text-white text-decoration-none me-4 hover-underline">Pokemon List</a>
                            <a href="#" class="text-white text-decoration-none hover-underline">About</a>
                        </div>
                    </nav>

                    <div class="col-md-1"></div>

                </div>
            </div>
        </header>

        <!-- Main Content -->
        <div class="container ">
            <!-- opening card -->
            <div class=" d-flex justify-content-center">
                <div class="my-3 mx-5 card bg-white" style="box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2); width: 60%;">
                    <div class="row">
                        <!-- logo -->
                        <div class="col-3">
                            <img src="logoPokemon.png" style="width:15vw;" alt="Logo">
                        </div>
                        <!-- tulisan -->
                        <div class="col-9 d-flex flex-column justify-content-center align-content-center text-center">
                            <!-- welcome -->
                            <div class="row">
                                <div class="col">
                                    <h4 style="color: #46dd7c;">Welcome to the Pokemon Page!</h4>
                                </div>
                            </div>
                            <!-- description -->
                            <div class="row">
                                <div class="col">
                                    <p style="color: #9e66cd;">Explore various Pokemon and their details.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

             </div>

            <div class="d-flex flex-wrap justify-content-center">
            <!-- card list -->
            <?php foreach ($pokemon as $p): ?>

                <div class="card p-2 m-3 " style="width: 25%; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);">
                    <div class="d-flex justify-content-center mt-4 p-0">
                        <img src="<?= $p['gambar']; ?>" class=" card-img-top m-0 p-0" alt="<?= $p['nama']; ?>" style="width: 80px;">
                    </div>
                    
                    <div class="card-body">
                        <!-- nama -->
                        <div class="card-title text-center fw-bold mb-0 pb-0" style="font-size: 1.5rem;"><?= $p['nama']; ?></div>
                        <!-- elemen -->
                        <div class="card-subtitle">
                            <?php 
                                if(str_contains(strtolower($p['element']), 'electric')) {
                                    echo '<span class="badge" style="background-color: #f6ee9c; color: #ffbc2c; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'fire')) {
                                    echo '<span class="badge" style="background-color: #f87171; color: #b91c1c; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'water')) {
                                    echo '<span class="badge" style="background-color: #bae6fd; color: #2563eb; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'grass')) {
                                    echo '<span class="badge" style="background-color: #bbf7d0; color: #15803d; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'psychic')) {
                                    echo '<span class="badge" style="background-color: #fbcfe8; color: #db2777; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'poison')) {
                                    echo '<span class="badge" style="background-color: #e9d5ff; color: #7c3aed; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'dark')) {
                                    echo '<span class="badge" style="background-color: #e5e7eb; color: #374151; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'steel')) {
                                    echo '<span class="badge" style="background-color: #cbd5e1; color: #64748b; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'ghost')) {
                                    echo '<span class="badge" style="background-color: #c7d2fe; color: #4338ca; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'normal')) {
                                    echo '<span class="badge" style="background-color: #f3f4f6; color: #6b7280; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'fighting')) {
                                    echo '<span class="badge" style="background-color: #fed7aa; color: #ea580c; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'rock')) {
                                    echo '<span class="badge" style="background-color: #d1d5db; color: #6b7280; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'ground')) {
                                    echo '<span class="badge" style="background-color: #fcd34d; color: #b45309; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'flying')) {
                                    echo '<span class="badge" style="background-color: #e0f2fe; color: #0ea5e9; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'bug')) {
                                    echo '<span class="badge" style="background-color: #d9f99d; color: #65a30d; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'ice')) {
                                    echo '<span class="badge" style="background-color: #a7f3d0; color: #0891b2; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'dragon')) {
                                    echo '<span class="badge" style="background-color: #ddd6fe; color: #7c3aed; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else if(str_contains(strtolower($p['element']), 'fairy')) {
                                    echo '<span class="badge" style="background-color: #ffe4e6; color: #be185d; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">'.$p['element'].'</span>';
                                }else {
                                    echo '<span class="badge" style="background-color: #f3f4f6; color: #6b7280; border-radius: 0.8rem; font-weight: 500; margin-right: 0.2rem;">' . $p['element'] . '</span>';
                                }



                            ?>
                            
                        </div>
                        <span style="color: #1e1e1eb8; font-size: 0.9rem; font-weight: 600; margin-top : 100px; margin-bottom:100px;">Skills:</span>
                        <div class="d-flex justify-content-start ml-0 my-2">
                                <div>
                                    <span class="badge " style="background-color: #dddee0ff; font-size: 0.9rem; color: #1e1e1eb8; border-radius: 0.2rem; font-weight: 500;"><?= $p['skill'][0]; ?></span>
                                    <span class="badge " style="background-color: #dddee0ff; font-size: 0.9rem; color: #1e1e1eb8; border-radius: 0.2rem; font-weight: 500;"><?= $p['skill'][1]; ?></span>
                                </div>
                        </div>
                        <!-- deskripsi -->
                         <div class="card-text truncate"><?= $p['deskripsi']; ?></div>
                    </div>
                </div>
                

            <?php endforeach; ?>
                                
            </div>
        </div>

    </div>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>