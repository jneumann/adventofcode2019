using System;

namespace AdventOfCode.Solutions.Year2019 {

  class Day01 : ASolution {

    public Day01() : base(1, 2019, "") {

    }

    protected override string SolvePartOne() {
      Double total = 0;
      string[] lines = System.IO.File.ReadAllLines(@"./Solutions/Year2019/Day01/input");
      
      foreach (string line in lines) {
        Double lineTotal = Math.Floor((Double.Parse(line) / 3.0) - 2.0);
        total += lineTotal;
      }

      return total.ToString(); 
    }

    protected override string SolvePartTwo() {
      Double total = 0;
      string[] lines = System.IO.File.ReadAllLines(@"./Solutions/Year2019/Day01/input");
      
      foreach (string line in lines) {
        Double lineTotal = Double.Parse(line);
        while (lineTotal > 0) {
          lineTotal = Math.Floor((lineTotal / 3.0) - 2.0);

          if (lineTotal > 0) {
            total += lineTotal;
          }
        }
      }

      return total.ToString(); 
    }
  }
}
