using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GeniusIdiotConsoleApp
{
    public class UsersResultStorage
    {
        public List<User> Users = new List<User>();
        public static void SaveResult(string pathResults, string text)
        {
            FileSystem.Write(pathResults, text, true);
        }
        public UsersResultStorage(string pathResults)
        {
            if (!File.Exists(pathResults))
            {
                FileSystem.Write(pathResults, "", false);
            }
            else
            {
                string[] ss = FileSystem.Read(pathResults).Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in ss)
                {
                    string[] userResult = s.Split('|');
                    string userName = userResult[0];
                    int userPercentage = int.Parse(userResult[1]);
                    string userDiagnosis = userResult[2];

                    User user = new User(userName, userPercentage, userDiagnosis);
                    Users.Add(user);
                }
            }
        }
        public void PrintResults()
        {
            Console.WriteLine("\n{0, -30} {1, -35} {2, -30}", "ФИО", "Процент правильных ответов", "Диагноз");
            foreach (var user in Users)
            {
                Console.WriteLine("{0, -30} {1, -35} {2, -30}", user.FullName, user.Percentage, user.Diagnosis);
            }
            Console.WriteLine();
        }

    }
}
