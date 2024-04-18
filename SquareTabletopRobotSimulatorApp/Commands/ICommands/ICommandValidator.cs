namespace SquareTabletopRobotSimulatorApp.Commands.ICommands;

public interface ICommandValidator
{
    bool IsPlaceCommand(string command);
    bool IsValidCommandAction(string action);

    bool IsPlaceCommandHasValidArguments(string argumentString);
}
