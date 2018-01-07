using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyMovingSimulator
{
   public static class Helper
    {
       public  static Direction GetRandomNewDirection(Direction previousDirection)
        {
            int limitTimes = 10;
            int count = 0;
            var direction = GetRandomDirection();
            while(direction == previousDirection&& count < limitTimes)
            {
                direction = GetRandomDirection();
            }
            return direction;
        }

        public static Direction GetRandomDirection()
        {
            Random random = new Random();
            int randomDirection = random.Next(1, 4);
            var direction = Direction.East;
            switch (randomDirection)
            {
                case 1:
                    direction = Direction.North;
                    break;
                case 2:
                    direction = Direction.East;
                    break;
                case 3:
                    direction = Direction.South;
                    break;
                case 4:
                    direction = Direction.West;
                    break;
            }
            return direction;
        }
    }
}
