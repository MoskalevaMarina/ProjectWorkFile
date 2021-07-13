using System;
using System.IO;
using System.Linq;

namespace Task1
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
                    DirectoryExtension.DelDirect(diSource); //   Вызов метода удаления
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
