using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace Шашки
{
    public interface IFigure
    {
        Color Color { get; set; }
        List<Move> GetJustMove(Point p, bool IsFirstPlayer);
        List<Move> GetBeatMove(Point p, bool IsFirstPlayer);

        bool IsKing { get; set; }
    }
}
