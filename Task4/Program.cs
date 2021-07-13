using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Reflection;
using System.Linq;

namespace FinalTask
{

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string dirName = @"c:\Users\User\Desktop\Students";
                string fileName = "Students.dat";
                //создание директории Students
                SozdDirectorii(dirName);
                //формирование массива студентов при помощи десериализации бинарного файла
                Student[] mas = Deserialize(fileName);
                //группировка по группам
                var studentGroups = mas.GroupBy(p => p.Group);

                foreach (IGrouping<string, Student> g in studentGroups)
                {
                    string d = dirName + "/" + g.Key + ".txt";
                    var fileInfo = new FileInfo(d);
                    fileInfo.Delete();

                    using (StreamWriter sw = fileInfo.CreateText())
                    {
                        Console.WriteLine($" Файл для групы {g.Key} создан");
                        foreach (var t in g)
                        {
                            sw.WriteLine($"Имя: {t.Name}, Дата рождения: {t.DateOfBirth.ToShortDateString()}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static Student[] Deserialize(string filename)
        {
            Student[] deserilizePeople = null;

            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                deserilizePeople = (Student[])formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Ошибка при десериализации: " + e.Message);
                Console.ReadKey();
                throw;
            }
            finally
            {
                fs.Close();
            }
            return deserilizePeople;
        }

        static void SozdDirectorii(string dirName)
        {
            DirectoryInfo diSource = new DirectoryInfo(dirName);
            if (!diSource.Exists)
            {
                diSource.Create();
                Console.WriteLine("Директория Students создана");
            }
            else
            {
                Console.WriteLine("Директория Students уже существует");
            }
        }
    }
}


