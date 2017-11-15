using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Шашки
{
    public interface IStrategy
    {
        void MakeMove(List<Move> move);
    }
}
