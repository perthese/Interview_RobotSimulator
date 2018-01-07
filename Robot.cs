using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyMovingSimulator
{
    public class Robot : IMoveable, ILocated
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }

        private Dimension currentTable;

        private List<PositionHistory> history = new List<PositionHistory>();

        public Robot() : this(new Dimension())
        {

        }

        public Robot(Dimension dimension) : this(dimension, new Position(), new Direction())
        {

        }

        public Robot(int x, int y, Direction direction) : this(new Dimension(5, 5), new Position(x, y), direction)
        {

        }
        public Robot(Dimension dimension, Position position, Direction direction)
        {
            currentTable = dimension;
            Position = position;
            Direction = direction;
            history.Add(new PositionHistory(Position.X, Position.Y, Direction, Action.Initial));

        }

        public bool Move()
        {
            var status = CheckMove();
            if (status)
            {
                int deltaX, deltaY;

                CalculateMove(out deltaX, out deltaY);

                Position.X += deltaX;
                Position.Y += deltaY;

                history.Add(new PositionHistory(Position.X, Position.Y, Direction, Action.Move));
            }
            else
                history.Add(new PositionHistory(Position.X, Position.Y, Direction, Action.InvalidMove));
            return status;
        }

        public Direction GetDirection()
        {
            return Direction;
        }

        public bool SetDirection(Direction direction)
        {

            Direction = direction;
            history.Add(new PositionHistory(Position.X, Position.Y, Direction, Action.ChangeDirection));
            return true;
        }



        public bool CheckMove()
        {
            int deltaX, deltaY;

            CalculateMove(out deltaX, out deltaY);

            var checkX = Position.X + deltaX >= 0 && Position.X + deltaX <= currentTable.Columns;
            var checkY = Position.Y + deltaY >= 0 && Position.Y + deltaY <= currentTable.Rows;

            return checkX && checkY;
        }

        private void CalculateMove(out int deltaX, out int deltaY)
        {
            deltaX = 0;
            deltaY = 0;

            switch (Direction)
            {
                case Direction.East:
                    deltaX = 1;
                    break;
                case Direction.West:
                    deltaX = -1;
                    break;
                case Direction.North:
                    deltaY = -1;
                    break;
                case Direction.South:
                    deltaY = 1;
                    break;
            }
        }
        public void PrintHistory()
        {
            if (history.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("-----------------");
                Console.WriteLine("History of Robot:");
                foreach (var item in history)
                {
                    var line = String.Format("   X: {0}, Y: {1}, Direction: {2}, Action Type: {3}", item.X, item.Y, item.Direction, item.Action.ToString());
                    Console.WriteLine(line);
                }
            }
        }
        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------");
            Console.WriteLine("Current table dimension:");
            Console.WriteLine("   Rows: " + currentTable.Rows);
            Console.WriteLine("   Columns: " + currentTable.Columns);
            Console.WriteLine("Current Direction: " + Direction.ToString());
            Console.WriteLine("Current position for Robot:");
            Console.WriteLine("   X: " + Position.X);
            Console.WriteLine("   Y: " + Position.Y);
        }
    }
}
