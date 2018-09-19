using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BionicAnt.Test
{
    [TestClass]
    public class StampTests
    {
        private Stamp _Stamp;

        [TestInitialize]
        public void SetUp()
        {
            _Stamp = new Stamp(5, 5);
        }

        [TestMethod]
        public void Positive_Test()
        {
            // Arrange
            var rovers = new List<Rover>
            {
                new Rover
                {
                    Ant = new Ant {X = 1, Y = 2, Direction = Direction.N},
                    Command = "LMLMLMLMM"
                },
                new Rover
                {
                    Ant = new Ant {X = 3, Y = 3, Direction = Direction.E},
                    Command = "MMRMMRMRRM"
                }
            };
            
            // Act
            _Stamp.MoveAnts(rovers);

            // Assert
            Assert.AreEqual(rovers[0].Ant.X, 1);
            Assert.AreEqual(rovers[0].Ant.Y, 3);
            Assert.AreEqual(rovers[0].Ant.Direction, Direction.N);

            Assert.AreEqual(rovers[1].Ant.X, 5);
            Assert.AreEqual(rovers[1].Ant.Y, 1);
            Assert.AreEqual(rovers[1].Ant.Direction, Direction.E);
        }

        [TestMethod]
        public void Should_Not_Move_When_On_West_Border_Facing_West()
        {
            // Arrange
            var rovers = new List<Rover>
            {
                new Rover
                {
                    Ant = new Ant {X = 0, Y = 0, Direction = Direction.W},
                    Command = "M"
                }
            };
            // Act
            _Stamp.MoveAnts(rovers);

            // Assert
            Assert.AreEqual(rovers[0].Ant.X, 0);
            Assert.AreEqual(rovers[0].Ant.Y, 0);
            Assert.AreEqual(rovers[0].Ant.Direction, Direction.W);
        }

        [TestMethod]
        public void Should_Not_Move_When_On_East_Border_Facing_East()
        {
            // Arrange
            var rovers = new List<Rover>
            {
                new Rover
                {
                    Ant = new Ant {X = 5, Y = 0, Direction = Direction.E},
                    Command = "M"
                }
            };

            // Act
            _Stamp.MoveAnts(rovers);

            // Assert
            Assert.AreEqual(rovers[0].Ant.X, 5);
            Assert.AreEqual(rovers[0].Ant.Y, 0);
            Assert.AreEqual(rovers[0].Ant.Direction, Direction.E);
        }

        [TestMethod]
        public void Should_Not_Move_When_On_North_Border_Facing_North()
        {
            // Arrange
            var rovers = new List<Rover>
            {
                new Rover
                {
                    Ant = new Ant {X = 0, Y = 5, Direction = Direction.N},
                    Command = "M"
                }
            };

            // Act
            _Stamp.MoveAnts(rovers);

            // Assert
            Assert.AreEqual(rovers[0].Ant.X, 0);
            Assert.AreEqual(rovers[0].Ant.Y, 5);
            Assert.AreEqual(rovers[0].Ant.Direction, Direction.N);
        }

        [TestMethod]
        public void Should_Not_Move_When_On_South_Border_Facing_South()
        {
            // Arrange
            var rovers = new List<Rover>
            {
                new Rover
                {
                    Ant = new Ant {X = 3, Y = 0, Direction = Direction.S},
                    Command = "M"
                }
            };

            // Act
            _Stamp.MoveAnts(rovers);

            // Assert
            Assert.AreEqual(rovers[0].Ant.X, 3);
            Assert.AreEqual(rovers[0].Ant.Y, 0);
            Assert.AreEqual(rovers[0].Ant.Direction, Direction.S);
        }

        [TestMethod]
        public void Should_Throw_Exception_When_Invalid_Command()
        {
            // Arrange
            var rovers = new List<Rover>
            {
                new Rover
                {
                    Ant = new Ant {X = 3, Y = 0, Direction = Direction.S},
                    Command = "Invalid"
                }
            };
            
            // Assert
            Assert.ThrowsException<InvalidOperationException>(() => _Stamp.MoveAnts(rovers));
        }
    }
}
