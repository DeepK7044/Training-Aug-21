using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace NonGeneric_Collection
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }

        //public override string ToString()
        //{
        //    return ($"Id is : {Id} Name is : {Name} Designation is : {Designation}");
        //}

        public void display()
        {
            Console.WriteLine($"Id is : {Id} Name is : {Name} Designation is : {Designation}");
        }

    }
    class NonGeneric_Collection
    {
        static void Main(string[] args)
        {
            Hashtable Person = new Hashtable();
            Person.Add("Name", "Deep");
            Person.Add("Age", 21);
            Person.Add("married", false);

            foreach (var person in Person.Keys)
            {
                Console.WriteLine(person +" : "+ Person[person]);
            }

            Person.Remove("Age");
            Console.WriteLine("Age".GetHashCode());

            //Person.Clear();
            Console.WriteLine("--------------------");
            foreach (var person in Person.Keys)
            {
                Console.WriteLine(person + " : " + Person[person]);
            }

            Employee emp1 = new Employee()
            {
                Id = 7044,
                Name = "Deep",
                Designation = ".Net Developer"
            };
            Employee emp2 = new Employee()
            {
                Id = 8014,
                Name = "Dhruvesh",
                Designation = "Java Developer"
            };

            //Stack

            Stack st = new Stack();
            st.Push(emp1);
            st.Push(emp2);

            foreach (Employee Emp in st)
            {
                //Console.WriteLine(Emp);
                Emp.display();
            }

            var obj = (Employee)st.Peek();
            obj.display();
            Console.WriteLine(st.Count);

            //Queue

            Queue que = new Queue();
            que.Enqueue(emp1);
            que.Enqueue(emp2);

            foreach (Employee Emp in que)
            {
                //Console.WriteLine(Emp);
                Emp.display();
            }

            var obj1 = (Employee)que.Peek();
            obj1.display();
            Console.WriteLine(que.Count);
            que.Dequeue();
            foreach (Employee Emp in que)
            {
                //Console.WriteLine(Emp);
                Emp.display();
            }

            //ArrayList
            ArrayList Student = new ArrayList();
            Student.Add("Deep");
            Student.Add(44);
            Student.Add("A1");
            Student.Add(true);

            Console.WriteLine(Student.Count);
            Console.WriteLine(Student.Capacity); //capacity 4
            Student.Add('D');
            Student.Add('D');
            Student.Add('D');
            Student.Add('D');

            Console.WriteLine(Student.Capacity); //capacity 8
            Student.Add('D');
            Console.WriteLine(Student.Capacity); //capacity 16

            foreach (var std in Student)
            {
                Console.WriteLine(std);
            }

            Student.Remove('D');
            //Student.RemoveAt(3);
            //Student.Clear();
            Console.WriteLine("----------------------------------");
            foreach (var std in Student)
            {
                Console.WriteLine(std);
            }


            Console.ReadLine();

        }
    }
}
