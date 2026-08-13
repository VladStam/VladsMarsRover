// See https://aka.ms/new-console-template for more information

using MarsRover.TerminalApp;
using MarsRover.TerminalApp.RoverLogic;

//On startup , the program will create a new instance of the UI class, which will handle user input and output. The UI class will prompt the user for input, parse the input, and create a new Rover object based on the input. The Rover object will be added to the ActiveSpace, which is a collection of all the rovers in the simulation. The program will then call the BlackBox method of the Logic class, which will execute the instructions for each rover in the ActiveSpace. Finally, the program will print the final position of each rover to the console.

UI ui = new UI();
//StartUp is method to get it going
ui.StartUp();
Display.PrintRover(ui.activeSpace.Rovers[0]);
Movement movement = new Movement();
movement.BlackBox(ui.activeSpace.Rovers[0]);
Display.PrintRover(ui.activeSpace.Rovers[0]);


Display.PrintExes(6, 6);