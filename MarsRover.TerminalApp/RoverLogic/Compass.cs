using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRover.TerminalApp.InputEnums;

namespace MarsRover.TerminalApp.RoverLogic
{

    public static class Compass
    {
        public static CompassDirection Rotate(CompassDirection point, Instructs instructs)
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
