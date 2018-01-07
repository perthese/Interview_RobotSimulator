using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyMovingSimulator
{
  public  class Dimension
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Dimension(): this(0,0)
        {

        }
        public Dimension(int rows,int columns)
        {
            Rows = rows;
            Columns = columns;
        }
    }
}
