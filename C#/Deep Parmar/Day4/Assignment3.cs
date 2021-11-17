//Create a user defined Exception DateException class which will validate date should not be less than the current date. 
//If date is less than current date it should throw an exception.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class DateException:Exception
    {
        public DateException(string message):base(message)
        {

        }
    }
    class DateChecker
    {
        public void DateCheck(DateTime date)
        {
            DateTime dt = DateTime.Now;
            try
            {
                if (date < dt)
                {
                    throw new DateException("Date should not be less than the current date");
                }
                else
                {
                    Console.WriteLine("Thank You ! For Enter Correct Date");
                }
            }
            catch (DateException Excep)
            {
                Console.WriteLine(Excep);                
            }
        }
    }
    class Assignment3
    {
        static void Main(string[] args)
        {
            DateChecker date_obj = new DateChecker();
            Console.WriteLine("Please Enter The Date : ");
            DateTime Date = Convert.ToDateTime(Console.ReadLine());
            date_obj.DateCheck(Date);
            Console.ReadLine();
        }
    }
}
