using ClassLibrary;
using System.IO;

namespace GeniusIdiotConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            UsersResultStorage userStorage = new UsersResultStorage();

            QuestionsStorage questionsStorage = new QuestionsStorage();

            while (true)
            {
                User currentUser = new User();

                if (userStorage.GetResults().Count != 0)
                {
                    Console.WriteLine("Хотите вывести все результаты тестирования?");
                    if (InputChecker.GetUserChoice())
                    {
                        Console.WriteLine("{0, -30} {1, -35} {2, -30}", "ФИО", "Процент правильных ответов", "Диагноз");
                        foreach (var user in userStorage.GetResults())
                        {
                            Console.WriteLine("{0, -30} {1, -35} {2, -30}", user.FullName, user.Percentage, user.Diagnosis);
                        }
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

                    Question newQuestion = new Question(textQuestion, answer);

                    questionsStorage.AddQuestion(newQuestion);

                }

                if (questionsStorage.Questions.Count != 0)
                {
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
                        questionsStorage.RemoveQuestion(input);
                    }
                }

                Console.WriteLine("\nПожалуйста, введите ваше ФИО");
                string fullname = InputChecker.GetCorrectInputFromConsole();

                var questions = questionsStorage.GetQuestions();


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
                        currentUser.IncreaseCorrectAnswersCount();
                    }

                    questions.RemoveAt(index);
                }


                double percentage = Math.Round((double)currentUser.CorrectAnswersCount * 100 / questionsStorage.Questions.Count);
                Console.WriteLine($"\nПроцент правильных ответов: {percentage}%");

                string diagnosis = Diagnosis.MakeDiagnosis(percentage);
                Console.WriteLine($"{fullname}, ваш диагноз: {diagnosis}");

                currentUser.FullName = fullname;
                currentUser.Percentage = percentage;
                currentUser.Diagnosis = diagnosis;

                userStorage.AddResult(currentUser);

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
