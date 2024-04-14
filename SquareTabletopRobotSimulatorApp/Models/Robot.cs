namespace SquareTabletopRobotSimulatorApp.Models;

public class Robot
{
    public Robot()
    {
        X = 0; Y = 0; Facing = Direction.NORTH;
    }
    public int X { get; set; }
    public int Y { get; set; }
    public Direction Facing { get; set; }

    public override string ToString()
    {
        return $"Output: {X},{Y},{Facing}";
    }
}