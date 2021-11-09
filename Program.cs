using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SF_8_Results_Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathNewFolder = "C://Users/user/Desktop/Students";
            string pathBinaryFile = "Students.dat";

            Student[] students;

            if (!Directory.Exists(pathNewFolder))
            {
                Directory.CreateDirectory(pathNewFolder);
            }

            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                using (var fs = new FileStream(pathBinaryFile, FileMode.Open))
                {
                    students = (Student[])formatter.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка. " + ex.Message);
            }



            /*Student student = new Student();

            string pathNewFolder = "C://Users/user/Desktop/Students";
            string pathBinaryFile = "Students.dat";

            if (!Directory.Exists(pathNewFolder))
            {
                Directory.CreateDirectory(pathNewFolder);
            }

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(pathBinaryFile, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        //student.Name = reader.ReadString();
                        //student.Group = reader.ReadString();
                        //student.DateOfBirth = DateTime.FromBinary(reader.ReadInt16());
                        //Students.Add(student);
                        //Console.WriteLine($"{student.Name}, {student.Group}, {student.DateOfBirth}");
                        string s1 = reader.ReadString();
                        string s2 = reader.ReadString();
                        DateTime s3 = DateTime.FromBinary(reader.ReadInt32());
                        Console.WriteLine($"{s1}, {s2}, {s3}");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }*/
        }
    }
}