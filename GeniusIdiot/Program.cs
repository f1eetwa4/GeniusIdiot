using ClassLibrary;
using System.IO;

namespace GeniusIdiotConsoleApp
{
    class Program 
    {
        static void Main(string[] args)
        {

            string pathResults = @"results.txt";
            UsersResultStorage userStorage = new UsersResultStorage(pathResults);

            string pathQuestions = @"questions.txt";
            QuestionsStorage questionsStorage = new QuestionsStorage(pathQuestions);


            while (true)
            {
                User user = new User();

                if (userStorage.Users.Count != 0)
                {
                    Console.WriteLine("Хотите вывести все результаты тестирования?");
                    if (InputChecker.GetUserChoice())
                    {
                        string results = userStorage.GetResults();
                        Console.WriteLine(results);
                    }
                }

                Console.WriteLine($"Хотите добавить вопрос в тест?");
                if (InputChecker.GetUserChoice())
                {
                    var allQuestions = questionsStorage.Questions;
                    for (int i = 0; i < allQuestions.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) {allQuestions[i].QuestionText}");
                    }

                    Console.WriteLine("Введите текст вопроса");
                    string textQuestion = InputChecker.GetCorrectInputFromConsole();
                    Console.WriteLine("Введите ответ на вопрос(число)");
                    int answer = InputChecker.GetUserAnswer();

                    questionsStorage.AddQuestion(pathQuestions, textQuestion, answer);

                }

                Console.WriteLine("\nХотите удалить какой-либо вопрос из теста?");
                if (InputChecker.GetUserChoice())
                {
                    int input;
                    while (true)
                    {
                        Console.WriteLine("\nВведите номер вопроса, который хотите удалить");
                        var allQuestions = questionsStorage.Questions;
                        for (int i = 0; i < allQuestions.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}) {allQuestions[i].QuestionText}");
                        }
                        input = InputChecker.GetUserAnswer();
                        int index1 = input - 1;
                        if (index1 < 0 || index1 > allQuestions.Count - 1)
                        {
                            Console.WriteLine("Не существует вопроса с таким номером.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    questionsStorage.RemoveQuestion(pathQuestions, input);
                }

                Console.WriteLine("\nПожалуйста, введите ваше ФИО");
                string fullname = InputChecker.GetCorrectInputFromConsole();

                var questions = QuestionsStorage.GetQuestions(questionsStorage);


                var random = new Random();

                for (int i = questions.Count - 1; i >= 0; i--)
                {
                    var index = random.Next(0, questions.Count);

                    Question question = questions[index];

                    Console.WriteLine($"\n{question.QuestionText}");
                    Console.Write("Ваш ответ: ");

                    int userAnswer = InputChecker.GetUserAnswer();

                    if (question.IsCorrectAnswer(userAnswer))
                    {
                        user.IncreaseCorrectAnswersCount();
                    }

                    questions.RemoveAt(index);
                }


                double percentage = Math.Round((double)user.CorrectAnswersCount * 100 / questionsStorage.Questions.Count);
                Console.WriteLine($"\nПроцент правильных ответов: {percentage}%");

                string diagnosis = Diagnosis.MakeDiagnosis(percentage);
                Console.WriteLine($"{fullname}, ваш диагноз: {diagnosis}");

                user.FullName = fullname;
                user.Percentage = percentage;
                user.Diagnosis = diagnosis;
                userStorage.Users.Add(user);

                string text = $"{user.FullName}|{user.Percentage}|{user.Diagnosis}";
                UsersResultStorage.SaveResult(pathResults, text);

                Console.Write("\nХотите пройти тест снова? ");
                if (!InputChecker.GetUserChoice())
                {
                    break;
                }

                Console.Clear();

            }



        }
    }
}
