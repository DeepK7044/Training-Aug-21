using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // This namespace use for FileHandling..

namespace File_Handling
{
    class Practice
    {
        static void Main(string[] args)
        {
            string path = @"D:\Daily Work\Training-Aug-21\C#\Deep Parmar\File Handling\Demo.txt";
            string path2 = @"D:\Daily Work\Training-Aug-21\C#\Deep Parmar\File Handling\Demo1.txt";
            string path3 = @"D:\Daily Work\Training-Aug-21\C#\Deep Parmar\File Handling\Demo";
            string path4 = @"D:\Daily Work\Training-Aug-21\C#\Deep Parmar\File Handling\Demo1";

            //File.Copy(path, path2);
            //File.Copy(path, path2, true);

            if (File.Exists(path2))
            {
                Console.WriteLine("File is copy successfully..");
                string data = File.ReadAllText(path);
                string data2 = File.ReadAllText(path2);
                Console.WriteLine(data + "Old File");
                Console.WriteLine(data2 + "Copy File");
            }
            else
            {
                Console.WriteLine("File is Not Found");
            }

            //Directory info

            DirectoryInfo dir = new DirectoryInfo(path3);

            //Directory info Method

            dir.Create();
            dir.CreateSubdirectory("new");
            dir.CreateSubdirectory("new1");
            dir.CreateSubdirectory("new2");
            dir.CreateSubdirectory("new3");

            DirectoryInfo[] dir_arr = dir.GetDirectories();
            foreach (var item in dir_arr)
            {
                Console.WriteLine(item);
                //Console.WriteLine(item.GetFiles().Length);
                //Console.WriteLine(item.Name);
                //Console.WriteLine(item.FullName);
            }

            //Directory info Properties

            Console.WriteLine(dir.Name);
            Console.WriteLine(dir.FullName);
            Console.WriteLine(dir.Parent);
            Console.WriteLine(dir.Root);
            Console.WriteLine(dir.Attributes);
            Console.WriteLine(dir.LastAccessTime);
            Console.WriteLine(dir.LastWriteTime);
            Console.WriteLine(dir.CreationTime);

            //dir.MoveTo(path4);

            //dir.Delete(true);

            //Console.WriteLine("Directory is Created..");
            //Console.WriteLine("subDirectory is Created..");

            using (FileStream fs=new FileStream(path,FileMode.Open,FileAccess.ReadWrite,FileShare.Read))
            {
                fs.WriteByte(65); //A
                //fs.WriteByte(66); //B

                string str = "Welcome to Radixweb..";
                //string str = "Myself Deep Parmar";


                byte[] res = Encoding.UTF8.GetBytes(str);
                fs.Write(res, 0, str.Length);

                Console.WriteLine("File Created successfully..");
                //Console.WriteLine("File Written successfully..");
                //Console.WriteLine("File Truncated successfully..");

                //StreamWriter

                using (StreamWriter writer = new StreamWriter(fs))
                {
                    int[] data = { 10, 11, 12, 13, 14, 15 };
                    char[] data1 = new char[] { 'A', 'B', 'C' };
                    //writer.Write("Hello World !!");
                    writer.WriteLine("Statement no 1");
                    writer.WriteLine("Statement no 2");
                    writer.WriteLine("Statement no 3");
                    foreach (var item in data)
                    {
                        writer.Write(item + " ");
                    }
                    writer.WriteLine();
                    foreach (var item in data1)
                    {
                        writer.Write(item + " ");
                    }
                }

                //StreamReader
                using (StreamReader reader =new StreamReader(fs))
                {

                    if (reader.Peek()>0)
                    {
                        Console.WriteLine("Data is Available..");

                        //string str;
                        //while ((str=reader.ReadLine())!=null)
                        //{
                        //    Console.WriteLine(str);
                        //}

                        //foreach (var item in reader.ReadLine())//Here Readline method fetch one by one char from stream it store in item.
                        //{
                        //    Console.WriteLine(item);
                        //}

                        //Console.WriteLine(reader.ReadLine()); //Readline method fetch one by one char from stream combine it and return as string.

                        string AllLines = reader.ReadToEnd();
                        Console.WriteLine(AllLines);
                    }
                    else
                    {
                        Console.WriteLine("Data is Not Available..");
                    }
                }
                
            }


            Console.ReadLine();
        }
    }
}
