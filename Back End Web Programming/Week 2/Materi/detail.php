<?php require_once 'util.php'; 

   

    if(isset($_REQUEST['id'])){
        $userId = intval($_REQUEST['id']);
        $detailUser = getUserDetails($userId);
        if($detailUser == null || $detailUser['admin'] == true){ 
            header("Location: admin.php");
            exit();
        }
        // exit();
    }else{
        header("Location: admin.php");
        exit();
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
       <nav class="navbar navbar-light bg-light">
        <div class="container-fluid ">
            <a class="navbar-brand  m-3" style="font-weight: bold;">User Detail</a>
            <form class="d-flex  justify-content-center">
                <a href="admin.php" class="btn btn-primary mx-1" style="height:fit-content;" type="submit">Back To Admin</a>
                <a href="admin.php?action=logout" class="btn btn-danger mx-1" style="height:fit-content;" type="submit">Logout</a>
            </form>
        </div>
    </nav>

    <div>
        <div class="info card m-3 p-3">
                <h3>User Information</h3>
                <div>
                    <div class="row">
                        <div class="col">
                            <p><strong>Username:</strong> <?php echo $detailUser['username']; ?></p>
                        </div>
                        <div class="col">
                            <p><strong>Email:</strong> <?php echo $detailUser['email']; ?></p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <p><strong>Status:</strong> <?php echo $detailUser['banned'] ? "<span class=\"text-danger\">Banned</span>" : "<span class=\"text-success\">Active</span>"; ?></p>
                        </div>
                        <div class="col">
                            <p><strong>Total Orders:</strong> <?php echo count($detailUser['orders']); ?></p>
                        </div>
                    </div>

                </div>
        </div>

        
        <div>
            <h2 class="m-5">Order History</h2>
            <?php if(count($detailUser['orders']) > 0) { foreach ($detailUser['orders'] as $order): ?>
                
                <div class="card m-3 p-3">
                    <div class="row">
                        <div class="col">
                            <div class="row"><div class="col"><h4>Order ID: <?php echo $order['order_id']; ?></h4></div></div>
                            <div class="row"><div class="col"><p><strong>Date:</strong> <?php echo $order['date']; ?></p></div></div>
                        </div>
                        <div class="col text-end text-success"><p><strong>Total: Rp <?php echo $order['total']; ?></strong></p></div>
                    </div>
                    <div class="row p-3">
                        <div class="col">
                            <div class="row"><div class="col"><h5>Items Ordered:</h5></div></div>
                            <?php foreach ($order['items'] as $item): ?>
                                <div class="row">
                                    <div class="col">
                                        <?php echo $item['name']; ?> X<?php echo $item['quantity']; ?>
                                    </div>
                                    <div class="col text-end">Rp <?php echo $item['price']; ?></div>
                                </div>
                            <?php endforeach; ?>
                        </div>

                        </div>
                        
                        
                    </div>
                </div>


            <?php endforeach; } ?>
        </div>


        <!-- si all user data -->
         <div class="m-5">
            <h3>All Users Order History</h3>
            <table class="table ">
                <thead>
                    <tr>
                        <th>Order ID</th>
                        <th>Username</th>
                        <th>Date</th>
                        <th>Total Items</th>
                        <th>Total Amount</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($_SESSION['Allorders'] as $order): ?>
                        <tr>
                            <td><?php echo $order['order_id']; ?></td>
                            <td><?php echo $order['username']; ?></td>
                            <td><?php echo $order['date']; ?></td>
                            <td><?php echo $order['total_items']; ?></td>
                            <td><?php echo $order['total']; ?></td>
                        </tr>
                    <?php endforeach; ?>
                </tbody>

         </div>
    
    </div>

                                

</body>
</html>