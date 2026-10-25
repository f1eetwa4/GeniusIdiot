using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary;
using GeniusIdiotConsoleApp;

namespace ClassLibrary
{
    public class QuestionsStorage
    {
        public List<Question> Questions = new List<Question>();
        public QuestionsStorage(string pathQuestions)
        {
            if (!File.Exists(pathQuestions))
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

                    FileSystem.Write(pathQuestions, $"{questions[i]}|{answers[i]}", true);
                }
            }
            else
            {

                string s = FileSystem.Read(pathQuestions);
                string[] ss = s.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in ss)
                {
                    string[] textAndAnswer = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
                    string textQuestion = textAndAnswer[0];
                    string answer = textAndAnswer[1].Trim();
                    Question question = new Question(textQuestion, int.Parse(answer));
                    Questions.Add(question);

                }
            }

        }
        
        public void AddQuestion(string pathQuestions, string textQuestion, int answer)
        {
            FileSystem.Write(pathQuestions, $"{textQuestion}|{answer}", true);

            Question newQuestion = new Question(textQuestion, answer);
            Questions.Add(newQuestion);
        }
        public void RemoveQuestion(string pathQuestions, int input)
        {
            int index = input - 1;
            string questionAndAnswer = $"{Questions[index].QuestionText}|{Questions[index].Answer}";
            FileSystem.Remove(pathQuestions, questionAndAnswer);
            Questions.Remove(Questions[index]);

        }
        
        public static List<Question> GetQuestions(QuestionsStorage questionsStorage)
        {
            var questionsCopy = new List<Question>();
            foreach (var question in questionsStorage.Questions)
            {
                questionsCopy.Add(question);
            }
            return questionsCopy;
        }

    }
}
