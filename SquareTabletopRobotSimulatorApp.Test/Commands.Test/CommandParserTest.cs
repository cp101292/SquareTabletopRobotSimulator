using Moq;
using SquareTabletopRobotSimulatorApp.Commands;
using SquareTabletopRobotSimulatorApp.Commands.ICommands;
using SquareTabletopRobotSimulatorApp.Models;

namespace SquareTabletopRobotSimulatorApp.Test.Commands.Test;

[TestFixture]
public class CommandParserTest
{
    private CommandParser parser;
    private Mock<ICommand>? commandMock;
    private Mock<ICommandValidator>? validatorMock;
    private Robot robot;
    private Tabletop tabletop;

    [SetUp]
    public void Setup()
    {
        commandMock = new Mock<ICommand>();
        validatorMock = new Mock<ICommandValidator>();
        parser = new CommandParser(commandMock.Object, validatorMock.Object);

        robot = new Robot();
        tabletop = new Tabletop();
    }


    [Test]
    public void ParseCommand_ValidPlaceCommand_True()
    {
        // Arrange
        string commandString = "PLACE 1,2,NORTH";

        // Setup validator
        validatorMock.Setup(v => v.IsValidCommandAction("PLACE")).Returns(true);
        validatorMock.Setup(v => v.IsPlaceCommand("PLACE")).Returns(true);
        validatorMock.Setup(v => v.IsPlaceCommandHasValidArguments(It.IsAny<string>())).Returns(true);

        // Act
        parser.ParseCommand(commandString, robot, tabletop);

        // Assert
        commandMock.Verify(c => c.PlaceRobot(It.IsAny<string>(), robot, tabletop), Times.Once);
    }

    [Test]
    public void ParseCommand_MoveCommand_CallsMoveRobot()
    {
        // Arrange
        string commandString = "MOVE";

        // Setup validator
        validatorMock.Setup(v => v.IsValidCommandAction("PLACE")).Returns(true);
        validatorMock.Setup(v => v.IsValidCommandAction("MOVE")).Returns(true);
        parser.IsFirstValidCommand = true;

        // Act
        parser.ParseCommand(commandString, robot, tabletop);

        // Assert
        commandMock.Verify(c => c.MoveRobot(robot, tabletop), Times.Once);
    }

    [Test]
    public void ParseCommand_LeftCommand_CallsTurnLeft()
    {
        // Arrange
        string commandString = "LEFT";

        // Setup validator
        validatorMock.Setup(v => v.IsValidCommandAction("PLACE")).Returns(true);
        validatorMock.Setup(v => v.IsValidCommandAction("LEFT")).Returns(true);
        parser.IsFirstValidCommand = true;
        // Act
        parser.ParseCommand(commandString, robot, tabletop);

        // Assert
        commandMock.Verify(c => c.TurnLeft(robot), Times.Once);
    }

    [Test]
    public void ParseCommand_RightCommand_CallsTurnRight()
    {
        // Arrange
        string commandString = "RIGHT";

        // Setup validator
        validatorMock.Setup(v => v.IsValidCommandAction("PLACE")).Returns(true);
        validatorMock.Setup(v => v.IsValidCommandAction("RIGHT")).Returns(true);
        parser.IsFirstValidCommand = true;
        // Act
        parser.ParseCommand(commandString, robot, tabletop);

        // Assert
        commandMock.Verify(c => c.TurnRight(robot), Times.Once);
    }

    [Test]
    public void ParseCommand_ReportCommand_CallsReportRobotPosition()
    {
        // Arrange
        string commandString = "REPORT";

        // Setup validator
        validatorMock.Setup(v => v.IsValidCommandAction("PLACE")).Returns(true);
        validatorMock.Setup(v => v.IsValidCommandAction("REPORT")).Returns(true);
        parser.IsFirstValidCommand = true;
        // Act
        parser.ParseCommand(commandString, robot, tabletop);

        // Assert
        commandMock.Verify(c => c.ReportRobotPosition(robot), Times.Once);
    }

    [Test]
    public void ParseCommand_NullCommandString_ThrowsArgumentNullException()
    {
        // Arrange
        string commandString = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => parser.ParseCommand(commandString, robot, tabletop));
    }

    [Test]
    public void ParseCommand_InvalidCommandAction_ThrowsArgumentException()
    {
        // Arrange
        string commandString = "INVALID";


        // Setup validator
        validatorMock.Setup(v => v.IsValidCommandAction("INVALID")).Returns(false);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => parser.ParseCommand(commandString, robot, tabletop));
    }

    [Test]
    public void ParseCommand_PlaceCommandWithIncompleteParameters_ThrowsArgumentException()
    {
        // Arrange
        string commandString = "PLACE 1,2"; // Incomplete parameters

        // Setup validator
        validatorMock.Setup(v => v.IsValidCommandAction("PLACE")).Returns(true);
        validatorMock.Setup(v => v.IsPlaceCommand("PLACE")).Returns(true);
        parser.IsFirstValidCommand = true;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => parser.ParseCommand(commandString, robot, tabletop));
    }



}

