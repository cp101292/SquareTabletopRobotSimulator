using System.Net.Http.Headers;
using SquareTabletopRobotSimulatorApp;
using SquareTabletopRobotSimulatorApp.Commands;
using SquareTabletopRobotSimulatorApp.Models;
using SquareTabletopRobotSimulatorApp.UserInteraction;
using SquareTabletopRobotSimulatorApp.UserInteraction.IUserInteraction;

const string outputFileName = "output.txt";
const string commandInputFileName = "CommandInputFile\\command.txt";

string outputFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,outputFileName );
string commandFilePath = Path.Combine(Directory.GetCurrentDirectory(), commandInputFileName);

ICommandUserInteractor fileCommandUserInteractor = new FileCommandUserInteractor(outputFolderPath, commandFilePath);

var commands = new Commands(fileCommandUserInteractor);
var tableTop = new Tabletop();
var commandParser = new CommandParser(commands, new CommandValidator());


//An entry point of the application.
RobotSimulatorApp robotSimulator = new RobotSimulatorApp(new Robot(),
    tableTop,
    commandParser,
    fileCommandUserInteractor);

robotSimulator.StartSimulation();

Console.WriteLine("Execution completed {press any key to exit}");
Console.ReadKey();