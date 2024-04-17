namespace SquareTabletopRobotSimulatorApp.UserInteraction.IUserInteraction;
public interface ICommandUserInteractor
{
    public void PrintCommandOutput(string msg);
    IEnumerable<string> ReadCommandsFromUser();
}