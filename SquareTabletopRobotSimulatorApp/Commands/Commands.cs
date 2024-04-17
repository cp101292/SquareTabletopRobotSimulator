using SquareTabletopRobotSimulatorApp;
using SquareTabletopRobotSimulatorApp.Commands.ICommands;
using SquareTabletopRobotSimulatorApp.Models;
using SquareTabletopRobotSimulatorApp.UserInteraction.IUserInteraction;

namespace SquareTabletopRobotSimulatorApp.Commands;

public class Commands : ICommand
{
    private readonly ICommandUserInteractor _commandUserInteraction;
    public Commands(ICommandUserInteractor commandUserInteraction)
    {
        _commandUserInteraction = commandUserInteraction;
    }
    public void PlaceRobot(string[] parameters, Robot robot, Tabletop tabletop)
    {
        if (parameters.Length == 2)
        {
            string[] coords = parameters[1].Split(',');
            if (coords.Length == 3 &&
                int.TryParse(coords[0], out int x) &&
                int.TryParse(coords[1], out int y) &&
                Enum.TryParse(coords[2], out Direction facing) &&
                tabletop.IsValidPosition(x, y))
            {
                robot.X = x;
                robot.Y = y;
                robot.Facing = facing;
            }
        }
    }

    public void MoveRobot(Robot robot, Tabletop tabletop)
    {
        switch (robot.Facing)
        {
            case Direction.NORTH:
                if (tabletop.IsValidPosition(robot.X, robot.Y + 1))
                {
                    robot.Y++;
                }
                break;
            case Direction.EAST:
                if (tabletop.IsValidPosition(robot.X + 1, robot.Y))
                {
                    robot.X++;
                }
                break;
            case Direction.SOUTH:
                if (tabletop.IsValidPosition(robot.X, robot.Y - 1))
                {
                    robot.Y--;
                }
                break;
            case Direction.WEST:
                if (tabletop.IsValidPosition(robot.X - 1, robot.Y))
                {
                    robot.X--;
                }
                break;
        }
    }

    public void TurnLeft(Robot robot)
    {
        switch (robot.Facing)
        {
            case Direction.NORTH:
                robot.Facing = Direction.WEST;
                break;
            case Direction.SOUTH:
                robot.Facing = Direction.EAST;
                break;
            case Direction.EAST:
                robot.Facing = Direction.NORTH;
                break;
            case Direction.WEST:
                robot.Facing = Direction.SOUTH;
                break;
        }
    }

    public void TurnRight(Robot robot)
    {
        switch (robot.Facing)
        {
            case Direction.NORTH:
                robot.Facing = Direction.EAST;
                break;
            case Direction.SOUTH:
                robot.Facing = Direction.WEST;
                break;
            case Direction.WEST:
                robot.Facing = Direction.NORTH;
                break;
            case Direction.EAST:
                robot.Facing = Direction.SOUTH;
                break;
        }
    }

    public void ReportRobotPosition(Robot robot)
    {
        _commandUserInteraction.PrintCommandOutput(robot.ToString());
    }
}