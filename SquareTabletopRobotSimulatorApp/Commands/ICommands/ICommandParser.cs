using SquareTabletopRobotSimulatorApp.Models;

namespace SquareTabletopRobotSimulatorApp.Commands.ICommands;
public interface ICommandParser
{
    public void ParseCommand(string commandString, Robot robot, Tabletop tabletop);
}