using System;
using System.IO;

namespace Task2
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
                    Console.WriteLine("Директория существует");
                    Console.WriteLine($"Размер папки с вложениями= {DirectoryExtension.DirSize(diSource)}");
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
