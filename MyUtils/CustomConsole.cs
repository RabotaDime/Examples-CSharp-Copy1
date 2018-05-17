using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleBase = System.Console; 



namespace My.Utils.CustomConsole
{
    public class CustomConsole
    {
    }



    public static class Console
    {
        public static CustomConsole PrimaryConsole = new CustomConsole ();

        public const string TitleDecorStart = "( ";
        public const string TitleDecorEnd   = " )";
        public const string HorizontalFill  = "-";
        public const string EmptyString  = "";



        //  Console.Horizontal("+12345-", "///START!!!", "\\\\\\END!!!");



        public static void HorizontalTitle
        (
            string title,
            int x_start,
            string fill         = HorizontalFill,
            string title_start  = TitleDecorStart, 
            string title_end    = TitleDecorEnd
        )
        {
            int max_size = ConsoleBase.WindowWidth;

            const int MaxDecorSize = 8;
            if (title_start .Length > MaxDecorSize) title_start = title_start .Substring(0, MaxDecorSize);
            if (title_end   .Length > MaxDecorSize) title_end   = title_end   .Substring(0, MaxDecorSize);

            int title_size = Math.Min(max_size - title_start.Length - title_end.Length, title.Length);
            if (title.Length > title_size)
            {
                title_size = title_size - 3;
                if (title_size > 0)
                    title = title.Substring(0, title_size) + "...";
                else
                    title = title.Substring(0, 3);
            }

            Console.Horizontal(fill);
            ConsoleBase.CursorTop--;

            ConsoleBase.CursorLeft += x_start;
            ConsoleBase.Write(title_start);
            ConsoleBase.Write(title);
            ConsoleBase.Write(title_end);

            ConsoleBase.CursorLeft = 0;
            ConsoleBase.CursorTop++;
        }

        public static void Horizontal
        (
            string fill     = HorizontalFill,
            string start    = EmptyString,
            string end      = EmptyString
        )
        {
            int max_size = ConsoleBase.WindowWidth;

            int start_size  = Math.Min(start.Length, max_size);
            int end_size    = Math.Min(end.Length, max_size - start_size);
            int fill_size   = max_size - start_size - end_size;

            ConsoleBase.Write(start.Substring(0, start_size));

            int step = 0;
            while (fill_size > 0)
            {
                ConsoleBase.Write(fill[step]);

                fill_size--;

                step++;
                if (step >= fill.Length) step = 0;
            }

            ConsoleBase.Write(end.Substring(0, end_size));
        }



        public static ConsoleColor TextColor
        {
            get { return ConsoleBase.ForegroundColor; }
            set { ConsoleBase.ForegroundColor = value; }
        }

        public static ConsoleColor ForegroundColor
        {
            get { return ConsoleBase.ForegroundColor; }
            set { ConsoleBase.ForegroundColor = value; }
        }

        public static ConsoleColor BackColor
        {
            get { return ConsoleBase.BackgroundColor; }
            set { ConsoleBase.BackgroundColor = value; }
        }

        public static ConsoleColor BackgroundColor
        {
            get { return ConsoleBase.BackgroundColor; }
            set { ConsoleBase.BackgroundColor = value; }
        }

        public static void ResetColor ()
        {
            ConsoleBase.ResetColor();
        }



        public static void SetCursorPosition (int x, int y)
        {
            ConsoleBase.SetCursorPosition(x, y);
        }

        public static int CursorLeft
        {
            get { return ConsoleBase.CursorLeft; }
            set { ConsoleBase.CursorLeft = value; }
        }

        public static int CursorTop
        {
            get { return ConsoleBase.CursorTop; }
            set { ConsoleBase.CursorTop = value; }
        }

        public static bool CursorVisible
        {
            get { return ConsoleBase.CursorVisible; }
            set { ConsoleBase.CursorVisible = value; }
        }

        public static int CursorSize
        {
            get { return ConsoleBase.CursorSize; }
            set { ConsoleBase.CursorSize = value; }
        }



        public static void Write (int value)
        {
            ConsoleBase.Write(value);
        }

        public static void Write (string value)
        {
            ConsoleBase.Write(value);
        }

        public static void WriteLine (int value)
        {
            ConsoleBase.WriteLine(value);
        }

        public static void WriteLine (string value)
        {
            ConsoleBase.WriteLine(value);
        }

        public static void WriteLine ()
        {
            ConsoleBase.WriteLine();
        }



        public static string ReadLine ()
        {
            return ConsoleBase.ReadLine();
        }
    }
}
