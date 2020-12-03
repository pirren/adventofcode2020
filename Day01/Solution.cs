using System.Collections.Generic;
using System.IO;

namespace AOC2020.Day01
{
    public class Solution
    {
        private string[] numbers;
        public List<int> convertedNumbers;

        public int GoalSum { get; private set; }
        public int Result { get; set; }

        public Solution(int goalSum) => this.GoalSum = goalSum;

        public Solution Start()
        {
            numbers = File.ReadAllLines(@"numbers.txt");
            return this;
        }

        public Solution Convert()
        {
            convertedNumbers = new List<int>();
            foreach (var item in numbers)
                convertedNumbers.Add(int.Parse(item));
            return this;
        }

        public Solution Solve()
        {
            for (int i = 0; i < convertedNumbers.Count; i++)
                for (int j = i + 1; j < convertedNumbers.Count; j++)
                    for (int k = j + 1; k < convertedNumbers.Count; k++)
                    {
                        if (convertedNumbers[i] + convertedNumbers[j] + convertedNumbers[k] == GoalSum)
                            Result = convertedNumbers[i] * convertedNumbers[j] * convertedNumbers[k];
                    }
            return this;
        }
    }

}
