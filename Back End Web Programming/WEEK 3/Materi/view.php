<?php
    require 'koneksi.php';


    //get all character
    $query = "SELECT * FROM characters";
    $stmt = $conn->prepare($query);
    $stmt->execute();
    $characters = $stmt->fetchAll();

    //get characters without wands
    $query = "SELECT id FROM characters WHERE id NOT IN (SELECT character_id FROM wands)";
    $stmt = $conn->prepare($query);
    $stmt->execute();
    $charactersWithoutWands = $stmt->fetchAll();

    //get characters with wands
    $query = "SELECT id FROM characters WHERE id IN (SELECT character_id FROM wands)";
    $stmt = $conn->prepare($query);
    $stmt->execute();
    $charactersWithWands = $stmt->fetchAll();

    //get unicoern hair wand
    $query = "SELECT id FROM wands WHERE core = 'unicorn hair'";
    $stmt = $conn->prepare($query);
    $stmt->execute();
    $unicornHairWands = $stmt->fetchAll();

    //get Phoenix feather wand
    $query = "SELECT id FROM wands WHERE core = 'phoenix feather'";
    $stmt = $conn->prepare($query);
    $stmt->execute();
    $phoenixFeatherWands = $stmt->fetchAll();


    //get Unknown wand
    $query = "SELECT id FROM wands WHERE core = 'unknown'";
    $stmt = $conn->prepare($query);
    $stmt->execute();
    $unknownWands = $stmt->fetchAll();

    //get Dragon heartstring wand
    $query = "SELECT id FROM wands WHERE core = 'Dragon heartstring'";
    $stmt = $conn->prepare($query);
    $stmt->execute();
    $dragonHeartstringWands = $stmt->fetchAll();


    //get other wand
    $query = "SELECT id FROM wands WHERE core <> 'unicorn hair' AND core <> 'phoenix feather' AND core <> 'unknown' AND core <> 'Dragon heartstring'";
    $stmt = $conn->prepare($query);
    $stmt->execute();
    $otherWands = $stmt->fetchAll();





?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <div class="container m-4">
        <a href="index.php" class="btn btn-primary"><- Go Back to Characters</a>
        <div class="my-4">
            <h1 style="text-align: center;">Database Statistics & Search</h1>
        </div>
        <!-- search  -->
        <div class="card p-4">
            <div class="div"><h4>Search Characters</h4></div>
            <form action="search.php" method="get">
                <div class="d-flex">
                    <input type="text" class="form-control" id="inputSearch" name="inputSearch" placeholder="Search by name, house, or role...">
                    <input type="submit" value="search" name="search" class="btn btn-primary">
                </div>
            </form>
        </div>
        <!-- statistics -->
         <div class="d-flex justify-content-between my-4">
            <div class="card p-4" style="min-width : 49%">
                <div><h4>General Statistics</h4></div>
                <div style="background-color: rgba(182, 193, 231, 0.3); border-radius: 5px; " class="my-2 d-flex justify-content-between align-items-center">
                    <p class="p-2">Total Characters:</p> <p class="p-2"><?= count($characters) ?></p>
                </div>
                <div style="background-color: rgb(174, 209, 174, 0.3); border-radius: 5px; " class="my-2 d-flex justify-content-between align-items-center">
                    <p class="p-2">Characters with Wands:</p> <p class="p-2"><?= count($charactersWithWands) ?></p>
                </div>
                <div style="background-color: rgb(231, 182, 223, 0.3); border-radius: 5px; " class="my-2 d-flex justify-content-between align-items-center">
                    <p class="p-2">Characters without Wands:</p> <p class="p-2"><?= count($charactersWithoutWands) ?></p>
                </div>

            </div>

            <div class="card p-4" style="min-width : 49%">
                <div><h4>Characters per House</h4></div>
                <div style="background-color: rgba(182, 193, 231, 0.3); border-radius: 5px; border-left: 5px solid #007bff;" class="my-2 d-flex justify-content-between align-items-center">
                    <p class="p-2">Ravenclaw</p> <p class="my-2 mx-3 py-1 px-3 rounded-pill bg-primary">4</p>
                </div>
                <div style="background-color: rgba(231, 182, 182, 1); border-radius: 5px; border-left: 5px solid #dc3545;" class="my-2 d-flex justify-content-between align-items-center">
                    <p class="p-2">Gryffindor</p> <p class="my-2 mx-3 py-1 px-3 rounded-pill bg-danger">4</p>
                </div>
                <div style="background-color: rgba(231, 221, 182, 1); border-radius: 5px; border-left: 5px solid #ffc107;" class="my-2 d-flex justify-content-between align-items-center">
                    <p class="p-2">Hufflepuff</p> <p class="my-2 mx-3 py-1 px-3 rounded-pill bg-warning">0</p>
                </div>
                <div style="background-color: rgb(174, 209, 174, 0.3); border-radius: 5px; border-left: 5px solid #28a745;" class="my-2 d-flex justify-content-between align-items-center">
                    <p class="p-2">Slytherin</p> <p class="my-2 mx-3 py-1 px-3 rounded-pill bg-success">0</p>
                </div>
            </div>

         </div>


         <!-- wand core distribution -->

         <div class="card p-4">
            <h4>Wand Core Distribution</h4>
            <div class="d-flex flex-wrap justify-content-left">
                <div class="card d-flex flex-column align-items-center p-4 m-2 bg-success-subtle" style="width: 30%; display: inline-block;">
                        <span class="badge rounded-pill text-bg-success"><?= count($unicornHairWands) ?> Wand</span>
                        <h5 class="pt-2">Unicorn hair</h5>
                        <P>Pure & Consistent</P>
                </div>
                <div class="card d-flex flex-column align-items-center p-4 m-2 bg-warning-subtle" style="width: 30%; display: inline-block;">
                        <span class="badge rounded-pill text-bg-warning"><?= count($phoenixFeatherWands) ?> Wand</span>
                        <h5 class="pt-2">Phoenix feather</h5>
                        <P>Rare & Powerful</P>
                </div>
                <div class="card d-flex flex-column align-items-center p-4 m-2 bg-primary-subtle" style="width: 30%; display: inline-block;">
                        <span class="badge rounded-pill text-bg-primary"><?= count($unknownWands) ?> Wand</span>
                        <h5 class="pt-2">Unknown</h5>
                        <P>Mysterious</P>
                </div>
                <div class="card d-flex flex-column align-items-center p-4 m-2 bg-danger-subtle" style="width: 30%; display: inline-block;">
                        <span class="badge rounded-pill text-bg-danger"><?= count($dragonHeartstringWands) ?> Wand</span>
                        <h5 class="pt-2">Dragon heartstring</h5>
                        <P>Strong & Loyal</P>
                </div>
                        <div class= "card d-flex flex-column align-items-center p-4 m-2 bg-secondary-subtle" style="width: 30%; display: inline-block;">
                        <span class="badge rounded-pill text-bg-secondary"><?= count($otherWands) ?> Wand</span>
                        <h5 class="pt-2">Other</h5>
                        <P>Different & Unique</P>
                </div>

            </div>
         </div>
    </div>
</body>
</html>
