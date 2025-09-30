<?php require_once 'util.php'; 

   if (!isset($_SESSION['logged_in']) || !isset($_SESSION['Logged_in_user']) || !$_SESSION['Logged_in_user']['admin']) {
       header("Location: login.php?error=directadmin");
       exit();
   }

   //admin page content here

   if(isset($_REQUEST['action']) && $_REQUEST['action'] === 'logout') {
        unset($_SESSION['Logged_in_user']);
        unset($_SESSION['logged_in']);
        unset($_SESSION['username']);   
        unset($_SESSION['cart']);

        header("Location: login.php");
        exit();
   }


   //action
   if(isset($_REQUEST['action']) && isset($_REQUEST['id'])) {

        $userId = intval($_REQUEST['id']);

        //delete user
        if($_REQUEST['action'] === 'delete') {
            foreach($_SESSION['users'] as $key => $user) {
                if($user['id'] === $userId && $user['admin'] == false) {
                    unset($_SESSION['users'][$key]);
                    $_SESSION['users'] = array_values($_SESSION['users']); // Reindex the array
                    break;
                }
            }
            header("Location: admin.php");
            exit();
        }

        //ban user
        if($_REQUEST['action'] === 'ban') {
            foreach($_SESSION['users'] as $key => $user) {
                if($user['id'] === $userId && $user['admin'] == false) {
                    $_SESSION['users'][$key]['banned'] = true;
                    break;
                }
            }
            header("Location: admin.php");
            exit();
        }
        //unban user
        if($_REQUEST['action'] === 'unban') {
            foreach($_SESSION['users'] as $key => $user) {
                if($user['id'] === $userId && $user['admin'] == false) {
                    $_SESSION['users'][$key]['banned'] = false;
                    break;
                }
            }
            header("Location: admin.php");
            exit();
        }



   }
?>
    


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">

</head>
<body>
    <div class="fluid-container m-5">
        <h1>Welcome <span style="color: rgba(255, 179, 0, 1);">Admin</span></h1>
        <a href="?action=logout" class="btn btn-danger">Logout</a>
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>No</th>
                    <th>Username</th>
                    <th>Email</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                <?php $no = 1; ?>
                <?php foreach ($_SESSION['users'] as $user): if($user['admin'] == false){?>
                    <tr>
                        <td><?php echo $no++; ?></td>
                        <td><?php echo $user['username']; ?></td>
                        <td><?php echo $user['email']; ?></td>
                        <td>
                            <a href="detail.php?action=detail&id=<?php echo $user['id']; ?>" class="btn btn-success">Detail</a>
                            <a href="?action=delete&id=<?php echo $user['id']; ?>" class="btn btn-warning">Delete</a>
                            <?php 
                                if($user['banned'] == false) {
                                    echo "<a href=\"?action=ban&id=" . $user['id'] . "\" class=\"btn btn-danger\">Banned</a>";
                                } else {
                                    echo "<a href=\"?action=unban&id=" . $user['id'] . "\" class=\"btn btn-primary\">Unban</a>";
                                }
                            ?>
                        </td>
                    </tr>
                <?php } endforeach; ?>
            </tbody>
        </table>
    </div>



    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>

