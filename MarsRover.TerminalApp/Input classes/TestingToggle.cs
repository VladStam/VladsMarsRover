using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.TerminalApp.Input_classes
{
    public class TestingToggle
    {
        public bool TestingOn = false;

        public string testPlateau = "25 25";
        public string firstRover = "1 2 N";
        public string firstInstructions = "LMLMMMLMLMMR";
        public string secondRover = "3 3 E";
        public string secondInstructions = "MMRMMRMRRM";

        public string[] inputMocks = [
       "25 25",
       "1 2 N",
       "LMLMMMLMLMMR",
            ];
        public TestingToggle()
        {
          
        }
    }
}
