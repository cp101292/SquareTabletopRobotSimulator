using SquareTabletopRobotSimulatorApp.Commands.ICommands;
using SquareTabletopRobotSimulatorApp.Models;

namespace SquareTabletopRobotSimulatorApp.Commands;
public class CommandParser : ICommandParser
{
    private readonly ICommand _command;
    private readonly ICommandValidator _validator;
    public bool IsFirstValidCommand = false;

    public CommandParser(ICommand command, ICommandValidator validator)
    {
        _command = command;
        _validator = validator;
    }
    public void ParseCommand(string commandString, Robot robot, Tabletop tabletop)
    {
        if (string.IsNullOrEmpty(commandString))
        {
            throw new ArgumentNullException(nameof(commandString));
        }

        var parts = commandString.Trim().Split(' ');
        var action = parts[0];

        if (!_validator.IsValidCommandAction(action))
        {
            throw new ArgumentException("Invalid command: " + action);
        }

        if (!IsFirstValidCommand && !_validator.IsPlaceCommand(action))
        {
            return;
        }

        if (!IsFirstValidCommand)
        {
            IsFirstValidCommand = true;
        }


        switch (action)
        {
            case "PLACE":
                if (string.IsNullOrEmpty(parts[1]) || !_validator.IsPlaceCommandHasValidArguments(parts[1]))
                {
                    throw new ArgumentException("Invalid PLACE command: " + commandString);
                }
                _command.PlaceRobot(parts[1], robot, tabletop);
                break;

            case "MOVE":
                _command.MoveRobot(robot, tabletop);
                break;

            case "LEFT":
                _command.TurnLeft(robot);
                break;

            case "RIGHT":
                _command.TurnRight(robot);
                break;

            case "REPORT":
                _command.ReportRobotPosition(robot);
                break;
        }
    }
}