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
        public static char[,] CreateGrid(int xAxisIn, int yAxisIn)
        {
            int xAxis = (xAxisIn * 2) + 1;
            int yAxis = (yAxisIn * 2) + 1;

            char[,] arr = new char[xAxis, yAxis];

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
            return arr;
        }
        public static void PrintExes(int xAxisIn, int yAxisIn)
        {
            char[,] arr = CreateGrid(xAxisIn, yAxisIn);

            int xAxis = (xAxisIn * 2) + 1;
            int yAxis = (yAxisIn * 2) + 1;

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    Console.Write(arr[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static void PrintExesAndRover(Rover rover, int xAxisIn, int yAxisIn)
        {
            char[,] arr = CreateGrid(xAxisIn, yAxisIn);

            int xAxis = (xAxisIn * 2) + 1;
            int yAxis = (yAxisIn * 2) + 1;

            var p = rover.position;
            int roverX = p.yPosition * 2;
            int roverY = p.xPosition * 2;

            arr[roverX, roverY] = '0';

            if (p.direction == InputEnums.CompassDirection.N)
            {
                arr[roverX, roverY + 1] = '^';
            }
            if (p.direction == InputEnums.CompassDirection.W)
            {
                arr[roverX - 1, roverY] = '<';
            }
            if (p.direction == InputEnums.CompassDirection.S)
            {
                arr[roverX, roverY - 1] = 'v';
            }
            if (p.direction == InputEnums.CompassDirection.E)
            {
                arr[roverY + 1, roverX] = '>';
            }

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    Console.Write(arr[i, j]);
                }

                Console.WriteLine();
            }
        }

    }
}

    
