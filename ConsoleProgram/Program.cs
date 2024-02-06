using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Linq;

namespace ConsoleProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            
            string inputLine = Console.ReadLine();

            while (!Regex.IsMatch(inputLine, "^[a-z]+$"))
            {
                if (Regex.Replace(inputLine, " ", "") != "")
                {
                    Console.Write("В строке должны быть только латинские буквы в нижнем регистре! Неподходящие символы: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Regex.Replace(Regex.Replace(inputLine, "[a-z]", ""), " ", " 'Пробел' "));
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("Строка не должна быть пустой!");
                }
                
                inputLine = Console.ReadLine();
            }

            char[] mainLine = inputLine.ToCharArray();

            Console.Write("Выход: ");
            Array.Reverse(mainLine);
            string resultLine;

            if (mainLine.Length % 2 != 0)
            {
                resultLine = new string(mainLine);
                Array.Reverse(mainLine);
                resultLine += new string(mainLine);

                Console.WriteLine(resultLine);
            }
            else
            {
                var lastSegment = new ArraySegment<char>(mainLine, 0, mainLine.Length / 2);
                var firstSegment = new ArraySegment<char>(mainLine, mainLine.Length / 2, mainLine.Length / 2);
                resultLine = String.Join("", firstSegment) + (String.Join("", lastSegment));
                Console.WriteLine(resultLine);
                Array.Reverse(mainLine);
            }

            foreach (char letter in mainLine)
            {
                Console.Write($"Количество '{letter}': ");
                Console.WriteLine(resultLine.Count(lt => lt == letter));
            }

            Console.Write(" . . . Нажмите любую кнопку, чтобы выйти; Enter, чтобы перезапустить  . . . ");
            char endKey = Console.ReadKey().KeyChar;

            if (endKey == '\r')
            {
                System.Diagnostics.Process.Start(Assembly.GetExecutingAssembly().Location);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
