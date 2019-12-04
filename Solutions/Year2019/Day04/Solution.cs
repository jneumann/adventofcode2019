using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2019 {

    class Day04 : ASolution {
        
        public Day04() : base(4, 2019, "") {
            
        }

        protected override string SolvePartOne() {
            var minRange = Int32.Parse(Input.Split('-')[0]);
            var maxRange = Int32.Parse(Input.Split('-')[1]);
            List<int> passwords = new List<int> { };

            for (var i = minRange; i <= maxRange; i++)
            {
                bool decreased = false;
                bool hasAdjacent = false;
                int lastDigit = -1;

                foreach(char digit in i.ToString())
                {
                    int currentDigit = Int32.Parse(digit.ToString());

                    if (lastDigit > currentDigit)
                        decreased = true;

                    if (lastDigit == currentDigit)
                        hasAdjacent = true;

                    lastDigit = currentDigit;
                }

                if (!decreased && hasAdjacent)
                    passwords.Add(i);
            }

            return passwords.Count.ToString(); 
        }

        protected override string SolvePartTwo() {
            var minRange = Int32.Parse(Input.Split('-')[0]);
            var maxRange = Int32.Parse(Input.Split('-')[1]);
            List<int> passwords = new List<int> { };

            for (var i = minRange; i <= maxRange; i++)
            {
                bool decreased = false;
                bool[] hasAdjacent = new bool[6];

                int lastDigit = -1;
                int lastLastDigit = -1;

                string str = i.ToString();
                for (int j = 0; j < str.Length; j++)
                {
                    int thisDigit = Int32.Parse(str[j].ToString());

                    if (lastDigit > thisDigit) // Digits have decreased
                        decreased = true;

                    if (lastDigit == thisDigit && lastLastDigit != thisDigit) // Found a 2 digit adjacent match, note the start index
                        hasAdjacent[j - 1] = true;

                    if (thisDigit == lastDigit && thisDigit == lastLastDigit) // Found a 3 digit adjacent match, so cancel it off
                        hasAdjacent[j - 2] = false;

                    lastLastDigit = lastDigit;
                    lastDigit = thisDigit;
                }

                if (!decreased && hasAdjacent.Any(x => x == true))
                    passwords.Add(i);
            }

            return passwords.Count.ToString();
        }
    }
}
