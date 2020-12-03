using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Solutions
{
    public class ThirdAdvent
    {
        public TreeMapReader Reader { get; set; }
        public ThirdAdvent()
        { }

        public void Solve(string[] data)
        {
            Console.WriteLine("Beginning Solve() Third Advent");
            this.InitReader(data);
        }

        private void InitReader(string[] data)
        {
            Console.WriteLine("Initializing reader...");
            List<string> grid = new List<string>();
            foreach (var line in data)
                grid.Add(line);
            Reader = new TreeMapReader();
            Reader.Init(grid);
        }

        public class TreeMapReader
        {
            public TreeMap TreeMap { get; set; }
            public TreeMapReader()
            { }

            public void Init(List<string> grid)
            {
                Console.WriteLine("Learning the map...");
                TreeMap = new TreeMap(grid);
            }
            
        }

        public class TreeMap
        {
            public List<string> Grid { get; private set; }
            public TreeMap(List<string> grid) => Grid = grid;
        }
    }

}
