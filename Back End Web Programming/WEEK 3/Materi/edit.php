<?php
    require 'koneksi.php';


    if(isset($_REQUEST['update'])){
        //update character
        $kueri = "update `characters` set `name` = :p1, `house_id` = :p2, `role` = :p3 where id = :id";
        $stmt = $conn->prepare($kueri);
        $stmt->bindParam(':p1', $_REQUEST['inputName']);
        $stmt->bindParam(':p2', $_REQUEST['inputHouse']);
        $stmt->bindParam(':p3', $_REQUEST['inputRole']);
        $stmt->bindParam(':id', $_REQUEST['id']);
        $stmt->execute();

        //update wand
        $kueri = "update `wands` set `wood` = :p1, `core` = :p2, `length` = :p3 where character_id = :id";
        $stmt = $conn->prepare($kueri);
        $stmt->bindParam(':p1', $_REQUEST['inputWood']);
        $stmt->bindParam(':p2', $_REQUEST['inputCore']);
        $stmt->bindParam(':p3', $_REQUEST['inputLength']);
        $stmt->bindParam(':id', $_REQUEST['id']);
        $stmt->execute();

        header("Location: index.php");
        exit();
    }


    if(isset($_REQUEST['id'])){
        $id = $_REQUEST['id'];

        $kueri = "select c.id, c.name , c.role,h.id as house_id ,h.name as house_name, w.wood, w.core, w.length from characters c join houses h on c.house_id = h.id join wands w on w.character_id = c.id where c.id = :id";
        $stmt = $conn->prepare($kueri);
        $stmt->bindParam(':id', $id);
        $stmt->execute();
        $data = $stmt->fetch();

    }else{
        header("Location: index.php");
        exit();
    }

    

?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Edit</title>
</head>
<body>
    <div class="container mt-4">
        <a href="index.php" class="btn btn-primary"> <- Back to Character</a>
        <div class="card p-4 my-4">
            <h1>Edit Character</h1>
            <form method="post">
                <div class="mb-3">
                    <label for="inputName" class="form-label">Name</label>
                    <input type="text" class="form-control" id="inputName" name="inputName" value="<?= htmlspecialchars($data['name']) ?>" required>
                </div>
                <div class="mb-3">
                    <label for="inputHouse" class="form-label">House</label>
                    <select class="form-select" id="inputHouse" name="inputHouse">
                        <option value="1" <?php if($data['house_id'] == 1) echo 'selected'; ?>>Gryffindor</option>
                        <option value="2" <?php if($data['house_id'] == 2) echo 'selected'; ?>>Slytherin</option>
                        <option value="3" <?php if($data['house_id'] == 3) echo 'selected'; ?>>Ravenclaw</option>
                        <option value="4" <?php if($data['house_id'] == 4) echo 'selected'; ?>>Hufflepuff</option>
                    </select>
                </div>
                <div class="mb-3">
                    <label for="inputRole" class="form-label">Role</label>
                    <input type="text" class="form-control" id="inputRole" name="inputRole" value="<?= htmlspecialchars($data['role']) ?>" required>
                </div>

                <hr>
                <h3>Wand Information</h3>
                <div class="row">
                    <div class="col">
                        <label for="inputWood" class="form-label">Wood</label>
                        <input type="text" class="form-control" id="inputWood" name="inputWood" value="<?= htmlspecialchars($data['wood']) ?>" required>
                    </div>
                    <div class="col">
                        <label for="inputCore" class="form-label">Core</label>
                        <input type="text" class="form-control" id="inputCore" name="inputCore" value="<?= htmlspecialchars($data['core']) ?>" required>
                    </div>
                    <div class="col">
                        <label for="inputLength" class="form-label">Length</label>
                        <input type="text" class="form-control" id="inputLength" name="inputLength" value="<?= htmlspecialchars($data['length']) ?>" required>
                    </div>
                </div>
                
                <input type="hidden" name="id" value="<?= $data['id'] ?>">
                <div class="mt-4">
                    <input type="submit" value="Update Character" class="btn btn-primary" name="update"> 
                    <a href="index.php" class="btn btn-secondary">Cancel</a>
                </div>
            </form>
        </div>

    </div>
</body>
</html>