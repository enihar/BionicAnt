using System;
using System.Collections.Generic;
using System.Linq;

namespace BionicAnt
{
    public class Stamp
    {
        private int _stampX;

        private int _stampY;

        public Stamp(int stampX, int stampY)
        {
            _stampX = stampX;
            _stampY = stampY;
        }

        public void MoveAnts(List<Rover> rovers)
        {
            foreach (var rover in rovers)
            {
                var commands = rover.Command.ToCharArray().ToList();

                while (commands.Any())
                {
                    switch (commands.First())
                    {
                        case 'L':
                            TurnLeft(rover.Ant);
                            break;
                        case 'R':
                            TurnRight(rover.Ant);
                            break;
                        case 'M':
                            MoveForward(rover.Ant);
                            break;
                        default:
                            throw new InvalidOperationException();
                    }

                    commands.RemoveAt(0);
                }
            }
        }

        private void TurnLeft(Ant ant)
        {
            switch (ant.Direction)
            {
                case Direction.E:
                    ant.Direction = Direction.N;
                    break;
                case Direction.W:
                    ant.Direction = Direction.S;
                    break;
                case Direction.N:
                    ant.Direction = Direction.W;
                    break;
                case Direction.S:
                    ant.Direction = Direction.E;
                    break;
            }
        }

        private void TurnRight(Ant ant)
        {
            switch (ant.Direction)
            {
                case Direction.E:
                    ant.Direction = Direction.S;
                    break;
                case Direction.W:
                    ant.Direction = Direction.N;
                    break;
                case Direction.N:
                    ant.Direction = Direction.E;
                    break;
                case Direction.S:
                    ant.Direction = Direction.E;
                    break;
            }
        }

        private void MoveForward(Ant ant)
        {
            switch (ant.Direction)
            {
                case Direction.E:
                    if (ant.X != _stampX) // if on the right border, don't move
                    {
                        ant.X = ant.X + 1;
                    }
                    break;
                case Direction.W:
                    if (ant.X != 0) // if on the left border, don't move
                    {
                        ant.X = ant.X - 1;
                    }
                    break;
                case Direction.N:
                    if (ant.Y != _stampY) // if on the top border, don't move
                    {
                        ant.Y = ant.Y + 1;
                    }
                    break;
                case Direction.S:
                    if (ant.Y != 0) // if on the bottom border, don't move
                    {
                        ant.Y = ant.Y - 1;
                    }
                    break;
            }
        }
    }
}
