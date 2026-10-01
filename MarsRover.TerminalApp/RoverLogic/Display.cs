using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.TerminalApp.RoverLogic
{
    public class Display
    {
        //method which prints the rover's position and direction to the console in a simple text format.
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
        public static (int, int) CalculateAxes(int xAxisIn, int yAxisIn)
        {
            int xAxis = (xAxisIn * 2) + 1;
            int yAxis = (yAxisIn * 2) + 1;
            return (xAxis, yAxis);
        }

        public static char[,] CreateGrid(int xAxisIn, int yAxisIn)
        {
            // Create a grid with the specified dimensions by doubling the input values and adding 1 to account for the grid lines and corners.
            var (xAxis, yAxis) = CalculateAxes(xAxisIn, yAxisIn);

            char[,] arr = new char[xAxis, yAxis];

            for (int y = 0; y < yAxis; y++)
            {
                for (int x = 0; x < xAxis; x++)
                {
                    if (y % 2 == 0 && x % 2 == 0)
                    {
                        arr[y, x] = '+';
                    }
                    else if (y % 2 == 0)
                    {
                        arr[y, x] = '—';
                    }
                    else if (x % 2 == 0)
                    {
                        arr[y, x] = '|';
                    }
                    else
                    {
                        arr[y, x] = ' ';
                    }
                }
            }
            return arr;
        }
        public static char[,] CreateGridIndexed(int xAxisIn, int yAxisIn)
        {
            var (xAxis, yAxis) = CalculateAxes(xAxisIn, yAxisIn);

            char[,] arr = new char[xAxis, yAxis];
            for (int y = 0; y < yAxis; y++)
            {
                for (int x = 0; x < xAxis; x++)
                {
                    if (x % 2 == 0 && y % 2 == 0)
                    {
                        arr[y, x] = '+';
                    }
                    else if (y % 2 == 0)
                    {
                        arr[y, x] = '—';
                    }
                    else if (x % 2 == 0)
                    {
                        arr[y, x] = '|';
                    }
                    else
                    {
                        arr[y, x] = ' ';
                    }
                }
            }
            // Add index numbers to the grid
            for (int x = 1; x <= xAxis; x += 2)
            {
                char[] gridNumber = new char[2];
                char[] numberArr = x.ToString().ToCharArray();
                gridNumber[0] = numberArr[0];
                if(x <= 9)
                {
                    gridNumber[1] = ' ';
                }
                else
                {
                    gridNumber[1] = numberArr[1];
                }
                arr[x, 0] = gridNumber[0];
            }
            return arr;
        }
        public static void PrintExes(int xAxisIn, int yAxisIn)
        {
            char[,] arr = CreateGrid(xAxisIn, yAxisIn);

            int xAxis = (xAxisIn * 2) + 1;
            int yAxis = (yAxisIn * 2) + 1;

            for (int y = 0; y < yAxis; y++)
            {
                for (int x = 0; x < xAxis; x++)
                {
                    Console.Write(arr[y, x]);
                }

                Console.WriteLine();
            }
        }
        public static void PrintExesAndRover2(Rover rover, int xAxisIn, int yAxisIn)
        {
            char[,] arr = CreateGrid(xAxisIn, yAxisIn);

            var (xAxis, yAxis) = CalculateAxes(xAxisIn, yAxisIn);

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
        Console.Write("  ");

            for (int x = 0; x < xAxisIn; x++)
            {
                if (x <= 9)
                {
                    Console.Write($"{x} ");
                }
                else
                {
                    Console.Write($"{x}");

                }
            }

            Console.WriteLine();

            // iterate through grid by row
            for (int y = 0; y < yAxis; y++)
            {
                // Print Y-axis number on grid rows
                if (y % 2 == 1)
                {
                    int yIndex = y / 2;
                    if ((y / 2) <= 9)
                    {

                        Console.Write($"{yIndex} ");
                    }
                    else
                    {
                        Console.Write($"{yIndex}");
                    }
                }
                else
                {
                    Console.Write("  ");
                }

                // Print the actual grid
                for (int x = 0; x < xAxis; x++)
                {
                    Console.Write(arr[y, x]);
                }

                Console.WriteLine();
            }
        }
        public static void PrintExesAndRover(Rover rover, int xAxisIn, int yAxisIn)
        {
            char[,] arr = CreateGrid(xAxisIn, yAxisIn);

            var (xAxis, yAxis) = CalculateAxes(xAxisIn, yAxisIn);

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
            Console.Write("  ");

            for (int x = 0; x < xAxisIn; x++)
            {
                if (x <= 9)
                {
                    Console.Write($"  {x} ");
                }
                else
                {
                    Console.Write($"  {x}");

                }
            }

            Console.WriteLine();

            // iterate through grid by row
            for (int y = 0; y < yAxis; y++)
            {
                // Print Y-axis number on grid rows
                if (y % 2 == 1)
                {
                    int yIndex = y / 2;
                    if ((y / 2) <= 9)
                    {

                        Console.Write($"{yIndex} ");
                    }
                    else
                    {
                        Console.Write($"{yIndex}");
                    }
                }
                else
                {
                    Console.Write("  ");
                }
                //add extra spaces
                for (int x = 0; x < xAxis; x++)
                {
                    Console.Write(arr[y, x] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}

    
