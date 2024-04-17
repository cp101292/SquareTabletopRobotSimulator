namespace SquareTabletopRobotSimulatorApp.Commands.ICommands;

public interface ICommandValidator
{
    public bool IsPlaceCommand(string command);
}
