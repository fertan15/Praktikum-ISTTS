<?php
require 'data.php';
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Praktikum - Minggu 1</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">

    <style>
        .overall{
            background-color: #2a475e;
        }
        .satuan{
            background-color: #1b2838;
        }
    </style>
   
</head>
<body>
    <div class="min-vh-100 d-flex flex-column bg-dark ">
        <!-- heading -->
        <header class="bg-dark text-white py-3">
                <div class="container-fluid">
                    <div class="row">

                        <div class="col-md-1"></div>

                                <img src="logo.png" class="" style="height: 80px; width: 200px;" alt="Logo">


                        <div class="col-md-1"></div>

                    </div>
                </div>
            </header>

            <!-- main -->
            <main class="container-fluid flex-grow-1 text-white ">
                <?php foreach ($games as $t) :?>
                    <div class="row border border-white bg-blue m-3 rounded overall">
                        <div class="col-3">
                            
                            <!-- gambar main di kiri -->
                            <div>
                                <div class="card text-white border border-white satuan m-3 mt-3">
                                    <img src="<?= $t['img'] ?>" class="card-img">
                                    <h3 class="card-title text-center py-3"><?= $t['title'] ?></h3>
                                    <h6 class="card-subtitle text-center">Genre: <?= $t['genre'] ?></h6>
                                    <p class="card-text text-center py-2">Release Date: <?= $t['release_date'] ?></p>
                                </div>
                            

                            </div>
                        </div>

                        <div class="col-9">
                            <!-- info dikanan -->
                            <div>
                                <?php foreach ($t['reviews'] as $r) :?>
                                    <div class="row border border-white satuan m-3 px-1 py-3 rounded align-items-center">
                                        <!-- reco or no reco -->
                                        <div class="col-2 d-flex align-items-center">
                                            <?php 
                                                if($r['type'] == "Recommended"){
                                                    echo "
                                                        <span class='badge text-bg-primary'>👍Recommended</span>
                                                    ";
                                                }else if($r['type'] == "Not Recommended"){
                                                    echo "
                                                        <span class='badge text-bg-danger'>👎Not Recommended</span>
                                                    ";
                                                } 
                                            ?>
                                        </div>
                                        <!-- username -->
                                        <div class="col-6">
                                                <div class="row">
                                                    <div class="col"><h3><?= $r['user'] ?></h3></div>
                                                </div>
                                                <div class="row">
                                                    <div class="col"><?= $r['comment'] ?></div>
                                                </div>
                                        </div>

                                        <!-- review helpfull or nah -->
                                        <div class="col-2 m-0" style="font-size: 0.75em;">
                                                <div class="row">
                                                    <div class="col text-success"><?= $r['votes']['helpful'] ?> find this review helpful</div>
                                                </div>
                                                <div class="row text-danger">
                                                    <div class="col"><?= $r['votes']['not_helpful'] ?> find this review unhelpful</div>
                                                </div>
                                        </div>
   
                                        <!-- funny or awarded -->
                                        <div class="col-2 m-0" style="font-size: 0.75em;">
                                                <div class="row">
                                                    <div class="col text-warning"><?= $r['votes']['funny'] ?> find this review funny</div>
                                                </div>
                                                <div class="row">
                                                    <div class="col"><?= $r['votes']['award'] ?> awarded this review </div>
                                                </div>
                                        </div>

                                    </div>

                                <?php endforeach; ?>
                            </div>

                        </div>

                    </div>
                <?php endforeach; ?>

            </div>


    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>