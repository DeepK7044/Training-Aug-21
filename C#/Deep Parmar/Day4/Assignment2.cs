//Create a user defined exception class NameException which will validate a Name and 
//name should contain only character. If name does not contain proper value it should throw an exception. 
//You need to handle exception in student class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class NameException:Exception
    {
        public NameException(string message) : base(message)
        {

        }
    }
    class students
    {
        public void NameCheck(string Name)
        {
            try
            {
                if (string.IsNullOrEmpty(Name))
                {
                    throw new NameException("Please Enter Name");
                }
                else
                {
                    for (int i = 0; i < Name.Length; i++)
                    {
                        if (Char.IsDigit(Name[i]))
                        {
                            throw new NameException("Name should contain only character");
                        }
                    }
                    Console.WriteLine("Thank You ! For Enter Correct Name");
                }
            }
            catch (NameException Excep)
            {
                Console.WriteLine(Excep);
            }
        }
    }
    class Assignment2
    {
        static void Main(string[] args)
        {
            students std_obj = new students();
            Console.WriteLine("Please Enter Your Name");
            string std_Name = Console.ReadLine();
            std_obj.NameCheck(std_Name);
            Console.ReadLine();
        }
    }
}
