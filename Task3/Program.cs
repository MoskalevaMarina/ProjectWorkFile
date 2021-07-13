using System;
using System.IO;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите директорию");
                string dirName = Console.ReadLine();

                DirectoryInfo diSource = new DirectoryInfo(dirName);
                if (diSource.Exists)
                {
                    Console.WriteLine($"Размер директории до очистки = { DirectoryExtension.DirSize(diSource)}");
                    Console.WriteLine("Очистка директории");
                    var p = DirectoryExtension.DelDirect(diSource); //   Вызов метода удаления

                    Console.WriteLine($"Кол. удаленных файлов= {p.kolFiles}, колич. удаленных папок ={p.kolDir}, освобождено места= {p.space}");
                    Console.WriteLine($"Размер директории после очистки = { DirectoryExtension.DirSize(diSource)}");
                }
                else { Console.WriteLine("Нет такой директории"); }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
