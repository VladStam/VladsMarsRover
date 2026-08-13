using MarsRover.TerminalApp.Input_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MarsRover.TerminalApp.Input_classes;
using static MarsRover.TerminalApp.InputEnums;

namespace MarsRover.TerminalApp.Input_classes
{
    public class InputParser
    {
        //these properties are used to confirm whether or not the input is valid. They are set to false by default and will be set to true if the input is valid.

        public bool PlateauIsValid { get; set; } 
        public bool PositionIsValid { get; set; } 
        public bool InstructionIsValid { get; set; } 

        public InputParser()
        {
            PlateauIsValid = false;
            PositionIsValid = false;
            InstructionIsValid = false;
        }

        //Below are the input checking methods which use regex to check if the input is valid.
        //They return a boolean value indicating whether or not the input is valid and set the corresponding property to true or false.
        //if the input is valid, the property is set to true, otherwise it is set to false.
        //the method returns a true or false value for testing purposes. 
        public bool PlateauIsValidCheck(string input)
        {
            bool check = Regex.IsMatch(input, @"^\d+\s+\d+$");
            //regex xhecks for number whitepace number. This is the format for the plateau input. The numbers represent the x and y coordinates of the plateau.

            PlateauIsValid = check;

            return check;
        }
        public bool PositionIsValidCheck(string input)
        {
            bool check = Regex.IsMatch(input, @"^(\d+)\s+(\d+)\s+([NSEWnesw])$");
            //regex checks for number whitepace number whitespace letter. This is the format for the position input. The numbers represent the x and y coordinates of the position and the letter represents the orientation of the rover.

            PositionIsValid = check;

            return check;
        }
        public bool InstructionIsValidCheck(string input)
        {
            bool check = Regex.IsMatch(input, @"^[LRMlrm]+$", RegexOptions.IgnoreCase);
            //regex checks for string of letters L or R or M. This is the format for the instruction input. The letters represent the instructions for the rover.

            InstructionIsValid = check;

            return check;
        }

        public  List<Instructs> InstructionParser(string inputString)
        {
         
            char[] chars = inputString.ToUpper().Trim().ToCharArray();
            // turn the input string after format checks into a char array of only upper case letters and then parse the char array into a list of Instructs enums using a switch statement. Then return the list of Instructs enums.
            List<Instructs> instructsList = chars.Select(c => c switch
            {
                'L' => Instructs.L,
                'R' => Instructs.R,
                'M' => Instructs.M,
                _ => throw new InvalidOperationException()
            }).ToList();
        
            return instructsList;
            //the end product is a list of Instructs enums that can be used to move the rover.

        }
        public Plateau PlateauParser(string inputString)
        {
            //parse the input string into a Plateau object spliting into a char array and then parsing the x and y coordinates into integers. Then return a new Plateau object with the x and y coordinates.
            string[] splitInput = inputString.Split(' ');
                int xAxis = int.Parse(splitInput[0]);
                int yAxis = int.Parse(splitInput[1]);

                return new Plateau(xAxis, yAxis);
        }
        public  Position PositionParser(string inputString)
        {
            //parse the input string into a Position object spliting into a char array and then parsing the x and y coordinates into integers. Then return a new Position object with the x and y coordinates and the orientation.
            string[] splitInput = inputString.Split(' ');
            int xCoord = int.Parse(splitInput[0]);
            int yCoord = int.Parse(splitInput[1]);
            CompassDirection orientation = CompassDirection.Parse<CompassDirection>(splitInput[2]);

            return new Position(xCoord, yCoord, orientation);

        }
    }
}
