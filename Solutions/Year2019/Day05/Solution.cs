using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Year2019 {

    class Day05 : ASolution {
        
        public Day05() : base(5, 2019, "") {
            
        }

        static int RunIntCode(int[] numbers, bool doPartOne)
        {
            int cursor = 0;
            while (numbers[cursor] != 99)
            {
                int num = numbers[cursor];
                int op = (num % 10);

                switch (op)
                {
                    case 1:
                    case 2:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        {
                            int param1Mode = (num / 100) % 10;
                            int param2Mode = (num / 1000) % 10;

                            int addr1 = numbers[cursor + 1];
                            int addr2 = numbers[cursor + 2];

                            int param1 = (param1Mode == 1) ? addr1 : numbers[addr1];
                            int param2 = (param2Mode == 1) ? addr2 : numbers[addr2];

                            if (op != 5 && op != 6)
                            {
                                int varAddr = numbers[cursor + 3];
                                int result = HandleOpCode(op, param1, param2);

                                numbers[varAddr] = result;
                                cursor += 4;
                            }
                            else
                            {
                                cursor = ShouldJump(op, param1) ? param2 : (cursor + 3);
                            }

                            break;
                        }
                    case 3:
                        {
                            int varAddr = numbers[cursor + 1];
                            numbers[varAddr] = doPartOne ? 1 : 5;
                            cursor += 2;
                            break;
                        }
                    case 4:
                        {
                            // Peek into next position, possible program halt
                            if (numbers[cursor + 2] == 99)
                            {
                                int varAddr = numbers[cursor + 1];
                                return numbers[varAddr];
                            }

                            cursor += 2;
                            break;
                        }
                }
            }

            return numbers[0]; // dunno what to return here
        }

        static int HandleOpCode(int opCode, int value1, int value2)
        {
            if (opCode == 1) return (value1 + value2);
            if (opCode == 2) return (value1 * value2);
            if (opCode == 7) return (value1 < value2) ? 1 : 0;
            if (opCode == 8) return (value1 == value2) ? 1 : 0;

            throw new ArgumentException("Invalid opcode passed: " + opCode);
        }

        static bool ShouldJump(int opCode, int value)
        {
            if (opCode == 5) return value != 0;
            if (opCode == 6) return value == 0;

            return false;
        }

        protected override string SolvePartOne() {
            int[] numbers = Input
                .Split(',')
                .Select(l => int.Parse(l))
                .ToArray();

            return RunIntCode((int[])numbers.Clone(), true).ToString();
        }

        protected override string SolvePartTwo() {
            int[] numbers = Input
                .Split(',')
                .Select(l => int.Parse(l))
                .ToArray();

            return RunIntCode((int[])numbers.Clone(), false).ToString();
        }
    }
}
