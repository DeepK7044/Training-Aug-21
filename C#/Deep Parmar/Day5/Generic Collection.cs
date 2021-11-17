using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
    }
    class Generic_Collection
    {
        static void Main(string[] args)
        {
            //List

            List<int> age = new List<int>();
            age.Add(40);
            age.Add(10);
            age.Add(20);
            age.Add(50);
            age.Add(30);

            foreach (var Age in age)
            {
                Console.WriteLine(Age);
            }

            //age.Insert(1, 60);
            //age.AddRange(age);
            //age.RemoveRange(4, 6);
            //age.Clear();
            //age.Remove(20);
            //age.RemoveAt(1);
            age.Sort();


            Console.WriteLine("----------------");
            foreach (var Age in age)
            {
                Console.WriteLine(Age);
            }


            Employee emp1 = new Employee()
            {
                ID = 101,
                Name = "Deep",
                Gender = "Male",
                Salary = 30000
            };
            Employee emp2 = new Employee()
            {
                ID = 102,
                Name = "Priyanka",
                Gender = "Female",
                Salary = 30000
            };
            Employee emp3 = new Employee()
            {
                ID = 103,
                Name = "Anurag",
                Gender = "Male",
                Salary = 40000
            };

            //stack

            //Stack<Employee> st_Emp = new Stack<Employee>();
            //st_Emp.Push(emp1);
            //st_Emp.Push(emp2);
            //st_Emp.Push(emp3);

            //foreach (Employee emp in st_Emp)
            //{
            //    Console.WriteLine(emp.ID + " - " + emp.Name + " - " + emp.Gender + " - " + emp.Salary);
            //}

            //st_Emp.Pop();
            ////st_Emp.Clear();

            //Console.WriteLine("----------------------------");
            //foreach (Employee emp in st_Emp)
            //{
            //    Console.WriteLine(emp.ID + " - " + emp.Name + " - " + emp.Gender + " - " + emp.Salary);
            //}
            //Console.WriteLine(st_Emp.Count);

            //Queue
            //Queue<Employee> que_Emp = new Queue<Employee>();
            //que_Emp.Enqueue(emp1);
            //que_Emp.Enqueue(emp2);
            //que_Emp.Enqueue(emp3);

            //foreach (Employee emp in que_Emp)
            //{
            //    Console.WriteLine(emp.ID + " - " + emp.Name + " - " + emp.Gender + " - " + emp.Salary);
            //}

            ////que_Emp.Dequeue();
            //que_Emp.Clear();

            //Console.WriteLine("----------------------------");
            //foreach (Employee emp in que_Emp)
            //{
            //    Console.WriteLine(emp.ID + " - " + emp.Name + " - " + emp.Gender + " - " + emp.Salary);
            //}
            //Console.WriteLine(que_Emp.Count);

            //Dictionary

            Dictionary<string, int> Std_Age = new Dictionary<string, int>();
            Std_Age.Add("Age1", 20);
            Std_Age.Add("Age2", 21);
            Std_Age.Add("Age3", 22);
            Std_Age.Add("Age4", 23);

            foreach (KeyValuePair<string,int> item in Std_Age)
            {
                Console.WriteLine(item.Key+" : "+item.Value);
            }

            //Std_Age.Clear();
            Std_Age.Remove("Age3");
            Console.WriteLine("---------------------");
            foreach (var item in Std_Age.Keys)
            {
                Console.WriteLine(item +" : "+Std_Age[item]);
            }

            Console.ReadLine();


        }
    }
}
