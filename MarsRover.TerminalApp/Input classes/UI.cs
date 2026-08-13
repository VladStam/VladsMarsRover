using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 using MarsRover.TerminalApp.RoverLogic;

namespace MarsRover.TerminalApp.Input_classes
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

            public TestingToggle toggle = new TestingToggle(true);

        public void StartUp()
            //method is colled from program on ionstantiation
        {
            if (!newParser.PlateauIsValid)
            //check the available plateau is valid, if not we request user input for the plateau and validate it, if it is valid we move on to the position input, if not we loop again until we get a valid plateau input, at the beginning the PlateauIsValid is hard coded to be false
            {
                PlateauInput(newParser.PlateauIsValid, StringObject);

                if (newParser.PlateauIsValid && !newParser.PositionIsValid)
                {
                     PositionInput(newParser.PositionIsValid, StringObject);

                    if (newParser.PositionIsValid && !newParser.InstructionIsValid)
                    {
                         InstructionInput(newParser.InstructionIsValid, StringObject);

                        if (newParser.InstructionIsValid)
                        {
                            BuildRover();
                        }
                    }
                }
            }
        }
        public string RequestUserInput(int code)
        {
            string[] textPrompts =
            [
                "Hello",
                "Please Create a plateau in format (int int) e.g. 7 7, then press enter",
                "Please Select a rover position in format (int int orientation) e.g. 2 2 W, then press enter",
                "Please input instructions as a string of Characters e.g. LLRRMMM, then press enter",
            ];

            Console.WriteLine(textPrompts[code]);
            // ehen the method is called the number in the method will dictate which messsage is called out
            string UserInput = "";
            // creating a string called user input which is null by default
            if (toggle.TestingOn) { UserInput = toggle.inputMocks[code-1]; }
            //when the testin toggle is on we will use the inputMocks array to provide the input, this is useful for testing purposes, when the testing toggle is off we will use the console readline method to get the user input
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

        //These input methods have two parameters a bool that allows them to run if the input format in valid and the string object of the input
        public string PlateauInput(bool plateauIsValid, InputStringObject stringObject ) {
            while (plateauIsValid == false)
            {
                string userInput =  RequestUserInput(1);
                // if no valid input is available we launch a request using the request user input method, if the user does not provide any input we use a default value of 9 9
                if (userInput == "")
                {
                    userInput = "9 9";
                }
                stringObject.PlateauStr = userInput;
                //once we have a string input we check if it is valid using the parser, if it is valid we set the plateauIsValid bool to true and the parser property to true, if not we print an error message and loop again
                if (newParser.PlateauIsValidCheck(stringObject.PlateauStr))
                {
                    plateauIsValid = true;
                    newParser.PlateauIsValid = true;
                }
                else { Console.WriteLine("The input is invalid"); }
            }
            return stringObject.PlateauStr;
        }
        public string PositionInput(bool isValidPosition, InputStringObject stringObject)
        {
            while (isValidPosition == false)
            {
                string userInput =  RequestUserInput(2);
                if (userInput == "")
                {
                    userInput = "0 0 N";
                }
                stringObject.PositionStr = userInput;

                if (newParser.PositionIsValidCheck(StringObject.PositionStr))
                {
                    isValidPosition = true;
                    newParser.PositionIsValid = true;
                }
                else { Console.WriteLine("The input is invalid"); }
            }
            return StringObject.PositionStr;
        }
        public string InstructionInput(bool isValidInstruction, InputStringObject stringObject)
        {
            while (isValidInstruction == false)
            {
                string userInput = RequestUserInput(3);
                if (userInput == "")
                {
                    userInput = "MMRRMMLL";
                }
                stringObject.InstructionStr = userInput;

                if (newParser.InstructionIsValidCheck(StringObject.InstructionStr))
                {
                    isValidInstruction = true;
                    newParser.InstructionIsValid = true;
                }
                else { Console.WriteLine("The input is invalid"); }
            }
            return StringObject.InstructionStr;
        }
        public Rover BuildRover()
        {
            Rover rover = new Rover.Builder()
                            .AddPlateau(newParser.PlateauParser(StringObject.PlateauStr))
                            .AddPosition(newParser.PositionParser(StringObject.PositionStr))
                            .AddInstruction(newParser.InstructionParser(StringObject.InstructionStr))
                            .Build();

            rover.StoredPosition = rover.position;
            activeSpace.Rovers.Add(rover);
            return rover;
        }
    }
}
