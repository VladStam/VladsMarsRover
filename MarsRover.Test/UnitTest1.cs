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
    public class ParserTests
    {
        [Test]
        public void TurnsStringIntoInstruction()
        {
            string testString = "LLLRRMM";

            List<Instructs> expectedList =
                new List<Instructs> { Instructs.L, Instructs.L, Instructs.L, Instructs.R, Instructs.R, Instructs.M, Instructs.M };

            InputParser parser = new InputParser();
            var output = parser.InstructionParser(testString);

            Assert.That(output, Is.EquivalentTo(expectedList));
        }

        [Test]
        public void TurnsStringIntoInstruction2()
        {
            string testString = "Ll  LR RmM";

            List<Instructs> expectedList =
                new List<Instructs> { Instructs.L, Instructs.L, Instructs.L, Instructs.R, Instructs.R, Instructs.M, Instructs.M };

            InputParser parser = new InputParser();
            var output = parser.InstructionParser(testString);

            Assert.That(output, Is.EquivalentTo(expectedList));
        }
        [Test]
        public void TurnsStringIntoExceptionNotInstruction()
        {
            InputParser parser = new InputParser();
            string testString = "LLqLRb RMM 3";

            Assert.Throws<InvalidOperationException>(() =>
                parser.InstructionParser(testString)
            );
        }
        
        [Test]
        public void TurnsStringIntopostion()
        {
            InputParser parser = new InputParser();
            string testString = "1 1 N";

            Position output =
              parser.PositionParser(testString);

            Position expectedval = new
            Position(1, 1, CompassDirection.N);

            Assert.That(output, Is.EqualTo(expectedval));
        }

        [Test]
        public void TurnsStringIntoPlateau()
        {
            InputParser parser = new InputParser();
            string testString = "10 10";
            Plateau output =
             parser.PlateauParser(testString);

            Plateau expectedval = new
            Plateau(10, 10);

            Assert.That(output, Is.EqualTo(expectedval));
        }
    }
    public class ValidInputTests
        {
            [Test]
            public void ChecksPlateauIsInValidInput()
            {
                InputParser parser = new InputParser();
                string testString = "10 x1!";

                bool output = parser.PlateauIsValidCheck(testString);

                Assert.That(output, Is.EqualTo(false));
            }
            [Test]
            public void ChecksPlateauIsValidInput()
            {
                InputParser parser = new InputParser();
                string testString = "10 1";

                bool output = parser.PlateauIsValidCheck(testString);

                Assert.That(output, Is.EqualTo(true));

                //UI ui = new UI();
                //bool output2 = ui.PlateauInput();
                //Assert.That(output2, Is.EqualTo(true));
            }
            [Test]
            public void ChecksPositionIsInValidInput()
            {
                InputParser parser = new InputParser();
                string testString = "1vvc 1w";

                bool output = parser.PositionIsValidCheck(testString);

                Assert.That(output, Is.EqualTo(false));
            }
            [Test]
            public void ChecksPositionIsValidInput()
            {
                InputParser parser = new InputParser();
                string testString = "1 1 w";

                bool output = parser.PositionIsValidCheck(testString);

                Assert.That(output, Is.EqualTo(true));
            }
            [Test]
            public void ChecksInstructionIsValidInput()
            {
                InputParser parser = new InputParser();
                string testString = "LLLLLR";

                bool output = parser.InstructionIsValidCheck(testString);

                Assert.That(output, Is.EqualTo(true));
            }
            [Test]
            public void ChecksInstructionIsValidInput2()
            {
                InputParser parser = new InputParser();
                string testString = "lllrr";

                bool output = parser.InstructionIsValidCheck(testString);

                Assert.That(output, Is.EqualTo(true));
            }
            [Test]
            public void ChecksInstructionIsinValidInput()
            {
                InputParser parser = new InputParser();
                string testString = "lll88rr";

                bool output = parser.InstructionIsValidCheck(testString);

                Assert.That(output, Is.EqualTo(false));
            }
        }

    public class DisplayTests
    {
        public Rover testRover1 = new Rover( 
            new Position(1, 2, CompassDirection.N), 
            new List<Instructs> { Instructs.L, Instructs.M, Instructs.R }, 
            new Plateau(5, 5)
        );

        [Test]
        public void DisplayRover()
        {
            Display.PrintRover(testRover1);
        }
        [Test]
        public void DisplayGrid()
        {

        }
    }
    }
    public class UIInteractionTests
    {
        [Test]
        public void RequestsText()
        {
            UI ui = new UI();
            string userInput = ui.RequestUserInput(2);
            Assert.That(userInput, Is.EqualTo(""));
        }
        [Test]

        public void PlateauInputChecker()
        {
            UI ui = new UI();
            var output = AppLogic.PlateauInput(ui.newParser.PlateauIsValid, ui.StringObject, ui);
            Assert.That(ui.StringObject.PlateauStr, Is.EqualTo("9 9"));
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
            UI ui = new UI();
            Movement logic = new Movement();
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
                            .AddPlateau(ui.newParser.PlateauParser(testPlateau))
                            .AddPosition(ui.newParser.PositionParser(firstRover))
                            .AddInstruction(ui.newParser.InstructionParser(firstInstructions))
                            .Build();
            rover = logic.BlackBox(rover);
            string output1 = "1 3 N";
            Rover roverExpected = new Rover(ui.newParser.PositionParser(firstRover),  ui.newParser.InstructionParser(firstInstructions),ui.newParser.PlateauParser(testPlateau));
            Assert.That(rover, Is.EqualTo(roverExpected));
        }

    }
    



