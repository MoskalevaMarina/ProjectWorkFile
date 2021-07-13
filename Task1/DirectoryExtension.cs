using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Task1
{
    class DirectoryExtension
    {
        public static void DelDirect(DirectoryInfo d)
        {
            FileInfo[] fls = d.GetFiles();
            foreach (FileInfo item in fls.Where(dd => DateTime.Now.Subtract(dd.LastWriteTime) > TimeSpan.FromMinutes(30)))
            {
                Console.WriteLine($"файл {item.FullName} удален");
                item.Delete();
            }

            DirectoryInfo[] dis = d.GetDirectories();

            foreach (DirectoryInfo item in dis)
            {
                if (DateTime.Now.Subtract(item.LastAccessTime) > TimeSpan.FromMinutes(30))
                {
                    Console.WriteLine($"каталог со всем содержимым {item.FullName} удален ");
                    item.Delete(true);
                }
                else DelDirect(item);
            }
        }
    }
}
