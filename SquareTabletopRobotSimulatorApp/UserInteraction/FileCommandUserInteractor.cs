using SquareTabletopRobotSimulatorApp.UserInteraction.IUserInteraction;

namespace SquareTabletopRobotSimulatorApp.UserInteraction;

public class FileCommandUserInteractor : ICommandUserInteractor
{
    private readonly string _outputFilePath;
    private readonly string _commandFilePath;

    public FileCommandUserInteractor(string outputFilePath, string commandFilePath)
    {
        _outputFilePath = outputFilePath;
        _commandFilePath = commandFilePath;
    }

    // Output can be seen to the file bin\Debug\net8.0\output
    public void PrintCommandOutput(string msg)
    {
        using StreamWriter writer = File.CreateText(_outputFilePath);
        writer.WriteLine(msg);
    }

    public IEnumerable<string> ReadCommandsFromUser()
    {
        IEnumerable<string> commands = new List<string>();
        if (File.Exists(_commandFilePath))
        {
            commands = File.ReadAllLines(_commandFilePath);
        }
        return commands;
    }
}