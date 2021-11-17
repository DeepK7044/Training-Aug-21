//Create a stack which will store Age of person and display it last in first out order.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Day5
{

    class Practice
    {
        static void Main(string[] args)
        {
            int Age;
            Console.WriteLine("Enter How many person Age You Want To Store");
            int num = int.Parse(Console.ReadLine());

            Stack<int> st = new Stack<int>();

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Enter {0} person Age", i + 1);
                Age = int.Parse(Console.ReadLine());
                st.Push(Age);
            }
            Console.WriteLine("Employee Age is:");
            int count = st.Count;
            foreach (Object age in st)
            {
                Console.WriteLine("{0} person age is : {1}",count,age);
                count--;
            }
            Console.ReadLine();
        }
    }
}
