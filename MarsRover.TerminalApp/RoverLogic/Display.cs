using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.TerminalApp.RoverLogic
{
    public class Display
    {
        public static void PrintRover(Rover rover)
        {
            var p = rover.position;
            Console.WriteLine(p.ToString());
            if (p.direction == InputEnums.CompassDirection.N)
            {
                Console.WriteLine(" ^"+"\n 0");
            }
            if (p.direction == InputEnums.CompassDirection.W)
            {
                Console.WriteLine("<0");
            }
            if (p.direction == InputEnums.CompassDirection.S)
            {
                Console.WriteLine(" 0" + "\n v");
            }
            if (p.direction == InputEnums.CompassDirection.E)
            {
                Console.WriteLine("0>");
            }
            
        }

        public static void PrintExes(int xAxisIn, int yAxisIn)
        {
            int xAxis = (xAxisIn * 2) + 1;
            int yAxis = (yAxisIn * 2) + 1;

            char[,] arr = new char[yAxis, xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        arr[i, j] = '+';
                    }
                    else if (i % 2 == 0)
                    {
                        arr[i, j] = '-';
                    }
                    else if (j % 2 == 0)
                    {
                        arr[i, j] = '|';
                    }
                    else
                    {
                        arr[i, j] = ' ';
                    }
                }
            }

            for (int i = 0; i < yAxis; i++)
            {
                string combined = "";

                for (int j = 0; j < xAxis; j++)
                {
                    combined += arr[i, j];
                }

                Console.WriteLine(combined);
            }
        }
       
    }
}

    
