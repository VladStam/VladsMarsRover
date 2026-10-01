using MarsRover.TerminalApp.Input_classes;
using MarsRover.TerminalApp.RoverLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRover.TerminalApp.InputEnums;

namespace MarsRover.Test
{
    public class DummyData
    {
        public string ExampleGrid1 =
    "0   1   2   3   4   5\n" +
  "  + - + - + - + - + - + - +\n" +
"0 < 0 |   |   |   |   |   |\n" +
  "  + - + - + - + - + - + - +\n" +
"1 |   |   |   |   |   |   |\n" +
  "  + - + - + - + - + - + - +\n" +
"2 |   |   |   |   |   |   |\n" +
  "  + - + - + - + - + - + - +\n" +
"3 |   |   |   |   |   |   |\n" +
  "  + - + - + - + - + - + - +\n" +
"4 |   |   |   |   |   |   |\n" +
  "  + - + - + - + - + - + - +\n" +
"5 |   |   |   |   |   |   |\n" +
  "  + - + - + - + - + - + - +\n";

        public Rover testRover1 = new Rover(
      new Position(1, 2, CompassDirection.N),
      new List<Instructs> { Instructs.L, Instructs.M, Instructs.R },
      new Plateau(5, 5)
  );

    }
}
