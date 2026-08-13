using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRover.TerminalApp.InputEnums;



namespace MarsRover.TerminalApp.Input_classes
{
    
    public record Position(int xPosition, int yPosition, CompassDirection direction);

    public record Plateau(int xAxis, int yAxis);

    //this is my DTO for the input strings. I will use this to pass the input strings to the parser class.
    public class InputStringObject
    {
        public string PlateauStr
        { get; set; }
        public string PositionStr
        { get; set; }
        public string InstructionStr
        { get; set; }
        public InputStringObject()
        {
            PlateauStr = "";
            PositionStr = "";
            InstructionStr = "";
        }
    }

}
