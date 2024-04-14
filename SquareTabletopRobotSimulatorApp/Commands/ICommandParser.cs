using SquareTabletopRobotSimulatorApp.Models;

public interface ICommandParser
{
    public void ParseCommand(string commandString, Robot robot, Tabletop tabletop);
}