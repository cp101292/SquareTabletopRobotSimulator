using System.Net.Http.Headers;
using SquareTabletopRobotSimulatorApp;
using SquareTabletopRobotSimulatorApp.Commands;
using SquareTabletopRobotSimulatorApp.Models;
using SquareTabletopRobotSimulatorApp.UserInteraction;

var commands = new Commands(new FileCommandUserInteractor());
var tableTop = new Tabletop();
var commandParser = new CommandParser(commands, new CommandValidator());
var fileCommandUserInterface = new FileCommandUserInteractor();


//An entry point of the application.
RobotSimulatorApp robotSimulator = new RobotSimulatorApp(new Robot(),
    tableTop,
    commandParser,
    fileCommandUserInterface);

robotSimulator.StartSimulation();

Console.WriteLine("Execution completed {press any key to exit}");
Console.ReadKey();