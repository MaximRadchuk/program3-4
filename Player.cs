using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Шашки
{
    class Player
    {
        public IStrategy strategy;
        public bool IsFirstPlayer { get; set; }
        public bool IsHuman { get; private set; }
        public Player()
        {
        }
        /// <summary>
        /// метод создания экземпляра игрока-компьютера
        /// </summary>
        /// <returns></returns>
        public static Player CreateComputerPlayer()
        {
            var player = new Player { IsHuman = false };
            player.strategy = ComputerStrategy.Instance;
            return player;
        }

        /// <summary>
        /// метод создания игрока-человека
        /// </summary>
        /// <returns></returns>
        public static Player CreateHumanPlayer()
        {
            var player = new Player { IsHuman = true };
            player.strategy = HumanStrategy.Instance;
            return player;
        }
        public void DoMove(List<Move> moves)
        {
            this.strategy.MakeMove(moves);
        }
        public void FinishMove(Move move)
        {
            var humanStrategy = strategy as HumanStrategy;

            if (humanStrategy != null)
            {
                humanStrategy.FinishMove(move);
            }
        }
       
    }
}
