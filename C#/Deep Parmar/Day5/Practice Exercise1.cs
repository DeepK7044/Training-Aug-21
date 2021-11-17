//Create a list which will store 5 student names and then display it search it index number
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Practice_Exercise_1
    {
        static void Main(string[] args)
        {
            string Name;
            List<string> stud_Name = new List<string>();
            Console.WriteLine("Enter How many student name you Want Add in List:");
            int num = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Enter {0} Student Name : ",i+1);
                Name = Console.ReadLine();
                stud_Name.Add(Name);
            }

            for (int i = 0; i < stud_Name.Count; i++)
            {
                Console.WriteLine("{0} Student Name Is : {1}",i+1,stud_Name[i]);
            }

            Console.ReadLine();
        }
    }
}
