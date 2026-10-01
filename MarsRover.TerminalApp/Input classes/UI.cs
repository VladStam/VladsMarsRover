using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MarsRover.TerminalApp.RoverLogic;
using MarsRover.TerminalApp.Input_classes;


namespace MarsRover.TerminalApp
{
    public class UI
    {
        //Upon the creation of  a new UI instance, several properties are initialized. These properties include:
        // - StringObject: An instance of InputStringObject to store user input strings.
        // - newParser: An instance of InputParser to validate and parse user input.
        // - activeSpace: An instance of ActiveSpace to manage the rovers in the simulation.
        // - toggle: An instance of TestingToggle to enable or disable testing mode.

            public InputStringObject StringObject = new InputStringObject();

            public InputParser newParser = new InputParser();

            public ActiveSpace activeSpace = new ActiveSpace();

            public TestingToggle toggle = new TestingToggle();

            public string[] textPrompts =
                [
                    "Hello",
                    "Please Create a plateau in format (int int) e.g. 7 7, then press enter",
                    "Please Select a rover position in format (int int orientation) e.g. 2 2 W, then press enter",
                    "Please input instructions as a string of Characters e.g. LLRRMMM, then press enter",
                    "Plateau created",
                    "Rover created",

                ];
        public void StartUp()
            //method is colled from program on ionstantiation
        {
            if (!newParser.PlateauIsValid)
            //check the available plateau is valid, if not we request user input for the plateau and validate it, if it is valid we move on to the position input, if not we loop again until we get a valid plateau input, at the beginning the PlateauIsValid is hard coded to be false
            {
                AppLogic.PlateauInput(newParser.PlateauIsValid, StringObject, this);

                if (newParser.PlateauIsValid && !newParser.PositionIsValid)
                {
                    AppLogic.PositionInput(newParser.PositionIsValid, StringObject, this);
                    if (newParser.PositionIsValid && !newParser.InstructionIsValid)
                    {
                         AppLogic.InstructionInput(newParser.InstructionIsValid, StringObject, this);

                        if (newParser.InstructionIsValid)
                        {
                            AppLogic.BuildRover(this);
                        }
                    }
                }
            }
        }
        public string RequestUserInput(int code)
        {
            Console.WriteLine(textPrompts[code]);
            // when the method is called the number in the method will dictate which messsage is called out
            string UserInput = "";
            // creating a string called user input which is null by default
            if (toggle.TestingOn) { UserInput = toggle.inputMocks[code-1]; }
            //when the testing toggle is on we will use the inputMocks array to provide the input, this is useful for testing purposes, when the testing toggle is off we will use the console readline method to get the user input
            else { UserInput = Console.ReadLine(); }
            return UserInput;
            //returns what is read as the users input, if the user does not input anything we return an empty string, this is handled in the input methods

            //var inputTask = Task.Run(() => Console.ReadLine());
            //var delayTask = Task.Delay(10000); // 10 seconds
            //var completedTask = await Task.WhenAny(inputTask, delayTask);
            //if (completedTask == inputTask)
            //{
            //    return inputTask.Result;
            //}
            //else
            //{
            //    Console.WriteLine("You are taking too long");
            //    return "";
            //}
        }

    }
}
