using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Task3
{
    class DirectoryExtension
    {
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            FileInfo[] fls = d.GetFiles();
            foreach (FileInfo item in fls)
            {
                size += item.Length;
            }

            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo item in dis)
            {
                size += DirSize(item);
            }
            return size;
        }

        public static (int kolFiles, int kolDir, long space) DelDirect(DirectoryInfo d)
        {
            (int kolFiles, int kolDir, long space) znach = (kolFiles: 0, kolDir: 0, space: 0);

            FileInfo[] fls = d.GetFiles();
            foreach (FileInfo item in fls.Where(dd => DateTime.Now.Subtract(dd.LastWriteTime) > TimeSpan.FromMinutes(30)))
            {
                Console.WriteLine($"файл {item.FullName} удален");
                znach.kolFiles++;
                znach.space += item.Length;
                item.Delete();
            }

            DirectoryInfo[] dis = d.GetDirectories();

            foreach (DirectoryInfo item in dis)
            {
                if (DateTime.Now.Subtract(item.LastAccessTime) > TimeSpan.FromMinutes(30))
                {
                    Console.WriteLine($"каталог со всем содержимым {item.FullName} удален ");
                    znach.kolDir++;
                    znach.space += DirectoryExtension.DirSize(item);
                    item.Delete(true);
                }
                else
                {
                    var kk = DelDirect(item);
                    znach.kolFiles += kk.kolFiles;
                    znach.kolDir += kk.kolDir;
                    znach.space += kk.space;
                }
            }
            return znach;
        }
    }
}
