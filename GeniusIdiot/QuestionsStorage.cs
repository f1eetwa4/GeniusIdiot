using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusIdiotConsoleApp
{
    public class QuestionsStorage
    {
        public List<Question> Questions = new List<Question>();
        public void Shuffle()
        {
            Random random = new Random();

            for (int i = Questions.Count - 1; i >= 1; i--)
            {
                int index = random.Next(0, i);

                Question questionTemp = Questions[i];
                Questions[i] = Questions[index];
                Questions[index] = questionTemp;
            }
        }
    }
}
