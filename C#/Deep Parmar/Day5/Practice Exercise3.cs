//3.Store a product information in map object. Key will be a product item and value will be the price of that product. 
//Search the product by product name.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Practice_Exercise_3
    {
        static void Main(string[] args)
        {
            string Product_Name;
            int Product_Price;
            Dictionary<string, int> Product = new Dictionary<string, int>();
            Console.WriteLine("Please Enter How Many Product You want Add");
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                Console.Write("Enter {0} Product Name : ", i + 1);
                Product_Name = Console.ReadLine();
                Console.Write("Enter {0} Product Price : ",i+1);
                Product_Price = int.Parse(Console.ReadLine());
                Product.Add(Product_Name.ToLower(), Product_Price);
                Console.WriteLine("--------------------------\n");
            }

            Console.WriteLine("--------Product List--------");
            Console.WriteLine("Product Name : Product Price");
            foreach (var key in Product.Keys)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine(key+ " : " + Product[key]);
            }

            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("If You Find Perticular Product Price Then Press Yes Otherwise Press No");
            string Choice = Console.ReadLine();
            if(Choice.ToLower()=="yes")
            {
                Console.Write("Please Enter Product Name That You Want To Search Their Price :");
                string Productname = Console.ReadLine();
                int Productprice;

                //Here i use TryGetValue() method for finding Perticular Product Price

                if (Product.TryGetValue(Productname,out Productprice))
                {
                    Console.WriteLine("{0} Price Is : {1}",Productname,Productprice);
                }
                else
                {
                    Console.WriteLine("Product Is Not Available");
                }
            }

            Console.ReadLine();
        }
    }
}
