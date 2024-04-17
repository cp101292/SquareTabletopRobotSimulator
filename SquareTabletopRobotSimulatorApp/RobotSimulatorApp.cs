using SquareTabletopRobotSimulatorApp.Commands.ICommands;
using SquareTabletopRobotSimulatorApp.Models;
using SquareTabletopRobotSimulatorApp.UserInteraction.IUserInteraction;

public class RobotSimulatorApp
{
    private Robot _robot;
    private Tabletop _tabletop;
    private readonly ICommandParser _commandParser;
    private readonly ICommandUserInteractor _commanUserInteraction;

    public RobotSimulatorApp(Robot robot, Tabletop tabletop, ICommandParser commandParser, ICommandUserInteractor commandUserInteraction)
    {
        _robot = robot;
        _tabletop = tabletop;
        _commandParser = commandParser;
        _commanUserInteraction = commandUserInteraction;
    }

    public void StartSimulation()
    {
        // Read input commands and execute them
        var commands = _commanUserInteraction.ReadCommandsFromUser();

        //Parse and process the command one by one
        foreach (string command in commands)
        {
            _commandParser.ParseCommand(command, _robot, _tabletop);
        }
    }

}