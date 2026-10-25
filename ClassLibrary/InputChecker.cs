namespace GeniusIdiotConsoleApp
{
    public class InputChecker
    {
        public static bool IsCorrectInput(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
        public static string GetCorrectInputFromConsole()
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
            try
            {
                Convert.ToInt32(input);
                return true;
            }
            catch (FormatException)
            {}
            catch (OverflowException)
            {}
            return false;
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

        public static bool GetUserChoice()
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