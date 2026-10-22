using System.IO;

namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UsersResultStorage userStorage = new UsersResultStorage();

            QuestionsStorage questionsStorage = CreateQuestionsAndAnswers();

            string path = @"results.txt";
            
            while (true)
            {
                FileInfo fileInfo = new FileInfo(path);

                if (fileInfo.Exists && File.ReadAllText(path).Length > 0)
                {
                    Console.WriteLine("Хотите вывести все результаты тестирования?");
                    if (GetUserChoice())
                    {
                        PrintResults(path);
                    }
                }

                Console.WriteLine("Пожалуйса, введите ваше ФИО");
                string fullname = Console.ReadLine();
                while (string.IsNullOrEmpty(fullname))
                {
                    Console.WriteLine("ФИО не может быть пустым! Введите ФИО еще раз");
                    fullname = Console.ReadLine();
                }

                if (!string.IsNullOrEmpty(fullname))
                {
                    User user = new User(fullname);

                    questionsStorage.Shuffle();

                    List<Question> questions = questionsStorage.Questions;

                    for (int i = 0; i < questions.Count; i++)
                    {
                        Question question = questions[i];

                        Console.WriteLine(question.QuestionText);
                        Console.Write("Ваш ответ: ");

                        string userAnswer = Console.ReadLine();

                        while (!IsNumber(userAnswer))
                        {
                            Console.WriteLine("Пожалуйста, введите число!");
                            userAnswer = Console.ReadLine();
                        }

                        if (question.IsCorrectAnswer(userAnswer))
                        {
                            user.IncreaseCorrectAnswersCount();
                        }
                    }

                    Console.WriteLine();

                    Console.WriteLine($"Количество правильных ответов: {user.CorrectAnswersCount}");

                    double percentage = (double)user.CorrectAnswersCount * 100 / questions.Count;

                    string diagnosis = MakeDiagnosis(percentage);
                    user.Diagnosis = diagnosis;
                    Console.WriteLine($"{fullname}, ваш диагноз: {diagnosis}");

                    userStorage.Users.Add(user);
                    WriteResultsToFile(path, user);

                    Console.Write("Хотите пройти тест снова?");
                    if (!GetUserChoice())
                    {
                        break;
                    }

                    Console.WriteLine();
                }
            }



        }

        
        public static bool IsNumber(string input)
        {

            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            else
            {
                foreach (char c in input)
                {
                    if (c < '0' || c > '9')
                    {
                        return false;
                    }
                }
                return true;
            }


        }

        static QuestionsStorage CreateQuestionsAndAnswers()
        {
            QuestionsStorage questionsStorage = new QuestionsStorage();

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
                Question question1 = new Question(questions[i], answers[i]);
                questionsStorage.Questions.Add(question1);
            }

            return questionsStorage;
        }

        static string MakeDiagnosis(double percentage)
        {
            switch (percentage)
            {
                case 0: return "Идиот";
                case <= 20: return "Кретин";
                case <= 40: return "Дурак";
                case <= 60: return "Нормальный";
                case <= 80: return "Талант";
                case <= 100: return "Гений";
                default: return "Ошибка";
            }
        }
        static bool GetUserChoice()
        {
            while (true)
            {
                Console.WriteLine("Введите Да или Нет");
                string input = Console.ReadLine().ToLower();
                if (!string.IsNullOrEmpty(input))
                {
                    if (input == "да")
                    {
                        return true;

                    }
                    else if (input == "нет")
                    {
                        return false;
                    }
                }
            }
        }
        static void WriteResultsToFile(string writePath, User user)
        {

            string text = string.Format("{0, -30} {1, -35} {2, -30}", user.FullName, user.CorrectAnswersCount, user.Diagnosis);
            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(text);
            }

        }
        static void PrintResults(string path)
        {
            Console.WriteLine("{0, -30} {1, -35} {2, -30}", "ФИО:", "Количество правильных ответов:", "Диагноз:");
            using (StreamReader sr = new StreamReader(path))
            {
                Console.WriteLine(sr.ReadToEnd());
            }

        }
    }
}
