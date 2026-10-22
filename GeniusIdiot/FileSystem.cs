using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GeniusIdiotConsoleApp
{
    public static class FileSystem
    {
        public static void Write(string path, string text, bool append)
        {
            using (StreamWriter sw = new StreamWriter(path, append, System.Text.Encoding.Default))
            {
                sw.WriteLine(text);
            }
        }
        public static void Read(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
    }
}
