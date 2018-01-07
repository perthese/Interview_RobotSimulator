using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyMovingSimulator
{
    public enum Direction
    {
        North,
        East,
        South,
        West,
        None
    }

    public enum Strategy {
        Default,
        RandomMove,
        ShortestPath
    }

    public enum Action
    {
        Initial,
        Move,
        ChangeDirection,
        InvalidMove
    }

}
