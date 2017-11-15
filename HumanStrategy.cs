using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Шашки
{
    class HumanStrategy : IStrategy
    {
        public List<Move> PossibleMove;
        private static HumanStrategy instance;
        public static HumanStrategy Instance { get { return instance = instance ?? new HumanStrategy(); } }
        public void MakeMove(List<Move> moves)
        {
            this.PossibleMove = moves;
        }

        public void FinishMove(Move move)
        {

            if (move == null)
            {
                return;
            }

            Game.Instance.FinishMove(move);
        }
        private void GetPossibleMove()
        {

        }
    }
}
