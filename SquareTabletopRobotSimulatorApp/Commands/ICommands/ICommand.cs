using SquareTabletopRobotSimulatorApp.Models;

namespace SquareTabletopRobotSimulatorApp.Commands.ICommands;
public interface ICommand
{
    void PlaceRobot(string[] parameters, Robot robot, Tabletop tabletop);
    void MoveRobot(Robot robot, Tabletop tabletop);
    void TurnLeft(Robot robot);
    void TurnRight(Robot robot);
    void ReportRobotPosition(Robot robot);
}