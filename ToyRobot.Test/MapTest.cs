using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotConsole;

namespace ToyRobot.Test
{
    [TestClass]
    public class MapTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid value, values must be > 0")]
        public void Invalid_X_Coordinate_Test()
        {
            var map = new Map(0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid value, values must be > 0")]
        public void Invalid_Y_Coordinate_Test()
        {
            var map = new Map(1, 0);
        }

        [TestMethod]
        public void Valid_Coordinates_Test()
        {
            var map = new Map(5, 5);
            Assert.IsNotNull(map);
        }

        [TestMethod]
        public void OffGrid_Coordinates_Test()
        {
            var map = new Map(5, 5);
            var actual = map.IsOnMap(6, 6);
            Assert.AreEqual(false,actual);
        }

    }
}
