using System.IO;

namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string pathResults = @"results.txt";
            UsersResultStorage userStorage = new UsersResultStorage(pathResults);

            string pathQuestions = @"questions.txt";
            QuestionsStorage questionsStorage = new QuestionsStorage(pathQuestions);


            while (true)
            {
                questionsStorage.Shuffle();

                if (userStorage.Users.Count != 0)
                {
                    Console.WriteLine("Хотите вывести все результаты тестирования?");
                    if (GetUserChoice())
                    {
                        userStorage.PrintResults();
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

                    int userAnswer = GetUserAnswer();

                    if (question.IsCorrectAnswer(userAnswer))
                    {
                        correctAnswersCount++;
                    }
                }


                double percentage = Math.Round((double)correctAnswersCount * 100 / questions.Count);
                Console.WriteLine($"\nПроцент правильных ответов: {percentage}%");

                string diagnosis = MakeDiagnosis(percentage);
                Console.WriteLine($"{fullname}, ваш диагноз: {diagnosis}");

                User user = new User(fullname, percentage, diagnosis);
                userStorage.Users.Add(user);

                string text = $"{user.FullName}|{user.Percentage}|{user.Diagnosis}";
                UsersResultStorage.SaveResult(pathResults, text);

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

        public static int GetUserAnswer()
        {
            while (true)
            {
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Пожалуйста, введите число!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Число слишком большое! Пожалуйста, введите число повторно!");
                }
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
