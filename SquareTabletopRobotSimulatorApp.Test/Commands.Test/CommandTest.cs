using Moq;
using SquareTabletopRobotSimulatorApp.Models;
using SquareTabletopRobotSimulatorApp.UserInteraction.IUserInteraction;

namespace SquareTabletopRobotSimulatorApp.Test.Commands.Test;

[TestFixture]
public class CommandTest
{
    private Mock<ICommandUserInteractor> commandUserInteractorMock;
    private SquareTabletopRobotSimulatorApp.Commands.Commands commands;
    private Robot robot;
    private Tabletop tabletop;

    [SetUp]
    public void Setup()
    {
        commandUserInteractorMock = new Mock<ICommandUserInteractor>();
        commands = new SquareTabletopRobotSimulatorApp.Commands.Commands(commandUserInteractorMock.Object);
        robot = new Robot();
        tabletop = new Tabletop();
    }


    [Test]
    public void PlaceRobotTest()
    {
        //Arrange
        var parameters = "1,2,NORTH";

        //Act
        commands.PlaceRobot(parameters, robot, tabletop);

        //Assert
        Assert.That(1, Is.EqualTo(robot.X));
        Assert.That(2, Is.EqualTo(robot.Y));
        Assert.That(Direction.NORTH, Is.EqualTo(robot.Facing));
    }

    [Test]
    public void MoveRobot_ValidMove_North()
    {

        // Arrange
        robot = new Robot { X = 1, Y = 1, Facing = Direction.NORTH };

        // Act
        commands.MoveRobot(robot, tabletop);

        // Assert
        Assert.That(2, Is.EqualTo(robot.Y));
    }

    [Test]
    public void MoveRobot_ValidMove_East()
    {

        // Arrange
        robot = new Robot { X = 1, Y = 1, Facing = Direction.EAST };

        // Act
        commands.MoveRobot(robot, tabletop);

        // Assert
        Assert.That(2, Is.EqualTo(robot.X));
    }

    [Test]
    public void MoveRobot_ValidMove_South()
    {

        // Arrange
        robot = new Robot { X = 1, Y = 2, Facing = Direction.SOUTH };

        // Act
        commands.MoveRobot(robot, tabletop);

        // Assert
        Assert.That(1, Is.EqualTo(robot.Y));
    }

    [Test]
    public void MoveRobot_ValidMove_West()
    {

        // Arrange
        robot = new Robot { X = 2, Y = 1, Facing = Direction.WEST };

        // Act
        commands.MoveRobot(robot, tabletop);

        // Assert
        Assert.That(1, Is.EqualTo(robot.X));
    }

    [Test]
    public void TurnLeft_ValidTurn_North()
    {
        //Arrange
        robot = new Robot {Facing = Direction.NORTH };

        //Act
        commands.TurnLeft(robot);
        
        //Assert
        Assert.That(Direction.WEST, Is.EqualTo(robot.Facing));
    }
    [Test]
    public void TurnLeft_ValidTurn_South()
    {
        //Arrange
        robot = new Robot { Facing = Direction.SOUTH };

        //Act
        commands.TurnLeft(robot);

        //Assert
        Assert.That(Direction.EAST, Is.EqualTo(robot.Facing));
    }
    [Test]
    public void TurnLeft_ValidTurn_East()
    {
        //Arrange
        robot = new Robot { Facing = Direction.EAST };

        //Act
        commands.TurnLeft(robot);

        //Assert
        Assert.That(Direction.NORTH, Is.EqualTo(robot.Facing));
    }
    [Test]
    public void TurnLeft_ValidTurn_West()
    {
        //Arrange
        robot = new Robot { Facing = Direction.WEST };

        //Act
        commands.TurnLeft(robot);

        //Assert
        Assert.That(Direction.SOUTH, Is.EqualTo(robot.Facing));
    }

    [Test]
    public void TurnRight_ValidTurn_North()
    {
        //Arrange
        robot = new Robot { Facing = Direction.NORTH };

        //Act
        commands.TurnRight(robot);

        //Assert
        Assert.That(Direction.EAST, Is.EqualTo(robot.Facing));
    }
    [Test]
    public void TurnRight_ValidTurn_South()
    {
        //Arrange
        robot = new Robot { Facing = Direction.SOUTH };

        //Act
        commands.TurnRight(robot);

        //Assert
        Assert.That(Direction.WEST, Is.EqualTo(robot.Facing));
    }
    [Test]
    public void TurnRight_ValidTurn_East()
    {
        //Arrange
        robot = new Robot { Facing = Direction.EAST };

        //Act
        commands.TurnRight(robot);

        //Assert
        Assert.That(Direction.SOUTH, Is.EqualTo(robot.Facing));
    }
    [Test]
    public void TurnRight_ValidTurn_West()
    {
        //Arrange
        robot = new Robot { Facing = Direction.WEST };

        //Act
        commands.TurnRight(robot);

        //Assert
        Assert.That(Direction.NORTH, Is.EqualTo(robot.Facing));
    }

    [Test]
    public void ReportRobotPositionTest()
    {
        robot = new Robot { X = 1, Y = 2, Facing = Direction.NORTH };
        
        // Act
        commands.ReportRobotPosition(robot);

        // Assert
        commandUserInteractorMock.Verify(
            x => x.PrintCommandOutput("Output: 1,2,NORTH"), Times.Once);
    }
}

