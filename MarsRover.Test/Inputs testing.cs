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
}
    



