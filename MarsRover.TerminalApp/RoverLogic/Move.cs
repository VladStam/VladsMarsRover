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
    public static class Move
    {
        public static Position Action(Position position)
        {
            //Unpacking the position object into its components and converting the direction to an integer for easier manipulation
            int d = (int)position.direction;
            int x = (int)position.xPosition;
            int y = (int)position.yPosition;
            if (d == 1)
            {
                x += 1;
                if (d == 1)
                {
                    y += 1;
                     if (d == 2)
                    {
                        x -= 1;
                         if (d == 3)
                        {
                            y -= 1;
                        }
                    }
                }
            }
            Position updatedPosition = new Position(x, y, (CompassDirection)d);
            return updatedPosition;
        }
        
        

    }


}
        
            