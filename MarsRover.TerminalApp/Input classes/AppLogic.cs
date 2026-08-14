using MarsRover.TerminalApp.RoverLogic;
using MarsRover.TerminalApp.Input_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.TerminalApp.Input_classes
{
    public static class AppLogic
    {
        //These input methods have two parameters a bool that allows them to run if the input format in valid and the string object of the input
        public static string PlateauInput(bool plateauIsValid, InputStringObject stringObject, UI uI)
        {
            while (plateauIsValid == false)
            {
                string userInput = uI.RequestUserInput(1);
                // if no valid input is available we launch a request using the request user input method, if the user does not provide any input we use a default value of 9 9
                if (userInput == "")
                {
                    userInput = "9 9";
                }
                stringObject.PlateauStr = userInput;
                //once we have a string input we check if it is valid using the parser, if it is valid we set the plateauIsValid bool to true and the parser property to true, if not we print an error message and loop again
                if (uI.newParser.PlateauIsValidCheck(stringObject.PlateauStr))
                {
                    plateauIsValid = true;
                    uI.newParser.PlateauIsValid = true;
                }
                else { Console.WriteLine("The input is invalid"); }
            }
            return stringObject.PlateauStr;
        }
        public static string PositionInput(bool isValidPosition, InputStringObject stringObject, UI uI)
        {
            while (isValidPosition == false)
            {
                string userInput = uI.RequestUserInput(2);
                if (userInput == "")
                {
                    userInput = "0 0 N";
                }
                stringObject.PositionStr = userInput;

                if (uI.newParser.PositionIsValidCheck(stringObject.PositionStr))
                {
                    isValidPosition = true;
                    uI.newParser.PositionIsValid = true;
                    Console.WriteLine(uI.textPrompts[4]);
                }
                else { Console.WriteLine("The input is invalid"); }
            }
            return uI.StringObject.PositionStr;
        }
        public static string InstructionInput(bool isValidInstruction, InputStringObject stringObject, UI uI)
        {
            while (isValidInstruction == false)
            {
                string userInput = uI.RequestUserInput(3);
                if (userInput == "")
                {
                    userInput = "MMRRMMLL";
                }
                stringObject.InstructionStr = userInput;

                if (uI.newParser.InstructionIsValidCheck(stringObject.InstructionStr))
                {
                    isValidInstruction = true;
                    uI.newParser.InstructionIsValid = true;
                    Console.WriteLine(uI.textPrompts[5]);
                }
                else { Console.WriteLine("The input is invalid"); }
            }
            return uI.StringObject.InstructionStr;
        }
        public static Rover BuildRover(UI uI)
        {
            Rover rover = new Rover.Builder()
                            .AddPlateau(uI.newParser.PlateauParser(uI.  StringObject.PlateauStr))
                            .AddPosition(uI.newParser.PositionParser(uI.StringObject.PositionStr))
                            .AddInstruction(uI.newParser.InstructionParser(uI.StringObject.InstructionStr))
                            .Build();

            rover.StoredPosition = rover.position;
            uI.activeSpace.Rovers.Add(rover);
            return rover;
        }
    }
}
