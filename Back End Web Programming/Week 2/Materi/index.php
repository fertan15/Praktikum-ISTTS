<?php 
require_once 'util.php'; 

// Clear success cookie if it exists (must be before any output)
if(isset($_COOKIE['addSuccess'])) {
    setcookie("addSuccess", "", time() - 3600, "/");
}

// Kick if accessing directly
if (!isset($_SESSION['logged_in']) || !$_SESSION['logged_in']) {
    header("Location: login.php?error=direct");
    exit();
}

// Add to cart
if(isset($_REQUEST['action']) && $_REQUEST['action'] === 'additem' && isset($_REQUEST['id']) && isset($_REQUEST['quantity'])) {
    $foodId = intval($_REQUEST['id']);
    $quantity = intval($_REQUEST['quantity']);
    
    if (!isset($_SESSION['cart'])) {
        $_SESSION['cart'] = [];
    }

    $found = false;
    foreach ($_SESSION['cart'] as &$item) {
        if ($item['food_id'] === $foodId) {
            $item['quantity'] += $quantity;
            $found = true;
            break;
        }
    }

    if (!$found) {
        $newId = count($_SESSION['cart']) + 1;
        $_SESSION['cart'][] = [
            'id' => $newId, 
            'food_id' => $foodId,
            'name' => $_REQUEST['name'], 
            'price' => $_REQUEST['price'], 
            'quantity' => $quantity
        ];
    }
    
    setcookie("addSuccess", "Item successfully added to cart!", time() + 5, "/");
    header("Location: index.php");
    exit();
}

// Logout
if(isset($_REQUEST['action']) && $_REQUEST['action'] === 'logout') {

    // Save cart before logout
    if(isset($_SESSION['cart']) && isset($_SESSION['users']) && isset($_SESSION['username'])) {
        foreach($_SESSION['users'] as &$user) {
            if($user['username'] == $_SESSION['username']) {
                $user['cart'] = $_SESSION['cart'];
                break;
            }
        }
    }
    
    header("Location: login.php");
    exit();
}
?>


    <!-- ui customer -->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <title>Main</title>
</head>     
<body>
   <nav class="navbar navbar-light bg-light">
        <div class="container-fluid ">
            <a class="navbar-brand  m-3" style="color: #c49600ff; font-weight: bold;">🍟McDonald's Menu</a>
            <form class="d-flex  justify-content-center">
                <p class="navbar-brand" style="color: #984df9ff;font-weight: bold;">Welcome, <?php echo $_SESSION['username']; ?>!</p>
                <a href="cart.php" class="btn btn-primary mx-1" style="height:fit-content;" type="submit">View Cart (<?php echo isset($_SESSION['cart']) ? count($_SESSION['cart']) : 0; ?>)</a>
                <a href="?action=logout" class="btn btn-danger mx-1" style="height:fit-content;" type="submit">Logout</a>
            </form>
        </div>
    </nav>
    <?php 
        if(isset($_COOKIE['addSuccess'])) {
            echo "<div class=\"alert alert-success alert-dismissible fade show\" role=\"alert\">" . htmlspecialchars($_COOKIE['addSuccess']) . "
                <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>
            </div>";
        }
    ?>
    <div class="main d-grid gap-3 m-5" style="grid-template-columns: repeat(4, minmax(250px, 1fr));">
        <?php foreach ($dummy_foods as $food): ?>
            <div class="card" style="width: 18rem;">
                <img src="<?php echo $food['image']; ?>" class="card-img-top" style="height: 200px; object-fit: cover;" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><?php echo $food['name']; ?></h5>
                    <p class="card-text mt-3"><?php echo $food['description']; ?></p>
                    <h4 class="card-text text-success mb-3">Rp <?php echo $food['price']; ?></h4>
                    <form method="post">
                        <input type="hidden" name="action" value="additem">
                        <input type="hidden" name="id" value="<?php echo $food['id']; ?>">
                        <input type="hidden" name="name" value="<?php echo $food['name']; ?>">
                        <input type="hidden" name="price" value="<?php echo $food['price']; ?>">
                        <div class="d-flex justify-item-center align-items-center">
                            <input type="number" class="form-control" name="quantity" style="width: 60px; height: 38px;" value="1" min="1">
                            <button type="submit" class="btn btn-primary m-2" style="Background-color: #f95914ff;">Add to Cart</button>
                        </div>
                    </form>
                </div>
            </div>
        <?php endforeach; ?>
    </div>



    <!-- bootstrap -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>

