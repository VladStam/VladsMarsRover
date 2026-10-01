using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.TerminalApp.Input_classes;
using MarsRover.TerminalApp.RoverLogic;



namespace MarsRover.TerminalApp.RoverLogic
{
    public class Director
    {
            //Upon startup, several properties are initialized. These properties include:
            // - StringObject: An instance of InputStringObject to store user input strings.
            // - newParser: An instance of InputParser to validate and parse user input.
            // - activeSpace: An instance of ActiveSpace to manage the rovers in the simulation.
            // - toggle: An instance of TestingToggle to enable or disable testing mode.

        public InputStringObject StringObject = new InputStringObject();

        public InputParser newParser;
        public ActiveSpace activeSpace;
        public TestingToggle toggle;
        public UI ui;

        public Director()
        {
            ui = new UI(this);
            newParser = new InputParser();
            activeSpace = new ActiveSpace();
            toggle = new TestingToggle();
        }

        public void Go()
        {
            ui.StartUp();
          
            Display.PrintRover(activeSpace.ExistingRovers[0]);
            Movement movement = new Movement();
            movement.BlackBox(activeSpace.ExistingRovers[0]);
            Display.PrintRover(activeSpace.ExistingRovers[0]);

            Display.PrintExesAndRover(activeSpace.ExistingRovers[0], activeSpace.ExistingRovers[0].plateau.xAxis, activeSpace.ExistingRovers[0].plateau.yAxis);
        }
        
    }
}
