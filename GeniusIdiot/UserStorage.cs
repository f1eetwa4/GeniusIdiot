using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusIdiot
{
    public class UserStorage
    {
        public List<User> Users = new List<User>();
        public void Print()
        {
            Console.WriteLine("|| {0,-30} || {1,-30} || {2,-15} ||", "ФИО:", "Количество правильных ответов:", "Диагноз:");
            foreach (User user in Users)
            {
                Console.WriteLine("|| {0,-30} || {1,-30} || {2,-15} ||", user.FullName, user.CorrectAnswersCount, user.Diagnosis);
            }
        }
    }
}
