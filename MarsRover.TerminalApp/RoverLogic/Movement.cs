using MarsRover.TerminalApp.Input_classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRover.TerminalApp.InputEnums;

namespace MarsRover.TerminalApp.RoverLogic
{
    public static class Movement
    {
        
        public static Rover BlackBox(Rover rover)
        {
            Position p = rover.position;

            foreach (Instructs instruct in rover.instruction)
            {
                Position pNew = new Position(p.xPosition, p.yPosition, p.direction);
                if (instruct != Instructs.M)
                {
                    CompassDirection direction = Compass.Rotate(p.direction, instruct);
                    pNew = new Position(p.xPosition, p.yPosition, direction);
                }
                if(instruct == Instructs.M)
                {
                    pNew = Move.Action(pNew);
                }
                rover.position = pNew;
                
            }
            return rover;

        }
        
    }
}
        
            