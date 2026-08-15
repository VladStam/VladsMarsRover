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
        public static char[,] CreateGridIndexed(int xAxisIn, int yAxisIn)
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
            // Add index numbers to the grid
            for (int i = 1; i <= xAxis; i += 2)
            {
                char[] gridNumber = new char[2];
                char[] numberArr = i.ToString().ToCharArray();
                gridNumber[0] = numberArr[0];
                if(numberArr.Length == 1)
                {
                    gridNumber[1] = ' ';
                }
                else
                {
                    gridNumber[1] = numberArr[1];
                }

                arr[i, 0] = gridNumber[0];

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

            // Convert rover's logical coordinates
            // into positions inside the visual grid.
            int roverX = (p.xPosition * 2) + 1;
            int roverY = (p.yPosition * 2) + 1;

            // Put rover on the grid
            arr[roverY, roverX] = '0';

            // Put direction marker next to rover
            if (p.direction == InputEnums.CompassDirection.N)
            {
                arr[roverY - 1, roverX] = '^';
            }
            else if (p.direction == InputEnums.CompassDirection.W)
            {
                arr[roverY, roverX - 1] = '<';
            }
            else if (p.direction == InputEnums.CompassDirection.S)
            {
                arr[roverY + 1, roverX] = 'v';
            }
            else if (p.direction == InputEnums.CompassDirection.E)
            {
                arr[roverY, roverX + 1] = '>';
            }

            // Print X-axis numbers
            Console.Write("   ");

            for (int x = 0; x < xAxisIn; x++)
            {
                Console.Write($"{x} ");
            }

            Console.WriteLine();

            // Print grid
            for (int y = 0; y < yAxis; y++)
            {
                // Print Y-axis number on grid rows
                if (y % 2 == 1)
                {
                    int yCoordinate = y / 2;
                    Console.Write($"{yCoordinate} ");
                }
                else
                {
                    Console.Write("  ");
                }

                // Print the actual grid
                for (int j = 0; j < xAxis; j++)
                {
                    Console.Write(arr[y, j]);
                }

                Console.WriteLine();
            }
        }
    }
}

    
