using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using My.Utils;



namespace Misc.Exercises
{
    class CAsyncExample1
    {
        public static string Name = "Простой пример асинхронной работы";

        public static void Info ()
        {
            Console.Write
            (
                " Задача: " + 
                "Определить конечный вывод в разных ситуациях "
            );
        }



        private static string _Result;

        public static void Execute ()
        {
            _Result = string.Empty;

            //  В данном примере я намеренно вызываю асинхронную функцию
            //  без ключевого слова await. Поэтому предупреждение нужно выключить,
            //  чтобы оно не смешивалось с настоящими ошибками и предупреждениями
            //  всего проекта, и не отвлекало тем самым от реальных проблем. 
            #pragma warning disable CS4014
            SaySomething1();
            #pragma warning restore CS4014
            Console.WriteLine("Проверка № 1");
            Console.WriteLine(_Result);

            Console.WriteLine(SaySomething1().Result);
            Console.WriteLine(_Result);

            Console.WriteLine(SaySomething2());
            Console.WriteLine(_Result);
        }

        static async Task<string> SaySomething1 ()
        {
            await Task.Delay(5);
            _Result = "Привет, мир! Случай № 1";
            return "Проверка № 2";
        }

        static string SaySomething2 ()
        {
            Thread.Sleep(5);
            _Result = "Привет, мир! Случай № 2";
            return "Проверка № 3";
        }
    }
}
