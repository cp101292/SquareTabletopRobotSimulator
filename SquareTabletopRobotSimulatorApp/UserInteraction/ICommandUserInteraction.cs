public interface ICommandUserInteraction
{
    public void PrintCommandOutput(string msg);
    IEnumerable<string> ReadCommandsFromUser();
}