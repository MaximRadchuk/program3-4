using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Шашки
{
    class HumanAdapter
    {
        private Point lastSelected;
       // private bool last;
        public HumanAdapter()
        {
            //last = false;
        }
        public void Click(Point point)
        {
            var currentPlayer = Game.Instance.CurrentPlayer;

            if (!currentPlayer.IsHuman)
            {
                return;
            }
            
            if (Game.Instance.PossibleFigures.FirstOrDefault(x => x.from == point)==null && Game.Instance.PossibleCells == null)
            {
                return;
            }
            if (Game.Instance.PossibleFigures.FirstOrDefault(x => x.from == point) != null)
            {
                Game.Instance.SavePossibleCells(point);
                lastSelected = point;
            }

            if (Game.Instance.PossibleCells.FirstOrDefault(x => x.to == point)!=null )
            {
                currentPlayer.FinishMove(Game.Instance.PossibleCells.FirstOrDefault(x => x.to == point));
              //Game.Instance.FinishMove( Game.Instance.PossibleCells.FirstOrDefault(x => x._to == point));
            }
        }
    }
}
