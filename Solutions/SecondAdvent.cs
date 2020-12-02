using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Client.Solutions
{
    public static class SecondAdvent
    {
        internal static void Solve(string[] data)
        {
            List<Password> passwords = BuildPasswords(data);
            var result = passwords.Where(p => (p.Phrase[p.Policy.FirstPosition - 1].ToString() == p.Policy.Char && p.Phrase[p.Policy.SecondPosition - 1].ToString() != p.Policy.Char) 
            || (p.Phrase[p.Policy.FirstPosition - 1].ToString() != p.Policy.Char && p.Phrase[p.Policy.SecondPosition - 1].ToString() == p.Policy.Char)).Count();
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
            while(Int32.TryParse(line[i].ToString(), out _))
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
            //public bool Valid()
            //{
            //    var  = Phrase.Count(c => c[Policy.FirstPosition] == Char);
            //    return Policy.FirstPosition <= count && count <= Policy.SecondPosition;
            //}

            public Password(string pw) => Phrase = pw;
        }

        class PasswordPolicy
        {
            public string Char { get; set; }
            public int FirstPosition { get; set; }
            public int SecondPosition { get; set; }
            public PasswordPolicy()
            { }
            public PasswordPolicy(string ch, int countMin, int countMax)
            {
                Char = ch;
                FirstPosition = countMin;
                SecondPosition = countMax;
            }
        }
    }
}
