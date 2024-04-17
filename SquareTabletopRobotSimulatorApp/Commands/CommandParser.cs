using SquareTabletopRobotSimulatorApp.Commands.ICommands;
using SquareTabletopRobotSimulatorApp.Models;

namespace SquareTabletopRobotSimulatorApp.Commands;
public class CommandParser : ICommandParser
{
    private readonly ICommand _command;
    private readonly ICommandValidator _validator;
    private bool isFirstValidCommand = false;

    public CommandParser(ICommand command, ICommandValidator validator)
    {
        _command = command;
        _validator = validator;
    }
    public void ParseCommand(string commandString, Robot robot, Tabletop tabletop)
    {
        string[] parts = commandString.Trim().Split(' ');
        string action = parts[0];


        if (!isFirstValidCommand && !_validator.IsPlaceCommand(action))
        {
            // Ignore commands until a valid PLACE command is encountered
            return;
        }

        if (!isFirstValidCommand)
        {
            isFirstValidCommand = true;
        }


        switch (action)
        {
            case "PLACE":
                _command.PlaceRobot(parts, robot, tabletop);
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