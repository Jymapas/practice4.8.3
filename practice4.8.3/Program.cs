using System;

namespace practice4._8._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game();
        }
        static void Game()
        {
            Console.WriteLine($"Введите целое положительное число x.\nВ диапазоне от 0 до X будет загадано случайное число.");
            int range = ConsoleInput(game: false), userTry = -1;
            Random random = new();
            int hiddenNumber = random.Next(range);
            Console.WriteLine($"Загаданное число находится в диапазоне от 0 до {range}.\nПопробуйте его угадать!");
            for (int i = 1; ; i++)
            {
                Console.Write($"Попытка {i}. Чтобы сдаться введите \"quit\".\nВведите целое число от 0 до {range}: \t");
                userTry = ConsoleInput(range);
                if (userTry == -1)
                {
                    Console.WriteLine($"Вы сдались! Было загадано число {hiddenNumber}.");
                    break;
                }
                if (hiddenNumber == userTry)
                {
                    Console.WriteLine(@"Вы выиграли за {0} {1}. Загаданное число — {2}.", i, TrysCount(i), hiddenNumber);
                    break;
                }
                Console.WriteLine(@"Загаданное число {0}. Попробуйте ещё раз.", LessOrBigger(userTry, hiddenNumber));
            }
            Console.WriteLine("Игра завершена!");
        }
        static int ConsoleInput(int max = int.MaxValue, bool game = true)
        {
            bool checkInput = false;
            int range = -1;
            do
            {
                string? input = Console.ReadLine();
                string[] quit = {"quit", "q", "exit", "e", "finish", "f", "escape", "end", "surrender"};
                if (game && quit.Contains(input))
                    return -1;
                checkInput = int.TryParse(input, out range) && range >= 0;
                if (!checkInput)
                    Console.WriteLine($"Некорректный ввод.\nВведите целое положительное число в диапазоне от 0 до {max}"); ; ;
            } while (!checkInput);
            return range;
        }
        static string TrysCount(int i)
        {
            i %= 100;
            if (i > 10 && i < 15)
                return "попыток";
            return (i % 10) switch
            {
                1 => "попытку",
                >= 2 and < 5 => "попытки",
                _ => "попыток"
            };
        }
        static string LessOrBigger(int userTry, int hiddenNumber) => userTry < hiddenNumber ? $"больше, чем {userTry}" : $"меньше, чем {userTry}";
    }
}