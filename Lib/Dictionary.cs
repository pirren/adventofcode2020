using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2020.Lib
{
    public static class System
    {
        public static string Greeting { get => "Advent of Code 2020 version"; }
        public static string Actions { get => "\nEnter a problem[1-25?], or [a] for all"; }

        public static void Write(string text = "", ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
