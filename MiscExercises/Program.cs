using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Console = My.Utils.CustomConsole.Console;



namespace Misc.Exercises
{
    class Program
    {
        struct Exercise
        {
            public string              Name;
            public FExerciseInfo       InfoFunc;
            public FExerciseExecute    ExecFunc;
        }



        static void Main (string[] args)
        {
            var AllExercises = new List<Exercise>
            {
                new Exercise
                {
                    Name        = LoopNumbers.Name,
                    InfoFunc    = LoopNumbers.Info,
                    ExecFunc    = LoopNumbers.Execute
                },
                new Exercise
                {
                    Name        = CSharpDataTypes.Name,
                    InfoFunc    = CSharpDataTypes.Info,
                    ExecFunc    = CSharpDataTypes.Execute
                },
                new Exercise
                {
                    Name        = AsyncExample1.Name,
                    InfoFunc    = AsyncExample1.Info,
                    ExecFunc    = AsyncExample1.Execute
                },
            };


            Start:
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.HorizontalTitle("Выбор примера", 5, "=", "<", ">");
            Console.ResetColor();

            Console.WriteLine("Номера примеров для запуска: ");

            int n = 1;
            foreach (Exercise exe in AllExercises)
            {
                Console.Write(n);
                Console.Write(". ");
                Console.Write(exe.Name);
                Console.WriteLine();

                n++;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Horizontal("=");
            Console.ResetColor();

            Console.CursorTop -= 2;
            string input_number = Console.ReadLine();
            Console.CursorTop += 1;


            if (! int.TryParse(input_number, out int choice))
            {
                Console.TextColor = ConsoleColor.Red;
                Console.WriteLine("Число введено неправильно");
                Console.ResetColor();
                goto Start;
            }


            if ((choice < 1) || (choice > AllExercises.Count))
            {
                Console.TextColor = ConsoleColor.Red;
                Console.WriteLine("Указанное число вышло за пределы допустимого");
                Console.ResetColor();
                goto Start;
            }

            choice--;

            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.HorizontalTitle(AllExercises[choice].Name, 5);
            Console.ResetColor();

            AllExercises[choice].ExecFunc();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Horizontal();
            Console.ResetColor();

            goto Start;
        }
    }



    internal delegate void FExerciseInfo ();
    internal delegate void FExerciseExecute ();
}                              
