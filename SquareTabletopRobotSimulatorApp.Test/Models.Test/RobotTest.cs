using SquareTabletopRobotSimulatorApp.Models;

namespace SquareTabletopRobotSimulatorApp.Test.Models.Test
{
    [TestFixture]
    public class RobotTest
    {
        [Test]
        public void RobotInitialValueTest()
        {
            var robot = new Robot();

            Assert.That(0, Is.EqualTo(robot.X));
            Assert.That(0, Is.EqualTo(robot.Y));
            Assert.That(Direction.NORTH, Is.EqualTo(robot.Facing));
        }

        [Test]
        public void RobotToStringTest()
        {
            var robot = new Robot();
            string str = $"Output: 0,0,NORTH";

            Assert.That(str, Is.EqualTo(robot.ToString()));
        }
    }
}
