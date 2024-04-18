using SquareTabletopRobotSimulatorApp.Models;

namespace SquareTabletopRobotSimulatorApp.Test.Models.Test
{
    [TestFixture]
    public class TabletopTest
    {
        private Tabletop _tabletop;

        [SetUp]
        public void Setup()
        {
            _tabletop = new Tabletop();
        }

        [TestCase(0,0)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        public void IsValidPosition_True(int x, int y)
        {
            // Arrange
            // Act
            bool isValid = _tabletop.IsValidPosition(x, y);

            // Assert
            Assert.That(true, Is.EqualTo(isValid));
        }

        [TestCase(-1, -1)]
        [TestCase(5, 4)]
        [TestCase(4, 5)]
        [TestCase(5, 5)]
        public void IsValidPosition_False(int x, int y)
        {
            // Arrange
            // Act
            bool isValid = _tabletop.IsValidPosition(x, y);

            // Assert
            Assert.That(false, Is.EqualTo(isValid));
        }
    }
}
