using Microsoft.VisualBasic;
using SquareTabletopRobotSimulatorApp.Commands.ICommands;

namespace SquareTabletopRobotSimulatorApp.Commands;

public class CommandValidator : ICommandValidator
{
    public bool IsPlaceCommand(string command)
    {
        return command.StartsWith("PLACE");
    }

    public bool IsValidCommandAction(string action)
    {
        return action is "PLACE" or "MOVE" or "LEFT" or "RIGHT" or "REPORT";
    }

    public bool IsPlaceCommandHasValidArguments(string argumentString)
    {
        var arguments = argumentString.Split(',');

        return arguments.Length == 3 &&
            int.TryParse(arguments[0], out int x) &&
            int.TryParse(arguments[1], out int y) &&
            Enum.TryParse(arguments[2], out Direction facing);
    }
}