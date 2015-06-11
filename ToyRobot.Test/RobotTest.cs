using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotConsole;

namespace ToyRobot.Test
{
    /// <summary>
    /// Summary description for RobotTest
    /// </summary>
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void Invalid_Coordinates_Test()
        {
            var map = new Map(5, 5);
            var target = new Robot(map);
            var actual = target.Place(-1, -1, Compass.East);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Invalid_X_Coordinates_Test()
        {
            var map = new Map(5, 5);
            var target = new Robot(map);
            var actual = target.Place(-1, 0, Compass.East);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Invalid_Y_Coordinates_Test()
        {
            var map = new Map(5, 5);
            var target = new Robot(map);
            var actual = target.Place(0, 6, Compass.East);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Invalid_XY_Coordinates_Test()
        {
            var map = new Map(5, 5);
            var target = new Robot(map);
            var actual = target.Place(5, 6, Compass.East);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Report_Test()
        {
            var map = new Map(5, 5);
            var target = new Robot(map);
            var result = target.Place(1, 1, Compass.East);
            var actual = target.Report();
            Assert.IsTrue(result);
            Assert.AreEqual("1, 1, EAST", actual);
        }

        [TestMethod]
        public void Move_Report_Test()
        {
            var map = new Map(5, 5);
            var target = new Robot(map);
            var result = target.Place(1, 1, Compass.North);
            target.Move();
            var actual = target.Report();
            Assert.IsTrue(result);
            Assert.AreEqual("1, 2, NORTH", actual);
        }

        [TestMethod]
        public void Turn_Left_Report_Test()
        {
            var map = new Map(5, 5);
            var target = new Robot(map);
            var result = target.Place(1, 1, Compass.North);
            target.Turn(Direction.Left);
            var actual = target.Report();
            Assert.IsTrue(result);
            Assert.AreEqual("1, 1, WEST", actual);
        }

        [TestMethod]
        public void Turn_Leftx2_Report_Test()
        {
            var map = new Map(5, 5);
            var target = new Robot(map);
            var result = target.Place(1, 1, Compass.North);
            target.Turn(Direction.Left);
            target.Turn(Direction.Left);
            var actual = target.Report();
            Assert.IsTrue(result);
            Assert.AreEqual("1, 1, SOUTH", actual);
        }

        [TestMethod]
        public void Turn_Leftx3_Report_Test()
        {
            var map = new Map(5, 5);
            var target = new Robot(map);
            var result = target.Place(1, 1, Compass.North);
            target.Turn(Direction.Left);
            target.Turn(Direction.Left);
            target.Turn(Direction.Left);
            var actual = target.Report();
            Assert.IsTrue(result);
            Assert.AreEqual("1, 1, EAST", actual);
        }

        [TestMethod]
        public void Turn_Right_Report_Test()
        {
            var map = new Map(5, 5);
            var target = new Robot(map);
            var result = target.Place(1, 1, Compass.North);
            target.Turn(Direction.Right);
            var actual = target.Report();
            Assert.IsTrue(result);
            Assert.AreEqual("1, 1, EAST", actual);
        }

        [TestMethod]
        public void Turn_Rightx2_Report_Test()
        {
            var map = new Map(5, 5);
            var target = new Robot(map);
            var result = target.Place(1, 1, Compass.North);
            target.Turn(Direction.Right);
            target.Turn(Direction.Right);
            var actual = target.Report();
            Assert.IsTrue(result);
            Assert.AreEqual("1, 1, SOUTH", actual);
        }

        [TestMethod]
        public void Turn_Rightx3_Report_Test()
        {
            var map = new Map(5, 5);
            var target = new Robot(map);
            var result = target.Place(1, 1, Compass.North);
            target.Turn(Direction.Right);
            target.Turn(Direction.Right);
            target.Turn(Direction.Right);
            var actual = target.Report();
            Assert.IsTrue(result);
            Assert.AreEqual("1, 1, WEST", actual);
        }

        [TestMethod]
        public void Move_Off_Board_Report_Test()
        {
            var map = new Map(5, 5);
            var target = new Robot(map);
            var result = target.Place(4, 4, Compass.North);
            target.Move();
            var actual = target.Report();
            Assert.IsTrue(result);
            Assert.AreEqual("4, 4, NORTH", actual);
        }

        [TestMethod]
        public void Move_Off_Board_Report_Test2()
        {
            var map = new Map(2, 2);
            var target = new Robot(map);
            var result = target.Place(1, 1, Compass.South);
            target.Move();
            target.Move();
            var actual = target.Report();
            Assert.IsTrue(result);
            Assert.AreEqual("1, 0, SOUTH", actual);
        }
    }
}
