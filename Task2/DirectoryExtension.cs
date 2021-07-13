using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task2
{
    public static class DirectoryExtension
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
    }
}
