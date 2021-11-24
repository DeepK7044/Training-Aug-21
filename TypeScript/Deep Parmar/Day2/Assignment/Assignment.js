// There is a retail shop which need to manage the inventory,
// whenever some purchase is being made product quantity should be reduced, 
// if quanity is less than 5 reorder request should be raised.
var Inventory = /** @class */ (function () {
    function Inventory() {
    }
    return Inventory;
}());
var ProductArr = [
    { "ProductId": 1, "ProductName": "Bread", "ProductPrice": 30, "ProductQuantity": 6, "IsAvailable": true },
    { "ProductId": 2, "ProductName": "Chips", "ProductPrice": 10, "ProductQuantity": 10, "IsAvailable": true },
    { "ProductId": 3, "ProductName": "Ketchup", "ProductPrice": 20, "ProductQuantity": 8, "IsAvailable": true },
    { "ProductId": 4, "ProductName": "Pasta", "ProductPrice": 40, "ProductQuantity": 4, "IsAvailable": true },
    { "ProductId": 5, "ProductName": "maggi", "ProductPrice": 12, "ProductQuantity": 15, "IsAvailable": true },
    { "ProductId": 6, "ProductName": "Mayo", "ProductPrice": 50, "ProductQuantity": 7, "IsAvailable": true },
    { "ProductId": 7, "ProductName": "Chesse", "ProductPrice": 80, "ProductQuantity": 6, "IsAvailable": true }
];
function AddProduct(ProductData) {
    ProductArr.push(ProductData);
    return ProductArr;
}
function DisplayAllProduct() {
    ProductArr.forEach(function (element) {
        console.log(element);
    });
}
function PurchaseProduct(Product_ID, Product_Quantity) {
    ProductArr.filter(function (Product, index, Array) {
        if (Product.ProductId == Product_ID) {
            if (Product_Quantity <= Product.ProductQuantity) {
                Product.ProductQuantity = Product.ProductQuantity - Product_Quantity;
                console.log("Thank You For Purchasing Product..");
                CheckQuantity();
            }
            else {
                console.log("Product Quantity is very Less..");
            }
        }
    });
}
function Reorder(Product_ID, Product_Quantity) {
    ProductArr.filter(function (Product, index, array) {
        if (Product.ProductId == Product_ID) {
            Product.ProductQuantity = Product.ProductQuantity + Product_Quantity;
            Product.IsAvailable = true;
            console.log("Your Product ".concat(Product.ProductName, " Is Reorder Successfullly"));
        }
    });
}
function CheckQuantity() {
    ProductArr.filter(function (Product, index, array) {
        if (Product.ProductQuantity == 0) {
            Product.IsAvailable = false;
            Reorder(Product.ProductId, 5);
        }
        else if (Product.ProductQuantity < 5) {
            Reorder(Product.ProductId, 5);
        }
    });
}
var Choice = 2;
switch (Choice) {
    case 1:
        var Products = AddProduct({ "ProductId": 8, "ProductName": "Biscuit", "ProductPrice": 10, "ProductQuantity": 10, "IsAvailable": true });
        Products.forEach(function (element) {
            console.log(element);
        });
        break;
    case 2:
        DisplayAllProduct();
        break;
    case 3:
        PurchaseProduct(1, 3);
        DisplayAllProduct();
        break;
    case 4:
        CheckQuantity();
        DisplayAllProduct();
        break;
    default:
        console.log("Please Enter Valid Choice..");
        break;
}
