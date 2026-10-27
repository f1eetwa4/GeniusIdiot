using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibrary
{
    public class UsersResultStorage
    {
        private List<User> UsersResults = new List<User>();
        private string Path = "results.json";
        public void AddResult(User user)
        {
            UsersResults.Add(user);
            Save();
        }
        public void Save()
        {
            var jsonData = JsonConvert.SerializeObject(UsersResults, Formatting.Indented);
            FileSystem.Write(Path, jsonData, false);
        }
        public UsersResultStorage()
        {
            if (File.Exists(Path))
            {
                var resultsInfo = FileSystem.Read(Path);
                UsersResults = JsonConvert.DeserializeObject<List<User>>(resultsInfo) ?? new List<User>();
            }
        }
        public List<User> GetResults()
        {
            var resultsCopy = new List<User>();
            foreach (var result in UsersResults)
            {
                resultsCopy.Add(result);
            }
            return resultsCopy;
        }
        

    }
}

//string s;
//s = string.Format("{0, -30} {1, -35} {2, -30}", "ФИО", "Процент правильных ответов", "Диагноз");
//foreach (var user in Users)
//{
//    s += string.Format("\n{0, -30} {1, -35} {2, -30}", user.FullName, user.Percentage, user.Diagnosis);
//}
//return s;

// изменить для консоли!!
