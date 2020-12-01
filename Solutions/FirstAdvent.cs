using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent
{
    class FirstAdvent
    {
        static void Main(string[] args)
        {
            FirstAdventSolver worker = new FirstAdventSolver(2020);
            worker.Start().Convert().Solve();

            Console.WriteLine($"Sum is {worker.Result}");
            Console.ReadLine();
        }

        public class FirstAdventSolver
        {
            private string[] numbers;
            public List<int> convertedNumbers;

            public int GoalSum { get; private set; }
            public int Result { get; set; }

            public FirstAdventSolver(int goalSum) => this.GoalSum = goalSum;

            public FirstAdventSolver Start()
            {
                numbers = File.ReadAllLines(@"numbers.txt");
                return this;
            }

            public FirstAdventSolver Convert()
            {
                convertedNumbers = new List<int>();
                foreach (var item in numbers)
                    convertedNumbers.Add(int.Parse(item));
                return this;
            }

            public FirstAdventSolver Solve()
            {
                for(int i = 0; i < convertedNumbers.Count; i++)
                    for(int j = i + 1; j < convertedNumbers.Count; j++)
                        for  (int k = j + 1; k < convertedNumbers.Count; k++)
                        {
                            if (convertedNumbers[i] + convertedNumbers[j] + convertedNumbers[k] == GoalSum)
                                Result = convertedNumbers[i] * convertedNumbers[j] * convertedNumbers[k];
                        }
                return this;
            }
        }
    }
}
