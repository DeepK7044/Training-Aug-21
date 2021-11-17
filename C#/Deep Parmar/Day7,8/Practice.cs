using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Day7_8
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }

    public class studentcompare : IEqualityComparer<Student>
    {
        bool IEqualityComparer<Student>.Equals(Student x, Student y)
        {
            if (x.StudentID == y.StudentID && x.StudentName.ToLower() == y.StudentName.ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        int IEqualityComparer<Student>.GetHashCode(Student obj)
        {
            return obj.StudentID.GetHashCode();
        }
    }



    class Practice
    {
        static void Main(string[] args)
        {
            int[] age = { 12, 20, 35, 87, 66, 35, 44, 88, 99 };

            var Age = from i in age where i > 18 orderby i descending select i;
            foreach (int a in Age)
            {
                Console.WriteLine(a);
            }

            //method syntax
            Console.WriteLine("---------------------------------");
            var methodSyntax = age.Where((p) => p > 18);
            foreach (var item in methodSyntax)
            {
                Console.WriteLine(item);
            }

            //Mixed Syntax
            Console.WriteLine("---------------------------------");
            var mixedSyntax = (from item in age
                               orderby age
                               select item).Where((p) => p > 18).Max();

            Console.WriteLine(mixedSyntax);

            Console.WriteLine("---------------------------------");

            //oftype
            ArrayList data = new ArrayList() { 1, "Deep", "Parmar", 21 };
            var OfType = from item in data.OfType<int>() select item;

            foreach (var item in OfType)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------------------------");

            //orderby , OrderByDescending ,ThenBy,ThenByDescending,Reverse
            List<Student> studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 },
            new Student() { StudentID = 6, StudentName = "Ram" , Age = 18 }
            };

            var qt = from std in studentList
                     orderby std.StudentName, std.Age ascending
                     select std;

            var mt = studentList.OrderByDescending(std => std.StudentName).ThenBy(std => std.Age);

            foreach (var stdList in qt)
            {
                Console.WriteLine($"Id = {stdList.StudentID} ,StudentName= {stdList.StudentName} ,Age={stdList.Age}");
            }

            //var qs = (from std in studentList
            //          select std).Reverse();

            //studentList.Reverse();

            var qs = studentList.AsEnumerable().Reverse();

            Console.WriteLine("----------------Reverse-----------------");
            foreach (var stdList in qs)
            {
                Console.WriteLine($"Id = {stdList.StudentID} ,StudentName= {stdList.StudentName} ,Age={stdList.Age}");
            }

            Console.WriteLine("---------------------------------");

            //All, Any & Contains are quantifier operators

            var All = studentList.All(std => std.Age >= 18);

            var std_any = studentList.Any(std => std.Age >= 18);

            var std_Contains = studentList.AsEnumerable().Contains(new Student() { StudentID = 3, StudentName = "Bill" }, new studentcompare());
            //var std_Contains = data.Contains("Deep");


            Console.WriteLine(All);
            Console.WriteLine(std_any);
            Console.WriteLine(std_Contains);

            Console.WriteLine("---------------------------------");

            //Set Operator: Distinct
            List<int> id = new List<int> { 1, 2, 3, 4, 6, 6, 5, 5, 4, 3 };

            List<Student> studentList1 = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 6, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 7, StudentName = "Ron" , Age = 19 },
            new Student() { StudentID = 8, StudentName = "Ram" , Age = 18 }
            };

            //var id_distinct = id.Distinct();
            //foreach (var ID in id_distinct)
            //{
            //    Console.WriteLine(ID);
            //}

            var distinct = studentList1.Distinct(new studentcompare());

            foreach (var std in distinct)
            {
                Console.WriteLine(std.StudentName);
            }

            Console.WriteLine("---------------------------------");
            //LINQ: Except
            List<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            List<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };
            var result = strList1.Except(strList2);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------------------------");

            List<Student> studentList2 = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            List<Student> studentList3 = new List<Student>() {
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            var except = studentList2.Except(studentList3,new studentcompare());

            foreach (var item in except)
            {
                Console.WriteLine(item.StudentName);
            }
            Console.WriteLine("---------------------------------");

            //Set Operator: Intersect


            Console.WriteLine("---------------------------------");
            var result_intersect = strList1.Intersect(strList2);

            foreach (var item in result_intersect)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------------");
            var intersect = studentList2.Intersect(studentList3, new studentcompare());

            foreach (var item in intersect)
            {
                Console.WriteLine(item.StudentName);
            }


            //Set Operator: Union

            Console.WriteLine("---------------------------------");
            var result_union = strList1.Union(strList2);

            foreach (var item in result_union)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------------");
            var union = studentList2.Union(studentList3, new studentcompare());

            foreach (var item in union)
            {
                Console.WriteLine(item.StudentName);
            }

            Console.WriteLine("---------------------------------");
            //Aggregation Operators: Aggregate
            var Aggregate = studentList.Aggregate("Student Name :",
                                                  (str, std) => str += std.StudentName + " , ");


            Console.WriteLine(Aggregate);


            //Avg
            var avgAge = studentList.Average(s => s.Age);

            Console.WriteLine("Average Age of Student: {0}", avgAge);

            //Count
            var adultStudent = studentList.Count(std => std.Age > 18);

            Console.WriteLine("Number of Adult Students: {0}", adultStudent);

            //Max
            var oldest = studentList.Max(s => s.Age);

            Console.WriteLine("Oldest Student Age: {0}", oldest);

            //sum
            var totalAge = studentList.Sum(emp => emp.Age);

            Console.WriteLine("Total Age is : {0}",totalAge);

            Console.WriteLine("---------------------------------");

            //Partitioning Operators: Skip & SkipWhile
            List<string> strList = new List<string>() { "One", "Two", "Three", "Four", "Five" };



            var newList = strList.Skip(2);

            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------------------------");

            var SkipWhile = strList.SkipWhile(str => str.Length <4);

            var skipwhile_index = strList.SkipWhile((str, index) => str.Length > index);

            foreach (var item in SkipWhile)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------------------------");
            foreach (var item in skipwhile_index)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("--------------Take & TakeWhile-------------------");
            //Partitioning Operators: Take & TakeWhile
            var take = strList.Take(2);

            foreach (var item in take)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------------------------");

            var takewhile = strList.TakeWhile(str => str.Length < 4);

            var tackwhile_index = strList.TakeWhile((str, index) => str.Length > index);

            foreach (var item in takewhile)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------------------------");
            foreach (var item in tackwhile_index)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("---------------------------------");

            //Element Operators: ElementAt, ElementAtOrDefault

            List<int> intList1 = new List<int>() { 10, 21, 30, 45, 50, 87 };
            List<string> strList3 = new List<string>() { "One", "Two", null, "Four", "Five" };
            List<string> strList4 = new List<string>() { "Two", "Three", "Four", "Five" };

            Console.WriteLine("1st Element in intList: {0}", intList1.ElementAt(0));
            Console.WriteLine("1st Element in strList: {0}", strList3.ElementAt(0));

            Console.WriteLine("2nd Element in intList: {0}", intList1.ElementAt(1));
            Console.WriteLine("2nd Element in strList: {0}", strList3.ElementAt(1));

            Console.WriteLine("3rd Element in intList: {0}", intList1.ElementAtOrDefault(2));
            Console.WriteLine("3rd Element in strList: {0}", strList3.ElementAtOrDefault(2));

            Console.WriteLine("10th Element in intList: {0} - default int value",
                intList1.ElementAtOrDefault(9));
            Console.WriteLine("10th Element in strList: {0} - default string value (null)",
                             strList3.ElementAtOrDefault(9));

            Console.WriteLine("intList.ElementAt(9) throws an exception: Index out of range");
            Console.WriteLine("-------------------------------------------------------------");
            //Console.WriteLine(intList1.ElementAt(9));

            Console.WriteLine("---------------------------------");
            //Element Operators: First & FirstOrDefault

            List<string> emptyList = new List<string>();

            Console.WriteLine("emptyList.First() throws an InvalidOperationException");
            Console.WriteLine("-------------------------------------------------------------");
            //Console.WriteLine(emptyList.First());

            Console.WriteLine("1st Element in emptyList: {0}", emptyList.FirstOrDefault());

            Console.WriteLine("1st Element in intList: {0}", intList1.FirstOrDefault());
            Console.WriteLine("1st Even Element in intList: {0}",
                                             intList1.FirstOrDefault(i => i % 2 == 0));

            Console.WriteLine("---------------------------------");

            //Element Operators : Last & LastOrDefault

            Console.WriteLine(intList1.Last());

            Console.WriteLine("Last Even Element in intList: {0}", intList1.Last(i => i % 2 == 0));

            Console.WriteLine("Last Element in strList: {0}", strList3.LastOrDefault());

            Console.WriteLine("Last Element in emptyList: {0}", emptyList.LastOrDefault());

            Console.WriteLine(strList4.LastOrDefault(s => s.Contains("T")));
            //Console.WriteLine(strList3.LastOrDefault(s => s.Contains("T"))); // throws an exception

            var qslast = intList1.Where(emp => emp > 150).LastOrDefault();
            Console.WriteLine(qslast);

            Console.WriteLine("---------------------------------");

            //Element Operators: Single & SingleOrDefault

            List<int> oneElementList = new List<int>() { 7 };

            Console.WriteLine(oneElementList.Single());
            //Console.WriteLine(emptyList.Single());
            Console.WriteLine(emptyList.SingleOrDefault());

            //following throws error because list contains more than one element which is less than 100
            //Console.WriteLine("Element less than 100 in intList: {0}", intList1.Single(i => i < 100));

            //following throws error because list contains more than one element which is less than 100
            //Console.WriteLine("Element less than 100 in intList: {0}",
            //                                    intList1.SingleOrDefault(i => i < 100));

            Console.WriteLine("---------------------------------");


            //Deferred Execution
            var teenAgerStudents = from s in studentList
                                   where s.Age > 12 && s.Age < 20
                                   select s;

            //Immediate Execution
            var teenAgerStudents1 = (from s in studentList
                                   where s.Age > 12 && s.Age < 20
                                   select s).ToList();

            Console.WriteLine("---------------------------------");
            //let keyword
            var lowercaseStudentNames = from s in studentList
                                        let lowercaseStudentName = s.StudentName.ToLower()
                                        where lowercaseStudentName.StartsWith("r")
                                        select lowercaseStudentName;

            foreach (var name in lowercaseStudentNames)
            { 
              Console.WriteLine(name);
            }

            Console.WriteLine("--------------into-------------------");
            //LINQ - into Keyword
            var stdData = from std in studentList
                          where std.Age > 18 && std.Age < 26
                          select std into Newstd
                          where Newstd.StudentName.StartsWith("R")
                          select Newstd;

            foreach (var std in stdData)
            {
                Console.WriteLine(std.StudentName);
            }

            Console.ReadLine();
        }
    }
}
