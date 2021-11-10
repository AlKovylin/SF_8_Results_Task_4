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
            //string pathFolder = "C://Users/user/Desktop/Students";
            string pathFolder = "D://Students";
            string pathBinaryFile = "Students.dat";
            BinaryFormatter formatter = new BinaryFormatter();
            Student[] students = new Student[50];

            if (File.Exists(pathBinaryFile))//проверяем наличие файла
            {
                try
                {
                    using (FileStream fs = new FileStream(pathBinaryFile, FileMode.Open))
                    {
                        students = (Student[])formatter.Deserialize(fs);//читаем в массив
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("FileStream: " + ex.Message);
                }
            }
            else
            {
                throw new FileNotFoundException("По указанному пути файл отсутствует.");
            }

            //формируем список групп 
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

            DirectoryInfo di = new DirectoryInfo(pathFolder);

            if (!di.Exists)//если папки нет, то создаём
                di.Create();

            //создадим файлы для каждой группы
            for (int i = 0; i < NameGroup.Count; i++)
            {
                string pathFile = pathFolder + "/ListGroup_" + NameGroup[i] + ".txt";

                if (File.Exists(pathFile))
                    File.Create(pathFile);
                else
                    File.Delete(pathFile);

                //добавим в него необходимые данные
                foreach (var st in students)
                {
                    if (st.Group == NameGroup[i])
                    {
                        try
                        {
                            using (StreamWriter sw = new StreamWriter(File.Open(pathFile, FileMode.Append)))
                            {
                                sw.WriteLine(st.Name + ", " + st.DateOfBirth);
                                sw.Close();
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Запись данных в файл: " + ex.Message);
                        }
                    }
                }
            }
            foreach (var s in students)
            {
                Console.WriteLine($"Имя: {s.Name}, Группа: {s.Group}, ДР: {s.DateOfBirth}");
            }

            Console.WriteLine("Группы: ");
            for (int i = 0; i < NameGroup.Count; i++)
            {

                Console.WriteLine(NameGroup[i]);
            }
        }
    }
}