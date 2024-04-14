namespace SquareTabletopRobotSimulatorApp.Models;

public class Tabletop
{
    public const int Width = 5;
    public const int Height = 5;

    public bool IsValidPosition(int x, int y)
    {
        return x is >= 0 and < Width && y is >= 0 and < Height;
    }
}