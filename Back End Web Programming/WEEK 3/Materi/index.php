<?php
  require 'koneksi.php';

  unset($_SESSION['eName']);
  unset($_SESSION['eHouse']);
  unset($_SESSION['eRole']);
  unset($_SESSION['eWood']);
  unset($_SESSION['eCore']);
  unset($_SESSION['eLength']);  


  if(isset($_REQUEST["add"])){
    $invalid = false;
    //cek validasai
    if(!isset($_REQUEST["inputName"]) || $_REQUEST["inputName"] == ""){
        $_SESSION['eName'] = "Name is required";
        $invalid = true;
    }

      if(!isset($_REQUEST["inputHouse"]) || $_REQUEST["inputHouse"] == "0"){
        $_SESSION['eHouse'] = "Please select a house";
        $invalid = true;
    }


      if(!isset($_REQUEST["inputRole"]) || $_REQUEST["inputRole"] == ""){
        $_SESSION['eRole'] = "Role is required";
        $invalid = true;
    }


      if(!isset($_REQUEST["inputWandWood"]) || $_REQUEST["inputWandWood"] == ""){
        $_SESSION['eWood'] = "Wood is required";
        $invalid = true;
    }


      if(!isset($_REQUEST["inputWandCore"]) || $_REQUEST["inputWandCore"] == ""){
        $_SESSION['eCore'] = "Core is required";
        $invalid = true;
    }


      if(isset($_REQUEST["inputWandLength"]) ){
        if($_REQUEST["inputWandLength"] < 3 || $_REQUEST["inputWandLength"] == ""){
          $_SESSION['eLength'] = "Length must be at least 3";
          $invalid = true;
        }  
     }    
    if($invalid) {
      goto form;
    }
  }

  //kalo misal delete
  if(isset($_REQUEST["del"])){
      $targetId = $_REQUEST['id'];

      //hapus dari wand dulu soalnya ada foreign key
      $kueri = "delete from wands where character_id = :id";
      $stmt = $conn->prepare($kueri);
      $stmt->bindParam(':id', $targetId);
      $stmt->execute();
      //hapus dari character
      $kueri = "delete from characters where id = :id";
      $stmt = $conn->prepare($kueri);
      $stmt->bindParam(':id', $targetId);
      $stmt->execute();
  }


  //add
    if(isset($_REQUEST["add"])){


      //input character dulu yes
      $kueri = "insert  into `characters`(`name`,`house_id`,`role`) values (:p1, :p2 , :p3)";
      $stmt = $conn->prepare($kueri);
      $stmt->bindParam(':p1', $_REQUEST['inputName']);
      $stmt->bindParam(':p2', $_REQUEST['inputHouse']);
      $stmt->bindParam(':p3', $_REQUEST['inputRole']);
      $stmt->execute();


      //dapetin id character yang baru diinput
      $newCharacterId = $conn->lastInsertId();

      //input wand
      $kueri = "insert  into `wands`(`character_id`,`wood`,`core`,`length`) values (:p1, :p2 , :p3, :p4)";
      $stmt = $conn->prepare($kueri);
      $stmt->bindParam(':p1', $newCharacterId);
      $stmt->bindParam(':p2', $_REQUEST['inputWandWood']);
      $stmt->bindParam(':p3', $_REQUEST['inputWandCore']);
      $stmt->bindParam(':p4', $_REQUEST['inputWandLength']);
      $stmt->execute();

      //biar ga nambah terus pas di refresh
      header("Location: index.php");

    }




  form:
 
  //default all data
  $kueri = "select c.id, c.name , c.role,h.id as house_id ,h.name as house_name, w.wood, w.core, w.length from characters c join houses h on c.house_id = h.id join wands w on w.character_id = c.id";
  $stmt = $conn->prepare($kueri);
  if ($stmt->execute()) {
      $data = $stmt->fetchAll();
  }


?>





