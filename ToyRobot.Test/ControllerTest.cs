using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToyRobotConsole;

namespace ToyRobot.Test
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void Move_Without_Place_Test()
        {
            const string expected = "0, 1, NORTH";
            var fakeRobot = new Mock<IRobot>();
            fakeRobot.Setup(r => r.Place(0, 0, Compass.North)).Returns(true);
            fakeRobot.Setup(r => r.Report()).Returns(expected);

            var target = new Controller(new Map(3, 3), fakeRobot.Object);
            target.Command("MOVE");
            target.Command("PLACE 0,0,NORTH");
            target.Command("MOVE");
            var actual = target.Command("REPORT");
            Assert.AreEqual(expected, actual);
        }
    }
}
