using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusIdiot
{
    public class User
    {
        public string FullName { get; set; } = "ФИО неизвестно";
        public int CorrectAnswersCount;
        public string Diagnosis { get; set; } = "Диагноз неизвестен";
        public User(string fullName)
        {
            FullName = fullName;
        }

    }
}
