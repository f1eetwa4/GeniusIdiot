using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class User
    {
        public string FullName { get; set; } 
        public double Percentage { get; set; }
        public string Diagnosis { get; set; }
        public int CorrectAnswersCount { get; set; }
        public User() : this("ФИО неизвестно", 0, "Диагноз неизвестен")
        {}
        public User(string fullName, double percentage, string diagnosis)
        {
            FullName = fullName;
            Percentage = percentage;
            Diagnosis = diagnosis;
        }
        public void IncreaseCorrectAnswersCount()
        {
            CorrectAnswersCount++;
        }
    }
}
