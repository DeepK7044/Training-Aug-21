using System;
using System.Threading;
using System.Threading.Tasks;

namespace Day9
{
    static class Extension
    {
        public static void func3(this Practice p) //Extension Method
        {
            Console.WriteLine("This is Third Function.. ");
        }

        public static void fun4(this Practice p, string str)
        {
            Console.WriteLine("This is Fourth function.." + str);
        }

        public static bool IsGraterThan(this int i, int value)
        {
            return i > value;
        }
    }
    class Practice
    {
        public static void method1()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(300);
                Console.WriteLine($"sync Method1..{i}");
            }

        }
        public static async Task<int> method2()
        {
            Thread.Sleep(10000);
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(" Method 2");
                    count += 1;
                }
            });
            return count;
        }

        public static void Method3(int count)
        {
            Console.WriteLine("Total count is " + count);
        }

        public static async Task callMethod()
        {
            var count = await method2();
            method1();
            Method3(count);
        }

        public void fun1()
        {
            Console.WriteLine("This is First Method..");
        }
        public void fun2()
        {
            Console.WriteLine("This is Second Method..");
        }
        static async Task Main(string[] args)
        {
            Practice p = new Practice();
            p.fun1();
            p.fun2();

            //Extension Method
            p.func3();
            p.fun4("Created By Deep");

            //Extention Method For .Net Class
            int i = 20;
            bool Result = i.IsGraterThan(10);
            Console.WriteLine(Result);

            Console.WriteLine("----------------------");

            callMethod();

            Console.ReadLine();
        }




    }

}