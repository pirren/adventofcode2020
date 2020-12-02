using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Client.Solutions
{
    public class FirstAdvent
    {
        private string[] numbers;
        public List<int> convertedNumbers;

        public int GoalSum { get; private set; }
        public int Result { get; set; }

        public FirstAdvent(int goalSum) => this.GoalSum = goalSum;

        public FirstAdvent Start()
        {
            numbers = File.ReadAllLines(@"numbers.txt");
            return this;
        }

        public FirstAdvent Convert()
        {
            convertedNumbers = new List<int>();
            foreach (var item in numbers)
                convertedNumbers.Add(int.Parse(item));
            return this;
        }

        public FirstAdvent Solve()
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
