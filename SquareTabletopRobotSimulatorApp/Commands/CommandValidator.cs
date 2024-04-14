public class CommandValidator
{
    public bool IsPlaceCommand(string command)
    {
        return command.StartsWith("PLACE");
    }
}