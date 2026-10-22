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
                if (File.Exists(pathResults))
                {
                    Console.WriteLine("Хотите вывести все результаты тестирования?");
                    if (GetUserChoice())
                    {
                        Console.WriteLine(FileSystem.Read(pathResults));
                    }
                }

                Console.WriteLine("Хотите добавить вопрос в тест?");
                if (GetUserChoice())
                {
                    Console.WriteLine("Введите текст вопроса");
                    string textQuestion = Console.ReadLine();
                    while (string.IsNullOrEmpty(textQuestion))
                    {
                        Console.WriteLine("Текст вопроса не может быть пустой строкой");
                        textQuestion = Console.ReadLine();
                    }
                    Console.WriteLine("Введите ответ на вопрос(число)");
                    string answer = Console.ReadLine();
                    while (!IsNumber(answer))
                    {
                        Console.WriteLine("Пожалуйста, введите число!");
                        answer = Console.ReadLine();
                    }
                    questionsStorage.AddQuestion(pathQuestions, textQuestion, int.Parse(answer));
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
                    string text = string.Format("{0, -30} {1, -35} {2, -30}", user.FullName, user.CorrectAnswersCount, user.Diagnosis);
                    FileSystem.Write(pathResults, text, true);


                    Console.Write("Хотите пройти тест снова? ");
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
