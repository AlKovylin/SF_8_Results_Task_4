using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathFolder = "D://Students";
            string pathBinaryFile = "Students.dat";
            BinaryFormatter formatter = new BinaryFormatter();

            Student[] students = ReadBinaryFile(pathBinaryFile, formatter);
            List<string> NameGroup = ReadNameGroup(students);

            CreateFolder(pathFolder);
            CreateFileList(pathFolder, students, NameGroup, formatter);
        }

        /// <summary>
        /// Создаёт файлы для каждой группы студентов и записывает их имена и дни рождения.
        /// Выводит в консоль результат работы.
        /// </summary>
        /// <param name="pathFolder"></param>
        /// <param name="students"></param>
        /// <param name="nameGroup"></param>
        /// <param name="formatter"></param>
        private static void CreateFileList(string pathFolder, Student[] students, List<string> nameGroup, BinaryFormatter formatter)
        {
            try
            {
                for (int i = 0; i < nameGroup.Count; i++)
                {
                    string pathFile = pathFolder + "/ListGroup_" + nameGroup[i] + ".txt";

                    if (File.Exists(pathFile))
                        File.Delete(pathFile);

                    Console.WriteLine($"Создан файл: {pathFile}");
                    Console.WriteLine($"\n\tСписок группы № {nameGroup[i]}\n");
                    Console.WriteLine(" -------------------------------------");
                    Console.WriteLine("| №  |    Имя    |    День рождения   |");
                    Console.WriteLine(" -------------------------------------");

                    using (StreamWriter sw = new StreamWriter(File.Open(pathFile, FileMode.Append)))
                    {
                        int numPP = 1;

                        for (int y = 0; y < students.Length; y++)
                        {
                            if (students[y].Group == nameGroup[i])
                            {
                                sw.WriteLine(students[y].Name + ", " + students[y].DateOfBirth);
                                Console.WriteLine("| {0, -3}| {1, -10}| {2, -19}|", numPP + ".", students[y].Name, students[y].DateOfBirth);
                                numPP++;
                            }
                        }
                    }
                    Console.WriteLine(" -------------------------------------");
                    Console.WriteLine("\n");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("CreateFileList: " + ex.Message);
            }
        }

        /// <summary>
        /// Создаёт новую папку.
        /// </summary>
        /// <param name="pathFolder"></param>
        private static void CreateFolder(string pathFolder)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(pathFolder);

                if (!di.Exists)//если папки нет, то создаём
                    di.Create();
            }
            catch(Exception ex)
            {
                Console.WriteLine("CreateFolder: " + ex.Message);
            }
        }

        /// <summary>
        /// Формирует список уникальных значений номеров групп студентов.
        /// </summary>
        /// <param name="students"></param>
        /// <returns>List</returns>
        private static List<string> ReadNameGroup(Student[] students)
        {
            List<string> NameGroup = new List<string>();

            foreach (var st in students)
            {
                bool flag = false;

                for (int i = 0; i < NameGroup.Count; i++)
                {
                    if (st.Group == NameGroup[i])
                        flag = true;
                }

                if (!flag)
                    NameGroup.Add(st.Group);
            }
            NameGroup.Sort();
            return NameGroup;
        }

        /// <summary>
        /// Десериализует бинарный файл в массив типов Student.
        /// </summary>
        /// <param name="pathBinaryFile">путь к файлу</param>
        /// <param name="formatter"></param>
        /// <returns>Student[]</returns>
        private static Student[] ReadBinaryFile(string pathBinaryFile, BinaryFormatter formatter)
        {
            Student[] students = new Student[50];
            BinaryFormatter formatter_ = formatter;

            if (File.Exists(pathBinaryFile))//проверяем наличие файла
            {
                try
                {
                    using (FileStream fs = new FileStream(pathBinaryFile, FileMode.Open))
                    {
                        students = (Student[])formatter_.Deserialize(fs);//читаем в массив
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ReadBinaryFile: " + ex.Message);
                }
            }
            else
            {
                throw new FileNotFoundException("По указанному пути файл отсутствует.");
            }
            return students;
        }
    }
}