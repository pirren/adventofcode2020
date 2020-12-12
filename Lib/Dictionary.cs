using System;

namespace AOC2020.Lib
{
    public static class System
    {
        public static string Greeting => String.Format("Advent of Code 2020 version");
        public static string Actions(int max) => String.Format("\nEnter a problem[1-{0}], or [a] for all", max); 

        public static void Write(string text = "", ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
