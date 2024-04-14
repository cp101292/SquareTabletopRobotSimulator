using System.Net.Http.Headers;
using SquareTabletopRobotSimulatorApp;
using SquareTabletopRobotSimulatorApp.Models;

var commands = new Commands(new FileCommandUserInteraction());
var tableTop = new Tabletop();
var commandParser = new CommandParser(commands);
var fileCommandUserInterface = new FileCommandUserInteraction();


//An entry point of the application.
RobotSimulatorApp robotSimulator = new RobotSimulatorApp(new Robot(),
    tableTop,
    commandParser,
    fileCommandUserInterface);

robotSimulator.StartSimulation();

Console.WriteLine("Execution completed {press any key to exit}");
Console.ReadKey();