using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Шашки
{
    public class FigureFactory: IControlFactory
    {
        public IFigure CreateKing(Color Color)
        {
            return new King(Color);
        }
        public IFigure CreateChecker(Color Color)
        {
            return new Checker(Color);
        }
    }
}
