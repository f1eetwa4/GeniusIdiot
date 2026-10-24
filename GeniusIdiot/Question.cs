using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusIdiotConsoleApp
{
    public class Question
    {
        public string QuestionText { get; set; } = "Вопрос не задан";
        public int Answer { get; set; }
        public Question(string questionText, int answer)
        {
            QuestionText = questionText;
            Answer = answer;
        }
        public bool IsCorrectAnswer(int input)
        {
            
            if (input == Answer)
            {
                return true;
            }

            return false;
        }
    }
}
