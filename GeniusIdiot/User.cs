using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusIdiotConsoleApp
{
    public class User
    {
        public string FullName { get; set; } = "ФИО неизвестно";
        public int CorrectAnswersCount { get; private set;}
        public string Diagnosis { get; set; } = "Диагноз неизвестен";
        public User(string fullName)
        {
            FullName = fullName;
        }
        public void IncreaseCorrectAnswersCount()
        {
            CorrectAnswersCount++;
        }
    }
}
