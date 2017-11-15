using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Шашки
{
    public class Move
    {
        public Point from { get; set; }
        public Point to { get; set; }
        public bool IskillingMove { get; set; }
        public Point Killedpoint { get; set; }
        public Move(Point from, Point to, bool kill)
        {
            this.from =from;
            this.to = to;
            this.IskillingMove = kill;
        }
        public Move(Point from, Point to, bool kill, Point killpoint)
        {
            this.from = from;
            this.to = to;
            this.IskillingMove = kill;
            this.Killedpoint = killpoint;
        }
    }
}
