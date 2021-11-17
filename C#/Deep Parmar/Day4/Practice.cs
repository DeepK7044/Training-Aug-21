using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class CheckAge:Exception
    {
        public CheckAge(string message) : base(message){ }
    }
    class Practice
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a number to divide 100: ");

            try
            {
                int num = int.Parse(Console.ReadLine());

                int result = 100 / num;

                Console.WriteLine("100 / {0} = {1}", num, result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Cannot divide by zero. Please try again.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Not a valid format. Please try again.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred! Please try again.");
            }

            Console.WriteLine("-----------------------------------------");
            try
            {
                Console.WriteLine("Enter Your Age");
                int Age = int.Parse(Console.ReadLine());

                if(Age<18)
                {
                    throw new CheckAge("Please Enter Valid Age");
                }
                else
                {
                    Console.WriteLine("You Are Adult");
                }
            }
            catch (CheckAge msg)
            {
                Console.WriteLine(msg);               
            }

            Console.WriteLine("-------------------------");
            StringBuilder sb = new StringBuilder();
            sb.Append("Hello ");
            sb.AppendLine("World!");
            sb.AppendLine("Hello C#");
            Console.WriteLine(sb);

            Console.WriteLine("-------------------------");

            string str = "This is a \"string\" in C#.";
            string path = @"\\mypc\shared\project";
            string email = @"test@test.com";

            Console.WriteLine(str);
            Console.WriteLine(path);
            Console.WriteLine(email);


            Console.WriteLine("-------------------------");
            //assigns default value 01/01/0001 00:00:00
            DateTime dt1 = DateTime.Now;

            //assigns year, month, day
            DateTime dt2 = new DateTime(2015, 12, 31);

            Console.WriteLine(dt1);
            Console.WriteLine(dt2);

            Console.WriteLine(dt1.ToString("dd/MM/yyyy  h:mm:ss tt"));


            Console.ReadLine();

        }
    }
}
