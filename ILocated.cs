using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyMovingSimulator
{
    interface ILocated
    {
        Direction GetDirection();
        bool SetDirection(Direction direction);

     
    }
}
