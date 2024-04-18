using SquareTabletopRobotSimulatorApp.Commands;
using System.ComponentModel.DataAnnotations;

namespace SquareTabletopRobotSimulatorApp.Test.Commands.Test
{
    [TestFixture]
    public class CommandValidatorTest
    {
        private CommandValidator validator;

        [SetUp]
        public void SetUp()
        {
            validator = new CommandValidator();
        }

        [Test]
        public void PlaceCommand_ValidPlaceCommand_True()
        {
            //Act
            var isPlaceCommand = validator.IsPlaceCommand("PLACE");
            //Assert
            Assert.That(isPlaceCommand, Is.True);
        }

        [Test]
        public void PlaceCommand_ValidPlaceCommand_False()
        {
            //Act
            var isPlaceCommand = validator.IsPlaceCommand("INVALID");
            //Assert
            Assert.That(isPlaceCommand, Is.False);
        }

        
        [TestCase("PLACE")]
        [TestCase("MOVE")]
        [TestCase("LEFT")]
        [TestCase("RIGHT")]
        [TestCase("REPORT")]
        public void IsValidCommandAction_True(string commandName)
        {
            //Act
            var isPlaceCommand = validator.IsValidCommandAction(commandName);
            //Assert
            Assert.That(isPlaceCommand, Is.True);
        }

        [Test]
        public void IsValidCommandAction_False()
        {
            //Act
            var isPlaceCommand = validator.IsValidCommandAction("INVALID");
            //Assert
            Assert.That(isPlaceCommand, Is.False);
        }

        [Test]
        public void IsPlaceCommandHasValidArguments_True()
        {
            //Arrange
            // Arrange
            string commandString = "1,2,NORTH";
            //Act
            var isPlaceCommand = validator.IsPlaceCommandHasValidArguments(commandString);
            //Assert
            Assert.That(isPlaceCommand, Is.True);
        }

        [TestCase("1,2,DOWN")]
        [TestCase("A,2,NORTH")]
        [TestCase("1,B,NORTH")]
        public void IsPlaceCommandHasValidArguments_False(string commandText)
        {
            //Arrange 

            //Act
            var isPlaceCommand = validator.IsPlaceCommandHasValidArguments(commandText);
            //Assert
            Assert.That(isPlaceCommand, Is.False);
        }
    }
}
