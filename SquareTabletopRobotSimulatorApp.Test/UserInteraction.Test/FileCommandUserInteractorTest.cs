using Moq;
using Moq.Language;
using NUnit.Framework.Legacy;
using SquareTabletopRobotSimulatorApp.UserInteraction;
using SquareTabletopRobotSimulatorApp.UserInteraction.IUserInteraction;

namespace SquareTabletopRobotSimulatorApp.Test.UserInteraction.Test;

[TestFixture]
public class FileCommandUserInteractorTest
{
    [Test]
    public void PrintCommandOutput_SuccessFull()
    {
        // Arrange
        var outputFilePath = "output.txt";
        var msg = "Test message";
        var interactor = new FileCommandUserInteractor(outputFilePath, "commands.txt");

        // Act
        interactor.PrintCommandOutput(msg);

        // Assert
        Assert.That(true, Is.EqualTo(File.Exists(outputFilePath)));
        Assert.That(msg, Is.EqualTo(File.ReadAllText(outputFilePath).Trim()));
    }

    [Test]
    public void ReadCommandsFromUser_SuccessFull()
    {
        // Arrange
        var commandFilePath = "commands.txt";
        var expectedCommands = new[] { "PLACE", "MOVE", "RIGHT", "LEFT" };
        File.WriteAllLines(commandFilePath, expectedCommands);

        var interactor = new FileCommandUserInteractor("output.txt", commandFilePath);

        // Act
        var actualCommands = interactor.ReadCommandsFromUser();

        // Assert
        CollectionAssert.AreEqual(expectedCommands, actualCommands);
    }

    [Test]
    public void ReadCommandsFromUser_IsEmpty()
    {
        // Arrange
        var commandFilePath = "non_existing_commands.txt";
        var interactor = new FileCommandUserInteractor("output.txt", commandFilePath);

        // Act
        var actualCommands = interactor.ReadCommandsFromUser();

        // Assert
        CollectionAssert.IsEmpty(actualCommands);
    }
}

