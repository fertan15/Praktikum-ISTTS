<?php require_once 'util.php'; 

// Clear notification cookie if it exists (must be before any output)
$notificationMessage = "";
if(isset($_COOKIE['notif'])) {
    $notificationMessage = $_COOKIE['notif'];
    setcookie("notif", "", time() - 3600, "/");
}

if(isset($_REQUEST['action']) && $_REQUEST['action'] == "update"  && isset($_REQUEST['quantity']) && isset($_REQUEST['id']) && isset($_SESSION['cart'])) {
    foreach ($_SESSION['cart'] as $key => &$item) {
        if ($item['id'] == intval($_REQUEST['id'])) {
            $item['quantity'] = intval($_REQUEST['quantity']);
            break;
        }
    }
    header("Location: Cart.php");
    exit();
}

if(isset($_REQUEST['action']) && $_REQUEST['action'] == 'delete' && isset($_REQUEST['id'])) {
    foreach ($_SESSION['cart'] as $key => $item) {
        if ($item['id'] === intval($_REQUEST['id'])) {
            unset($_SESSION['cart'][$key]);
            break;
        }
    }
    $_SESSION['cart'] = array_values($_SESSION['cart']); // Reindex the array
}

if(isset($_REQUEST['action']) && $_REQUEST['action'] == 'clear') {
    unset($_SESSION['cart']);
    setcookie("notif", "Cart Berhasil Dikosongkan!", time() + 5, "/");
    header("Location: Cart.php");
    exit();
}

if(isset($_REQUEST['action']) && $_REQUEST['action'] == 'checkout') {
    if(isset($_SESSION['cart']) && count($_SESSION['cart']) > 0) {
        $total = 0;
        
        // Calculate total
        foreach ($_SESSION['cart'] as $item) {
            $total += $item['price'] * $item['quantity'];
        }
        
        // Save order to user
        $orderId = 'ORD-' . date('YmdHis') . '-' . rand(1000,9999);
        foreach($_SESSION['users'] as $key => $user) {
            if($user['username'] == $_SESSION['username']) {
                $_SESSION['users'][$key]['orders'][] = [
                    'order_id' => $orderId,
                    'items' => $_SESSION['cart'],
                    'total_items' => count($_SESSION['cart']),
                    'total' => $total,
                    'date' => date('d M Y H:i')
                ];

                $newOrder = [
                    'order_id' => $orderId,
                    'date' => date('d M Y H:i'),
                    'username' => $_SESSION['username'],
                    'total_items' => count($_SESSION['cart']),
                    'total' => $total,
                ];

                array_unshift($_SESSION['Allorders'], $newOrder);                
                break;
            }
        }

        
        // Clear cart and set success notification
        unset($_SESSION['cart']);
        setcookie("notif", "Checkout Berhasil! Order ID: " . $orderId . ". Total: Rp " . number_format($total, 0, ',', '.'), time() + 5, "/");
    } else {
        setcookie("notif", "Cart is empty! Cannot checkout.", time() + 5, "/");
    }
    header("Location: Cart.php");
    exit();
}



?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Cart</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">

</head>
<body>
   <nav class="navbar navbar-light bg-light">
        <div class="container-fluid ">
            <a class="navbar-brand  m-3" style="font-weight: bold;">Shopping Cart</a>
            <form class="d-flex  justify-content-center">
                <a href="index.php" class="btn btn-primary mx-1" style="height:fit-content;" type="submit">Continue Shopping</a>
                <a href="index.php?action=logout" class="btn btn-danger mx-1" style="height:fit-content;" type="submit">Logout</a>
            </form>
        </div>
    </nav>
    <?php 
        if(!empty($notificationMessage)) {
            echo "<div class=\"alert alert-success alert-dismissible fade show\" role=\"alert\">" . htmlspecialchars($notificationMessage) . "
                <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>
            </div>";
        }
    ?>

    <table class="table">
        <thead>
            <tr>        
                <th scope="col">Item</th>
                <th scope="col">Price</th>
                <th scope="col">Quantity</th>
                <th scope="col">Subtotal</th>
                <th scope="col">action</th>
            </tr>
        </thead>
        <tbody>

            <?php if(isset($_SESSION['cart']) && count($_SESSION['cart']) > 0) foreach ($_SESSION['cart'] as $item): ?>
                <tr>
                    <td><?php echo $item['name']; ?></td>
                    <td><?php echo $item['price']; ?></td>
                    <form method="post">
                        <input type="hidden" name="id" value="<?php echo $item['id']; ?>">
                        <input type="hidden" name="action" value="update">
                        <td><input type="number" name="quantity"  value="<?php echo $item['quantity']; ?>" min="1" > <input type="submit" value="Update" name="update" class="btn btn-success"></td>
                    </form>
                    <td><?php echo $item['price'] * $item['quantity']; ?></td>
                    <td><a href="?action=delete&id=<?php echo $item['id']; ?>" class="btn btn-danger">Remove</a></td>
                </tr>
            <?php endforeach; 
            

             $total = 0;

            if(isset($_SESSION['cart'])){

                foreach ($_SESSION['cart'] as $item) {
                    $total += $item['price'] * $item['quantity'];
                }
            }

            if(isset($_SESSION['cart']) && count($_SESSION['cart']) > 0){
                echo "
                <tr>
                    <td colspan=\"4\">Total: Rp " . $total . "</td>
                    <td><a href=\"?action=clear\" class=\"btn btn-secondary\">Clear Cart</a> <a href=\"?action=checkout\" class=\"btn btn-success\">Checkout</a></td>
                </tr>";
            }

            ?>

        </tbody>
    </table>

    <?php 

            if(!isset($_SESSION['cart']) || count($_SESSION['cart']) == 0) {
                echo " <div class=\"text-center m-5\"> <div class=\"text-center\">Your Cart is empty</div>
                        <a href=\"index.php\" class=\"btn btn-primary mx-1\" style=\"height:fit-content;\" type=\"submit\">Start Shopping</a></div>";
            }
        ?>

    <!-- bootstrap -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

</body>
</html>