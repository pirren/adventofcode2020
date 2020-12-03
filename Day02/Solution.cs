﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Day02
{
    class Day02
    {
        internal static void Solve(string[] data)
        {
            List<Password> passwords = BuildPasswords(data);
            var result = passwords.Where(p => p.Valid()).Count();
            Console.WriteLine(result);
        }

        private static List<Password> BuildPasswords(string[] data)
        {
            List<Password> passwords = new List<Password>();
            foreach (string line in data)
            {
                Password password = new Password(line.Split(": ")[1])
                {
                    Policy = new PasswordPolicy
                    {
                        Char = line.Split(':')[0].Last().ToString(),
                        SecondPosition = IntBuilder(line.Split('-')[1]),
                        FirstPosition = IntBuilder(line.Split('-')[0])
                    }
                };

                passwords.Add(password);
            }
            return passwords;
        }

        private static int IntBuilder(string line)
        {
            var str = string.Empty;
            var i = 0;
            while (Int32.TryParse(line[i].ToString(), out _))
            {
                str += line[i];
                i++;
                if (i >= line.Length) break;
            }
            return Int32.Parse(str);
        }

        class Password
        {
            public string Phrase { get; private set; }
            public PasswordPolicy Policy { get; set; }

            public bool Valid()
            {
                var valid = false;
                if (Phrase[Policy.FirstPosition - 1].ToString() == Policy.Char) valid = !valid;
                if (Phrase[Policy.SecondPosition - 1].ToString() == Policy.Char) valid = !valid;

                return valid;
            }

            public Password(string pw) => Phrase = pw;
        }

        class PasswordPolicy
        {
            public string Char { get; set; }
            public int FirstPosition { get; set; }
            public int SecondPosition { get; set; }
            public PasswordPolicy()
            { }
            public PasswordPolicy(string ch, int firstPosition, int secondPosition)
            {
                Char = ch;
                FirstPosition = firstPosition;
                SecondPosition = secondPosition;
            }
        }
    }
}