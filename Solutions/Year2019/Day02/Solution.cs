using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2019 {

    class Day02 : ASolution {
        
        public Day02() : base(2, 2019, "") {
            
        }

        protected override string SolvePartOne() {
            int instr = 0;
            int[] opcode = Input.Split(',').Select(s => int.Parse(s)).ToArray();
            opcode[1] = 12;
            opcode[2] = 2;

            while (opcode[instr] != 99)
            {
                switch (opcode[instr])
                {
                    case 1:
                        // Add
                        opcode[opcode[instr + 3]] = opcode[opcode[instr + 1]] + opcode[opcode[instr + 2]];
                        break;
                    case 2:
                        // Multiply
                        opcode[opcode[instr + 3]] = opcode[opcode[instr + 1]] * opcode[opcode[instr + 2]];
                        break;
                }

                instr += 4;
            }

            System.Console.WriteLine(opcode[0]);

            return null;
        }

        protected override string SolvePartTwo() {
            int noun = 0;
            int verb = 0;
            int instr = 0;
            bool answerFound = false;

            for (int x = 0; x <= 99; x++)
            {
                for (int y = 0; y <= 99; y++)
                {
                    int[] opcode = Input.Split(',').Select(s => int.Parse(s)).ToArray();

                    instr = 0;
                    opcode[1] = x;
                    opcode[2] = y;

                    while (opcode[instr] != 99)
                    {
                        switch (opcode[instr])
                        {
                            case 1:
                                // Add
                                opcode[opcode[instr + 3]] = opcode[opcode[instr + 1]] + opcode[opcode[instr + 2]];
                                break;
                            case 2:
                                // Multiply
                                opcode[opcode[instr + 3]] = opcode[opcode[instr + 1]] * opcode[opcode[instr + 2]];
                                break;
                        }

                        instr += 4;
                    }


                    if (opcode[0] == 19690720)
                    {
                        answerFound = true;
                        verb = y;
                        break;
                    }
                }

                if (answerFound)
                {
                    noun = x;
                    break;
                }
            }

            System.Console.WriteLine(100 * noun + verb);

            return null;
        }
    }
}
