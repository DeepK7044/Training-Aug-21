//Create a user defined Exception Class AgeException. If Age is less than 0 it should be thrown an exception. And you need to handle that exception in student class.
//Note to create a user defined exception class you need to derive it from System.Exception class.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    //Create Custom Exception Class AgeException
    class AgeException : Exception
    {
        public AgeException(string message) : base(message)
        {
        }
    }

    //Handle that exception in student class.
    class student
    {
        public void AgeCheck(int age)
        {
            //if Age is LessThan 0 Then It Throw Custom Exception
            try
            {
                if (age < 0)
                {
                    throw new AgeException("Age is Not a Less Than 0");
                }
                else
                {
                    Console.WriteLine("You Enter right Age");
                }
            }
            catch (AgeException Exep)
            {
                Console.WriteLine(Exep.Message);
            }
            

        }
    }
        
   
    class Assignment1
    {
        static void Main(string[] args)
        {
            student stu_obj = new student();
            Console.WriteLine("Please Enter Your Age");
            int Age = int.Parse(Console.ReadLine());
            stu_obj.AgeCheck(Age);
            Console.ReadLine();
        }
    }
}
