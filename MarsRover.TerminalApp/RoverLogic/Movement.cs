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
    public class Movement
    {
        
        public Rover BlackBox(Rover rover)
        {
            Position p = rover.position;

            foreach (Instructs instruct in rover.instruction)
            {
               CompassDirection direction = Rotate(p.direction,instruct);
                Position pNew = new Position(p.xPosition,p.yPosition, direction);
                if(instruct == Instructs.M)
                {
                    pNew = Move(pNew);
                }
                rover.position = pNew;
                
            }
            return rover;

        }
        public Position Move(Position position)
        {
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
        public CompassDirection Rotate(CompassDirection point, Instructs instructs)
        {
            int pointIndex = (int)point;
            int directionIndex = (int)instructs;
            if (instructs == Instructs.M)
            {
                directionIndex = 0;
                if (instructs == Instructs.L)
                {
                    directionIndex = -1;
                    if (instructs == Instructs.R)
                    {
                        directionIndex = 1;
                    }
                }
            }

            int NewIndex = directionIndex + pointIndex;

            if (NewIndex == 4) //west
            {
                NewIndex = 0;//north
            }
            if (NewIndex == -1)//north to west
            {
                NewIndex = 3;//west
            }
            CompassDirection newDirection = (CompassDirection)NewIndex;
            return newDirection;
        }
        

    }


}
        
            