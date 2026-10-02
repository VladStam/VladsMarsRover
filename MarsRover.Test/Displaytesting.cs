using MarsRover.TerminalApp.Input_classes;
using MarsRover.TerminalApp.RoverLogic;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Shouldly;
using System.Diagnostics.CodeAnalysis;
using static MarsRover.TerminalApp.InputEnums;
using static MarsRover.TerminalApp.RoverLogic.Display;
using static MarsRover.TerminalApp.RoverLogic.Movement;
using static MarsRover.TerminalApp.RoverLogic.Rover;
using MarsRover.TerminalApp;


namespace MarsRover.Test
{
    public class DisplayTests
    {
        DummyData dummyData = new DummyData();
        Director dummyDirector = new Director();

        [Test]
        public void DisplayRover()
        {
            Display.PrintRover(dummyData.testRover1);
        }
        [Test]
        public void DisplayGrid()
        {

        }
    }
}
    public class UIInteractionTests
    {

    Director dummyDirector = new Director();

    [Test]
        public void RequestsText()
        {
            UI ui = new UI(dummyDirector);
            string userInput = ui.RequestUserInput(2);
            Assert.That(userInput, Is.EqualTo(""));
        }
    [Test]

        public void PlateauInputChecker()
        {
            UI ui = new UI(dummyDirector);
            var output = AppLogic.PlateauInput( ui.director.newParser.PlateauIsValid, ui.director.StringObject, ui);
            Assert.That(ui.director.StringObject.PlateauStr, Is.EqualTo("9 9"));
        }


        // [Test]
        //public void ChecksInputedInstructionIsValidInput()
        //{
        //         UI ui = new UI();
        // //ui.StringObject.PlateauStr = "7 7";
        // ui.newParser.PlateauIsValid = true;
        // var output = ui.PlateauInput(ui.newParser.PlateauIsValid, ui.StringObject);
        // Assert.That(output, Is.EqualTo("7 7"));
        //}
        //[Test]
        //public void ParserReturns2Rovers()
        //{
        //    InputParser parser = new InputParser();
        //    string testPlateau = " 5 5 ";
        //    string firstRover = "1 2 N";
        //    string firstInstructions = "LMLMLMLMM";
        //    string secondRover = "3 3 E";
        //    string secondInstructions = "MMRMMRMRRM";
        //    string output1 = "1 3 N";
        //    string output2 = "5 1 E";
        //}
        [Test]

        public void BlackboxValidator()
        {
            UI ui = new UI(dummyDirector);
            string testPlateau = "5 5";
            string firstRover = "1 2 N";
            string firstInstructions = "LMLMLMLMM";
            string secondRover = "3 3 E";
            string secondInstructions = "MMRMMRMRRM";

            string[] inputMocks = [
                  "5 5",
               "1 2 N",
               "LMLMLMLMM",
              ];

            Rover rover = new Rover.Builder()
                            .AddPlateau(ui.director.newParser.PlateauParser(testPlateau))
                            .AddPosition(ui.director.newParser.PositionParser(firstRover))
                            .AddInstruction(ui.director.newParser.InstructionParser(firstInstructions))
                            .Build();
            rover = Movement.BlackBox(rover);
            string output1 = "1 3 N";
            Rover roverExpected = new Rover(ui.director.newParser.PositionParser(firstRover),  ui.director.newParser.InstructionParser(firstInstructions),ui.director.newParser.PlateauParser(testPlateau));
            Assert.That(rover, Is.EqualTo(roverExpected));
        }

    }
    



