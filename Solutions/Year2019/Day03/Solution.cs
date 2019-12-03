using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2019 {

    class Day03 : ASolution {
        
        public Day03() : base(3, 2019, "") {
            
        }

        protected override string SolvePartOne() {
            string[] input = Input.Split('\n');
            List<(int, int)> path1 = new List<(int, int)> { };
            List<(int, int)> path2 = new List<(int, int)> { };

            int x = 0;
            int y = 0;

            foreach (var i in input[0].Split(","))
            {
                char direction = i[0];
                int distance = int.Parse( i.Substring(1));

                for(var d = 1; d <= distance; d++)
                {
                    switch (direction)
                    {
                        case 'R':
                            x++;
                            break;
                        case 'L':
                            x--;
                            break;
                        case 'U':
                            y++;
                            break;
                        case 'D':
                            y--;
                            break;
                    }

                    path1.Add(( x, y ));
                }
            }

            x = 0;
            y = 0;

            foreach (var i in input[1].Split(","))
            {
                char direction = i[0];
                int distance = int.Parse(i.Substring(1));

                for (var d = 1; d <= distance; d++)
                {
                    switch (direction)
                    {
                        case 'R':
                            x++;
                            break;
                        case 'L':
                            x--;
                            break;
                        case 'U':
                            y++;
                            break;
                        case 'D':
                            y--;
                            break;
                    }

                    path2.Add((x, y));
                }
            }

            path1 = path1.Distinct().ToList();
            path2 = path2.Distinct().ToList();

            var result = path1.Intersect(path2);

            foreach(var r in result)
            {
                System.Console.WriteLine(r);
            }

            System.Console.WriteLine("---");

            return null; 
        }

        protected override string SolvePartTwo() {
            string[] input = Input.Split('\n');
            List<(int, int)> path1 = new List<(int, int)> { };
            List<(int, int)> path2 = new List<(int, int)> { };

            int x = 0;
            int y = 0;
            int steps = 0;

            foreach (var i in input[0].Split(","))
            {
                char direction = i[0];
                int distance = int.Parse(i.Substring(1));

                for (var d = 1; d <= distance; d++)
                {
                    switch (direction)
                    {
                        case 'R':
                            x++;
                            break;
                        case 'L':
                            x--;
                            break;
                        case 'U':
                            y++;
                            break;
                        case 'D':
                            y--;
                            break;
                    }

                    steps++;

                    path1.Add((x, y));
                }
            }

            x = 0;
            y = 0;
            steps = 0;

            foreach (var i in input[1].Split(","))
            {
                char direction = i[0];
                int distance = int.Parse(i.Substring(1));

                for (var d = 1; d <= distance; d++)
                {
                    switch (direction)
                    {
                        case 'R':
                            x++;
                            break;
                        case 'L':
                            x--;
                            break;
                        case 'U':
                            y++;
                            break;
                        case 'D':
                            y--;
                            break;
                    }

                    steps++;
                    path2.Add((x, y));
                }
            }

            var result = path1.Intersect(path2);
            List<int> step_results = new List<int> { };

            foreach (var r in result)
            {
                var step1 = path1.FindIndex(a => a == r);
                var step2 = path2.FindIndex(a => a == r);

                int total = step1 + step2;

                System.Console.WriteLine(step1.ToString() + " " + step2.ToString() + " " + total.ToString());

                step_results.Add(step1 + step2);
            }

            step_results.Sort();
            System.Console.WriteLine(step_results[0]);

            return null;
        }
    }
}
