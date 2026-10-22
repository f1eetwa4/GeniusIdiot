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
        public bool IsCorrectAnswer(string input)
        {
            
            if (int.Parse(input) == Answer)
            {
                return true;
            }

            return false;
        }
    }
}
