using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyMovingSimulator
{
   public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x,int y)
        {
            X = x;
            Y = y;
        }

        public Position(): this(0,0)
        {

        }
    }

    public class PositionHistory:Position
    {
        public Direction Direction { get; set; }
        public Action Action{ get; set; }

        public PositionHistory(int x,int y,Direction direction, Action action):base(x,y)
        {
            Direction = direction;
            Action = action;
        }
    }
}
