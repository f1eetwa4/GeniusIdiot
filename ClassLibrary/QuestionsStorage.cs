using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;
using GeniusIdiotConsoleApp;
using Newtonsoft.Json;

namespace ClassLibrary
{
    public class QuestionsStorage
    {
        public List<Question> Questions = new List<Question>();
        private string Path = "questions.json";
        public QuestionsStorage()
        {
            if (!File.Exists(Path))
            {
                string[] questions =
                {
                "Сколько будет 2 плюс 2, умноженное на 2?",
                "Бревно нужно распилить на 10 частей. Сколько надо сделать распилов?",
                "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
                "Укол делают каждые полчаса. Сколько нужно минут для трех уколов?",
                "5 свечей горело, 2 потухли. Сколько свечей осталось?"
                };
                int[] answers = { 6, 9, 25, 60, 5 };

                for (int i = 0; i < questions.Length; i++)
                {
                    Question question = new Question(questions[i], answers[i]);
                    
                    Questions.Add(question);
                }
            }
            else
            {
                var jsonData = FileSystem.Read(Path);
                Questions = JsonConvert.DeserializeObject<List<Question>>(jsonData) ?? new List<Question>();
            }

        }
        
        public void AddQuestion(Question question)
        {
            Questions.Add(question);
            Save();
        }
        public void RemoveQuestion(int input)
        {
            int index = input - 1;
            Questions.RemoveAt(index);
            Save();
        }
        public void Save()
        {
            var jsonData = JsonConvert.SerializeObject(Questions, Formatting.Indented);
            FileSystem.Write(Path, jsonData, false);
        }
        public List<Question> GetQuestions()
        {
            var questionsCopy = new List<Question>();
            foreach (var question in Questions)
            {
                questionsCopy.Add(question);
            }
            return questionsCopy;
        }

    }
}
