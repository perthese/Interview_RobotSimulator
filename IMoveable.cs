using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyMovingSimulator
{
    interface IMoveable
    {
        bool Move();
        bool CheckMove();
    }
}
