using System;

namespace MovieStreaming.Core
{
    class ColorConsole
    {
        public static void WriteLineGreen(string message) {
            WriteColorLine(message, ConsoleColor.Green);
        }

        public static void WriteLineYellow(string message)
        {
            WriteColorLine(message, ConsoleColor.Yellow);
        }

        public static void WriteLineRed(string message)
        {
            WriteColorLine(message, ConsoleColor.Red);
        }

        public static void WriteLineCyan(string message)
        {
            WriteColorLine(message, ConsoleColor.Cyan);
        }

        public static void WriteLineGray(string message)
        {
            WriteColorLine(message, ConsoleColor.Gray);
        }

        public static void WriteLineDarkGray(string message)
        {
            WriteColorLine(message, ConsoleColor.DarkGray);
        }

        public static void WriteColorLine(string message, ConsoleColor color)
        {
            var beforeColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(message);

            Console.ForegroundColor = beforeColor;
        }
    }
}
