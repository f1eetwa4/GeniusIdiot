using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusIdiotConsoleApp
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

        public void AddQuestion(string pathQuestions)
        {
            PrintQuestions();

            Console.WriteLine("Введите текст вопроса");
            string textQuestion = Program.GetCorrectInput();
            Console.WriteLine("Введите ответ на вопрос(число)");
            string answer = Console.ReadLine();
            while (!Program.IsNumber(answer))
            {
                Console.WriteLine("Пожалуйста, введите число!");
                answer = Console.ReadLine();
            }

            FileSystem.Write(pathQuestions, $"{textQuestion}|{answer}", true);

            Question newQuestion = new Question(textQuestion, int.Parse(answer));
            Questions.Add(newQuestion);
        }
        public void RemoveQuestion(string pathQuestions)
        {
            string input;
            while (true)
            {
                Console.WriteLine("\nВведите номер вопроса, который хотите удалить");
                PrintQuestions();
                input = Program.GetCorrectInput();
                if (Program.IsNumber(input))
                {
                    int index1 = int.Parse(input) - 1;
                    if (index1 < 0 || index1 > Questions.Count - 1)
                    {
                        Console.WriteLine("Не существует вопроса с таким номером.");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }
            int index = int.Parse(input) - 1;
            string questionAndAnswer = $"{Questions[index].QuestionText}|{Questions[index].Answer}";
            FileSystem.Remove(pathQuestions, questionAndAnswer);
            Questions.Remove(Questions[index]);

        }
        public void PrintQuestions()
        {
            Console.WriteLine("Список вопросов:");
            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {Questions[i].QuestionText}");
            }
        }

    }
}