<!doctype html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>index</title>
    <style>
      .form-text{
        color:red;
      }
    </style>
  </head>
  <body>
    <div>
        <div class="container-fluid d-flex justify-content-center p-5" style="  border-bottom: 10px solid; border-image: linear-gradient(to right, #00c6ff, #0072ff, #8e2de2, #4a00e0) 1;border-radius: 10px; font-weight: bold;" >
            <a class="navbar-brand" href="#" style="font-size: 3rem; background: linear-gradient(to right, #00c6ff, #0072ff, #8e2de2, #4a00e0); -webkit-background-clip: text; -webkit-text-fill-color: transparent;  ">Harry Potter Characters</a>
        </div>
      
        <form method="post">
            <div class="card p-5 m-3" style="box-shadow: 0 1px 2px 0 rgba(100, 100, 100, 0.2), 0 6px 20px 0 rgba(150, 150, 150, 0.19);">
              <div class="row my-3">
                <div class="col" style="font-weight: bold; font-size:2rem;">Add New Character</div>
              </div>
              <div class="row">
                <div class="col">
                  <label for="inputName" class="form-label" style="font-weight: 600;color: rgba(89, 89, 89, 1);">Name</label>
                  <input type="text" id="inputName" name="inputName" class="form-control" aria-describedby="nameHelpBlock" required>
                  <div id="nameHelpBlock" class="form-text">
                    <?php if(isset($_SESSION['eName'])) echo $_SESSION['eName']; ?>
                    <!-- note -->
                  </div>
                </div>
                <div class="col">
                  <label for="inputHouse" class="form-label" style="font-weight: 600;color: rgba(89, 89, 89, 1);">House</label>
                  <select class="form-select" aria-label="Default select example" name="inputHouse" >
                    <option selected value="0" disabled hidden>Select House</option>
                        <option value="1">Gryffindor</option>
                        <option value="4">Hufflepuff</option>
                        <option value="3">Ravenclaw</option>
                        <option value="2">Slytherin</option>
                  </select>              
                  <div id="houseHelpBlock" class="form-text">
                    <?php if(isset($_SESSION['eHouse'])) echo $_SESSION['eHouse']; ?>
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col">
                  <label for="inputRole" class="form-label" style="font-weight: 600;color: rgba(89, 89, 89, 1);">Role</label>
                  <input type="text" id="inputRole" name="inputRole" class="form-control" aria-describedby="roleHelpBlock" required>
                  <div id="roleHelpBlock" class="form-text">
                    <?php if(isset($_SESSION['eRole'])) echo $_SESSION['eRole']; ?>
                  </div>
                </div>
                <div class="col">
                  <label for="inputWandWood" class="form-label" style="font-weight: 600;color: rgba(89, 89, 89, 1);">Wand Wood</label>
                  <input type="text" id="inputWandWood" name="inputWandWood" class="form-control" aria-describedby="wandWoodHelpBlock" required>
                  <div id="wandWoodHelpBlock" class="form-text">
                    <?php if(isset($_SESSION['eWood'])) echo $_SESSION['eWood']; ?>
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col">
                  <label for="inputWandCore" class="form-label" style="font-weight: 600;color: rgba(89, 89, 89, 1);">Wand Core</label>
                  <input type="text" id="inputWandCore" name="inputWandCore" class="form-control" aria-describedby="wandCoreHelpBlock" required>
                  <div id="wandCoreHelpBlock" class="form-text">
                    <?php if(isset($_SESSION['eCore'])) echo $_SESSION['eCore']; ?>
                  </div>
                </div>
                <div class="col">
                  <label for="inputWandLength" class="form-label" style="font-weight: 600;color: rgba(89, 89, 89, 1);">Wand Length</label>
                  <input type="number" step="0.1" id="inputWandLength" name="inputWandLength" class="form-control" aria-describedby="wandLengthHelpBlock" min="3" required>
                  <div id="wandLengthHelpBlock" class="form-text">
                    <?php if(isset($_SESSION['eLength'])) echo $_SESSION['eLength']; ?>
                  </div>
                </div>
              </div>
              <div class="row my-3">
                <div class="col">
                  <input type="submit" class="btn btn-primary" name="add" value="Add Character">
                </div>
              </div>

              <!-- end card -->
            </div>

          </form>
          
          <div class="div d-flex justify-content-center m-4">
            <a class="btn btn-success" href="view.php">View Statistics & Search</a>
          </div>


          <!-- list -->
            <div class="card p-5 m-3" style="box-shadow: 0 1px 2px 0 rgba(100, 100, 100, 0.2), 0 6px 20px 0 rgba(150, 150, 150, 0.19);">
               <div>
                 <h1>Character List</h1>
               </div>
               <div>
                <table class="table">
                  <thead>
                    <tr>
                      <th scope="col">NAME</th>
                      <th scope="col">HOUSE</th>
                      <th scope="col">ROLE</th>
                      <th scope="col">WAND</th>
                      <th scope="col">ACTION</th>
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
                        <td class="py-4">
                          <form method="post">
                            <input type="hidden" name="id" value="<?= $row['id'] ?>">
                            <a class="btn btn-primary" name="edit" value="Edit" href="edit.php?id=<?= $row['id'] ?>">Edit</a>
                            <input type="submit" class="btn btn-danger" name="del" value="Delete">
                          </form>
                        </td>
                      </tr>
                    <?php endforeach; ?>
                  </tbody>

                </table>
               </div>
             </div>

        <!-- end container -->
    </div>

  </body>
</html>