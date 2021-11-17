using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public delegate void Calculation(int a, int b);
    public delegate void show();
    public delegate int Area(int a);
    public delegate void myMethod(int a);
    public delegate int Calculation2(int a, int b);


    class Practice
    {

        public static void Addition(int num1, int num2)
        {
            Console.WriteLine("Addition Is : " + (num1 + num2));
        }
        public static void subtraction(int num1, int num2)
        {
            Console.WriteLine("subtraction Is : " + (num1 - num2));
        }
        public static void Multiplication(int num1, int num2)
        {
            Console.WriteLine("Multiplication Is : " + (num1 * num2));
        }
        public static void Division(int num1, int num2)
        {
            Console.WriteLine("Division Is : " + (num1 / num2));
        }

        public static void Show()
        {
            Console.WriteLine("This is Show Method..");
        }

        public static int Square(int num)
        {
            return num * num;
        }
        public static int cube(int num)
        {
            return num * num * num;
        }

        public static void Method(myMethod fun,int a)
        {
            a += 5;
            fun(a);
        }
        static void Main(string[] args)
        {
            //Practice p1 = new Practice();
            //Calculation obj = new Calculation(p1.Addition);
            //obj += p1.subtraction;

            //multicast Delegate it uses Assignment operator
            Calculation obj = new Calculation(Addition);
            obj += subtraction;
            obj += Multiplication;
            obj += Division;

            //obj -= Multiplication;

            obj.Invoke(20, 10);


            //Single Cast Delegate
            show obj2 = new show(Show);
            obj2();

            Area obj3 = new Area(Square);
            Console.WriteLine("Square Is : " + obj3.Invoke(3));

            obj3 = cube;
            int Result = obj3.Invoke(2);
            Console.WriteLine("Cube Is : " + Result);

            //Anonymous Function 
            myMethod obj4 = delegate (int a)
              {
                  a += 10;
                  Console.WriteLine(a);
              };

            obj4.Invoke(4);

            Practice.Method(delegate (int a) { a += 10; Console.WriteLine(a); }, 5);

            //Lambda Expression
            myMethod obj5 = a =>
            {
                a += 10;
                Console.WriteLine("Value is : "+a); //Statement Lambda
            };

            obj5(4);

            Calculation2 obj6= (a,b) => a + b; //Expression Lambda
            Console.WriteLine(obj6(10, 20));

            //Generic Delegates
            //Func,Action,Predicate  Generic Delegate in C# are present in the System namespace.

            //Func
            //The Func Generic Delegate in C# can take up to 16 input parameters of different types. 
            //It must have one return type. The return type is mandatory but the input parameter is not.
            Func<int, int> square = a => a * a;
            Console.WriteLine(square(10));

            //Action
            //It takes one or more input parameters and returns nothing. 
            //This delegate can take a maximum of 16 input parameters of the different or same type
            Action<int> cube_no = a => Console.WriteLine(a*a*a);
            cube_no(3);

            //Predicate
            //It represents a method containing a set of criteria and checks whether the passed parameter meets those criteria.
            //A predicate delegate methods must take one input parameter and return a boolean - true or false.
            Predicate<int> check_age = Age => Age > 18;
            Console.WriteLine(check_age(21));

            Console.ReadLine();

        }
    }
}
