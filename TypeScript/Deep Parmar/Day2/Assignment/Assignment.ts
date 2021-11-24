// There is a retail shop which need to manage the inventory,
// whenever some purchase is being made product quantity should be reduced, 
// if quanity is less than 5 reorder request should be raised.

// Design an interface and classes for the same.

interface IInventory
{
    ProductId:number;
    ProductName:string;
    ProductPrice:number;
    ProductQuantity:number;
    IsAvailable:boolean;

    // display();
}

class Inventory implements IInventory
{
    ProductId:number;
    ProductName:string;
    ProductPrice:number;
    ProductQuantity:number;
    IsAvailable:boolean;

    // display()
    // {
    //     console.log(`ProductId :${this.ProductId} ,ProductName : ${this.ProductName} 
    //                 ,ProductPrice : ${this.ProductPrice},ProductQuantity : ${this.ProductQuantity}
    //                 ,IsAvailable : ${this.IsAvailable}` )
    // }
}

var ProductArr:Inventory[]=
[
    {"ProductId":1,"ProductName":"Bread","ProductPrice":30,"ProductQuantity":6,"IsAvailable":true},
    {"ProductId":2,"ProductName":"Chips","ProductPrice":10,"ProductQuantity":10,"IsAvailable":true},
    {"ProductId":3,"ProductName":"Ketchup","ProductPrice":20,"ProductQuantity":8,"IsAvailable":true},
    {"ProductId":4,"ProductName":"Pasta","ProductPrice":40,"ProductQuantity":4,"IsAvailable":true},                        
    {"ProductId":5,"ProductName":"maggi","ProductPrice":12,"ProductQuantity":15,"IsAvailable":true},
    {"ProductId":6,"ProductName":"Mayo","ProductPrice":50,"ProductQuantity":7,"IsAvailable":true},
    {"ProductId":7,"ProductName":"Chesse","ProductPrice":80,"ProductQuantity":6,"IsAvailable":true}
]

function AddProduct(ProductData:Inventory):Inventory[]
{
    ProductArr.push(ProductData);
    return ProductArr;
}

//For See All Products
function DisplayAllProduct()
{
    ProductArr.forEach(element => {
        console.log(element);
    });
}

//For Purchase Product
function PurchaseProduct(Product_ID:number,Product_Quantity:number)
{
    ProductArr.filter((Product,index,Array)=>
    {
        if(Product.ProductId==Product_ID)
        {
            if(Product_Quantity<=Product.ProductQuantity)
            {
                Product.ProductQuantity=Product.ProductQuantity-Product_Quantity;
                console.log("Thank You For Purchasing Product..");
                CheckQuantity();
            }
            else
            {
                console.log("Product Quantity is very Less..");                
            }
        }
    }
    );
}

// For Reorder Inventory Product
function Reorder(Product_ID:number,Product_Quantity:number)
{
    ProductArr.filter((Product,index,array)=>{
        if(Product.ProductId==Product_ID)
        {
            Product.ProductQuantity=Product.ProductQuantity+Product_Quantity;
            Product.IsAvailable=true;
            console.log(`Your Product ${Product.ProductName} Is Reorder Successfullly`);            
        }
    });
}

// For Check Product Quantity
function CheckQuantity()
{
    ProductArr.filter((Product,index,array)=>{
        if(Product.ProductQuantity==0)
        {
            Product.IsAvailable=false;
            Reorder(Product.ProductId,5);
        }
        else if(Product.ProductQuantity<5)
        {
            Reorder(Product.ProductId,5);
        }
    });
}

//1.Add Product Inventory Product
//2.Display All Product Details
//3.For Purchase Product
//4.Check ProductQuantity is Less than 5 Or not. If ProductQuantity Lessthan 5 Then Reorder Product
var Choice:number=2;

switch (Choice) {
    case 1:
        var Products:Inventory[]=AddProduct({"ProductId":8,"ProductName":"Biscuit","ProductPrice":10,"ProductQuantity":10,"IsAvailable":true});
        Products.forEach(element => {
            console.log(element);
        });
        break;
    case 2:
        DisplayAllProduct();
        break;
    case 3:
        PurchaseProduct(1,3);
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
