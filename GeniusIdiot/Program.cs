using System.IO;

namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UsersResultStorage userStorage = new UsersResultStorage();

            string pathResults = @"results.txt";
            string pathQuestions = @"questions.txt";

            QuestionsStorage questionsStorage = new QuestionsStorage(pathQuestions);


            while (true)
            {
                questionsStorage.Shuffle();

                if (File.Exists(pathResults))
                {
                    Console.WriteLine("Хотите вывести все результаты тестирования?");
                    if (GetUserChoice())
                    {
                        Console.WriteLine("\n{0, -30} {1, -35} {2, -30}", "ФИО", "Процент правильных ответов", "Диагноз");
                        Console.WriteLine(FileSystem.Read(pathResults));
                    }
                }

                Console.WriteLine($"Хотите добавить вопрос в тест?");
                if (GetUserChoice())
                {
                    questionsStorage.AddQuestion(pathQuestions);
                }

                Console.WriteLine("\nХотите удалить какой-либо вопрос из теста?");
                if (GetUserChoice())
                {
                    questionsStorage.RemoveQuestion(pathQuestions);
                }

                Console.WriteLine("\nПожалуйста, введите ваше ФИО");
                string fullname = GetCorrectInput();

                int correctAnswersCount = 0;

                List<Question> questions = questionsStorage.Questions;

                for (int i = 0; i < questions.Count; i++)
                {
                    Question question = questions[i];

                    Console.WriteLine($"\n{question.QuestionText}");
                    Console.Write("Ваш ответ: ");

                    string userAnswer = Console.ReadLine();

                    while (!IsNumber(userAnswer))
                    {
                        Console.WriteLine("Пожалуйста, введите число!");
                        userAnswer = Console.ReadLine();
                    }

                    if (question.IsCorrectAnswer(userAnswer))
                    {
                        correctAnswersCount++;
                    }
                }


                double percentage = (double)correctAnswersCount * 100 / questions.Count;
                Console.WriteLine($"\nПроцент правильных ответов: {percentage}%");

                string diagnosis = MakeDiagnosis(percentage);
                Console.WriteLine($"{fullname}, ваш диагноз: {diagnosis}");

                User user = new User(fullname, percentage, diagnosis);
                userStorage.Users.Add(user);

                string text = string.Format("{0, -30} {1, -35} {2, -30}", user.FullName, user.Percentage, user.Diagnosis);
                FileSystem.Write(pathResults, text, true);

                Console.Write("\nХотите пройти тест снова? ");
                if (!GetUserChoice())
                {
                    break;
                }

                Console.Clear();

            }



        }

        public static string GetCorrectInput()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Неверный ввод! Попробуйте еще раз");
                input = Console.ReadLine();
            }
            return input;
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


    }
}
