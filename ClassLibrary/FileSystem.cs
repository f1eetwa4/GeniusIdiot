using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClassLibrary
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
        public static string Read(string path)
        {
            string s;
            using (StreamReader sr = new StreamReader(path))
            {
                s = sr.ReadToEnd();
            }
            return s;
        }
        public static void Remove(string path, string strToRemove)
        {
            string s = Read(path);
            List<string> ss = s.Split(new[] { "\r\n", "\n" },StringSplitOptions.RemoveEmptyEntries).ToList();
            ss.Remove(strToRemove);
            string data = string.Join("\r\n", ss);
            Write(path, data, false);
        }
    }
}
