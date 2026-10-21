namespace GeniusIdiot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя пользователя");
            string name = Console.ReadLine();
            while (true)
            {
                string[] questions = CreateQuestions();
                int[] answers = CreateAnswers();
                Shuffle(questions, answers);

                int correctAnswersCount = 0;

                for (int i = 0; i < 5; i++)
                {
                    if (IsCorrectAnswer(questions, answers, i))
                    {
                        correctAnswersCount++;
                    }
                }

                Console.WriteLine();
                Console.WriteLine($"Количество правильных ответов: {correctAnswersCount}");
                string diagnosis = MakeDiagnosis(correctAnswersCount);
                Console.WriteLine($"{name}, ваш диагноз: {diagnosis}");

                Console.WriteLine("Хотите пройти тест снова?");
                string userAnswer = Console.ReadLine();
                userAnswer = userAnswer.ToLower();
                if (userAnswer == "нет")
                {
                    break;
                }
            }

        }

        private static bool IsCorrectAnswer(string[] questions, int[] answers, int i)
        {
            Console.WriteLine(questions[i]);

            Console.Write("Ваш ответ: ");
            int userAnswer = int.Parse(Console.ReadLine());

            if (userAnswer == answers[i])
            {
                return true;
            }

            return false;
        }

        static string[] CreateQuestions()
        {
            string[] questions =
            {
    "Сколько будет 2 плюс 2, умноженное на 2?",
    "Бревно нужно распилить на 10 частей. Сколько надо сделать распилов?",
    "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
    "Укол делают каждые полчаса. Сколько нужно минут для трех уколов?",
    "5 свечей горело, 2 потухли. Сколько свечей осталось?"
    };
            return questions;
        }
        static int[] CreateAnswers()
        {
            int[] answers = { 6, 9, 25, 60, 2 };
            return answers;
        }
        static void Shuffle(string[] questions, int[] answers)
        {
            Random random = new Random();

            for (int i = questions.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);

                string tempForQuestions = questions[i];
                questions[i] = questions[j];
                questions[j] = tempForQuestions;

                int tempForAnswers = answers[i];
                answers[i] = answers[j];
                answers[j] = tempForAnswers;
            }
        }
        static string MakeDiagnosis(int correctAnswersCount)
        {
            switch (correctAnswersCount)
            {
                case 0: return "Идиот";
                case 1: return "Кретин";
                case 2: return "Дурак";
                case 3: return "Нормальный";
                case 4: return "Талант";
                case 5: return "Гений";
                default: return "Ошибка";
            }
        }
    }
}
