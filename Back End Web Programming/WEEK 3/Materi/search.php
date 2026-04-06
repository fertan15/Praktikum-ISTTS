<?php
    require 'koneksi.php';

    if(isset($_REQUEST['search'])){
        $searchBar = $_REQUEST['inputSearch'];
        $searchTerm = '%' . $_REQUEST['inputSearch'] . '%';
        $query = "SELECT characters.id, characters.name, houses.id as house_id ,houses.name AS house_name, characters.role, wands.wood, wands.core, wands.length FROM characters JOIN houses ON characters.house_id = houses.id JOIN wands ON wands.character_id = characters.id WHERE characters.name LIKE :searchTerm OR houses.name LIKE :searchTerm OR characters.role LIKE :searchTerm OR wands.wood LIKE :searchTerm OR wands.core LIKE :searchTerm";
        $stmt = $conn->prepare($query);
        $stmt->bindParam(':searchTerm', $searchTerm);
        $stmt->execute();
        $data = $stmt->fetchAll();
    } else if(isset($_REQUEST['clear'])){
        $searchBar = "";
        $query = "select c.id, c.name , c.role,h.id as house_id ,h.name as house_name, w.wood, w.core, w.length from characters c join houses h on c.house_id = h.id join wands w on w.character_id = c.id";
        $stmt = $conn->prepare($query);
        $stmt->execute();
        $data = $stmt->fetchAll();
    } else {
        $data = [];
    }



?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <div>
        <a href="index.php" class="btn btn-primary m-4"> <- Back to Characters</a>
        <div class="card p-4">
            <div class="div"><h4>Search Characters</h4></div>
            <form action="">
                <div class="d-flex">
                    <input type="text" class="form-control m-2" id="inputSearch" name="inputSearch" placeholder="Search by name, house, or role..." value="<?= isset($searchBar) ? htmlspecialchars($searchBar) : '' ?>">
                    <input type="submit" value="search" name="search" class="btn btn-primary m-2">
                    <input type="submit" value="clear" name="clear" class="btn btn-secondary m-2">
                </div>
            </form>
        </div>

        <!-- hasil search -->
        <div class="card p-4">
            <h4>Search Results (<?= count($data) ?> Found)</h4>
            <div>
                                <table class="table">
                  <thead>
                    <tr>
                      <th scope="col">NAME</th>
                      <th scope="col">HOUSE</th>
                      <th scope="col">ROLE</th>
                      <th scope="col">WAND</th>
                    </tr>
                  </thead>
                  <tbody>
                    <?php foreach ($data as $row): ?>
                      <tr>
                        <td class="py-4"><?= htmlspecialchars($row['name']) ?></td>
                        <td class="my-4 <?php if($row['house_id'] == 1) echo 'badge rounded-pill text-bg-danger'; else if($row['house_id'] == 2) echo 'badge rounded-pill text-bg-success'; else if($row['house_id'] == 3) echo 'badge rounded-pill text-bg-primary';else echo 'badge rounded-pill text-bg-warning'; ?>"><?= htmlspecialchars($row['house_name']) ?></td>
                        <td class="py-4"><?= htmlspecialchars($row['role']) ?></td>
                        <td>
                              <div class="row">
                                <div class="col"><?= htmlspecialchars($row['wood']) ?></div>
                              </div>  
                              <div class="row">
                                <div class="col <?php if($row['core'] == 'Unicorn hair') echo' badge" style="background: blueviolet;'; else if($row['core'] == 'Dragon heartstring') echo' badge" style="background: red;'; else if($row['core'] == 'Phoenix feather') echo' badge" style="background: orange;'; else if($row['core'] == 'Unknown') echo' badge" style="background: rgba(59, 59, 255, 0.899);'; else echo' badge" style="background: rgb(65, 65, 65)  ;';   ?> width:auto;" ><?= htmlspecialchars($row['core']) ?></div>
                                <div class="col"><?= htmlspecialchars($row['length']) ?></div>
                              </div>
                        </td>
                      </tr>
                    <?php endforeach; ?>
                  </tbody>

                </table>

            </div>
        </div>

    </div>
</body>
</html>