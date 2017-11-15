using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Шашки
{
    class ComputerStrategy : IStrategy
    {
        private readonly Random random;

        private static ComputerStrategy instance;
        public static ComputerStrategy Instance { get { return instance = instance ?? new ComputerStrategy(); } }

        private ComputerStrategy()
        {
            this.random = new Random();
        }
        public void MakeMove(List<Move> moves)
        {
            var move = GetRandomMove(moves);
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1);
                Application.DoEvents();
            }
            Game.Instance.FinishMove(move);// 
        }
        private Move GetRandomMove(List<Move> moves)
        {
            var ind = random.Next(moves.Count);
            return moves[ind];
        }
    }
}
