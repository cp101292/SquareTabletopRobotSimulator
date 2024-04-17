using SquareTabletopRobotSimulatorApp.Commands.ICommands;

namespace SquareTabletopRobotSimulatorApp.Commands;

public class CommandValidator : ICommandValidator
{
    public bool IsPlaceCommand(string command)
    {
        return command.StartsWith("PLACE");
    }
}