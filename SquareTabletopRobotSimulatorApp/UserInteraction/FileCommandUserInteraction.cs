public class FileCommandUserInteraction : ICommandUserInteraction
{

    // Output can be seen to the file bin\Debug\net8.0\output
    public void PrintCommandOutput(string msg)
    {
        string outputFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");

        // Create the output folder if it doesn't exist
        if (!Directory.Exists(outputFolderPath))
        {
            Directory.CreateDirectory(outputFolderPath);
        }

        string outputFile = Path.Combine(outputFolderPath, "output.txt");

        using StreamWriter writer = File.CreateText(outputFile);
        writer.WriteLine(msg);
    }

    public IEnumerable<string> ReadCommandsFromUser()
    {
        string commandFilePath = Path.Combine(Directory.GetCurrentDirectory(), "CommandInputFile\\command.txt");
        IEnumerable<string> commands = new List<string>();
        if (File.Exists(commandFilePath))
        {
            commands = File.ReadAllLines(commandFilePath);
        }
        return commands;
    }

}