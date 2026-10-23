using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusIdiotConsoleApp
{
    public class User
    {
        public string FullName { get; set; } = "ФИО неизвестно";
        public double Percentage { get; set; }
        public string Diagnosis { get; set; } = "Диагноз неизвестен";
        public User(string fullName, double percentage, string diagnosis)
        {
            FullName = fullName;
            Percentage = percentage;
            Diagnosis = diagnosis;
        }
    }
}
