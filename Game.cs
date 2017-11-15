using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
namespace Шашки
{
    class Game
    {
        public IFigure [,] Board { get; private set; }
        IControlFactory factory;
        public Board visio;
        public List<Move> PossibleFigures { get; private set; }
        public List<Move> PossibleCells { get; private set; }
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public Game(bool isFirstPlayerHuman, bool isSecondPlayerHuman,int w,int h)
        {
            Board = new IFigure[8, 8];
            visio = new Board(w, h);
            this.Player1 = isFirstPlayerHuman ? Player.CreateHumanPlayer() : Player.CreateComputerPlayer();
            this.Player2 = isSecondPlayerHuman ? Player.CreateHumanPlayer() : Player.CreateComputerPlayer();
            
        }

        public Player OtherPlayer { get { return CurrentPlayer == Player1 ? Player2 : Player1; } }

        public static Game Instance { get; private set; }
        public void DoMove()
        {
           
        }
        public static void CreateInstance(bool isFirstPlayerHuman, bool isSecondPlayerHuman,int w,int h)
        {
            Instance = new Game(isFirstPlayerHuman,isSecondPlayerHuman,w,h);
            Instance.Start();
        }
        public void FinishMove(Move move)
        {
            if (Board[move.from.X, move.from.Y].IsKing == false || !KingOrChecker(move))
            {
                Game.Instance.Board[move.to.X, move.to.Y] = factory.CreateChecker(Board[move.from.X, move.from.Y].Color);
            }
            if (KingOrChecker(move) || Board[move.from.X, move.from.Y].IsKing == true)
            {
                Game.Instance.Board[move.to.X, move.to.Y] = factory.CreateKing(Board[move.from.X, move.from.Y].Color);
                Board[move.to.X, move.to.Y].IsKing = true;
               // visio.Update();
            }
            if(move.IskillingMove)
            {
                Board[move.Killedpoint.X, move.Killedpoint.Y] = null;
                PossibleFigures = Board[move.to.X, move.to.Y].GetBeatMove(new Point(move.to.X, move.to.Y), CurrentPlayer.IsFirstPlayer);
                if (PossibleFigures!=null)
                {
                    Board[move.from.X, move.from.Y] = null;
                    
                    PossibleCells = PossibleFigures;
                    if (PossibleFigures.Count == 0)//если у кого-то больше нет ходов, показываем, кто победил
                    {
                        this.ShowVictory(CurrentPlayer == Player2 ? "The first player" : "The second player");
                        return;
                    }
                    CurrentPlayer.DoMove(PossibleFigures);
                    return;
                }
            }
            Board[move.from.X, move.from.Y] = null;
            CurrentPlayer = OtherPlayer;
            PossibleCells = null;
            PossibleFigures = GetPossibleFugures(CurrentPlayer.IsFirstPlayer);
            if (PossibleFigures.Count == 0)//если у кого-то больше нет ходов, показываем, кто победил
            {
                this.ShowVictory(CurrentPlayer == Player2 ? "The first player" : "The second player");
                return;
            }
            CurrentPlayer.DoMove(GetPossibleFugures(CurrentPlayer.IsFirstPlayer));
            visio.Update();
        }
        public void Start()
        {
            factory = new FigureFactory();
            Player1.IsFirstPlayer = true;
            Player2.IsFirstPlayer = false;
            CurrentPlayer = Player1;
            SetFigures();
            PossibleFigures = GetPossibleFugures(CurrentPlayer.IsFirstPlayer);
            CurrentPlayer.DoMove(GetPossibleFugures(CurrentPlayer.IsFirstPlayer));
            
        }
        public bool KingOrChecker(Move move)
        {
            bool check = false;
            if(Board[move.from.X, move.from.Y].Color == Color.Black)
            {
                if (move.to.Y == 7)
                {
                    check = true;
                }
            }
            if (Board[move.from.X, move.from.Y].Color == Color.White)
            {
                if (move.to.Y == 0)
                {
                    check = true;
                }
            }
            return check;
        }
        public void SavePossibleCells(Point point)
        {
            PossibleCells = Board[point.X, point.Y].GetBeatMove(point, CurrentPlayer.IsFirstPlayer);
            if (PossibleCells == null)
            {
            PossibleCells = Board[point.X,point.Y].GetJustMove(point, CurrentPlayer.IsFirstPlayer);
            }
        }
        private List<Move> GetPossibleMoves(Player player)
        {
            return GetPossibleFugures(CurrentPlayer.IsFirstPlayer);
        }
        public void SetFigures()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1)
                    {
                        Game.Instance.Board[j,i] = factory.CreateChecker(Color.Black);
                        Game.Instance.Board[j, i].IsKing = false;
                       
                    }
                    if ((i + 5) % 2 != 0 && j % 2 != 0 || (i + 5) % 2 == 0 && j % 2 == 0)
                    {
                        Game.Instance.Board[j, i+5] = factory.CreateChecker(Color.White);
                        Game.Instance.Board[j, i+5].IsKing = false;
                    }
                    
                }
               
            }
        }
        private void ShowVictory(string player)
        {
            Form1 f = new Form1();
            f.ShowVictory(player);
        }
        public  List<Move> GetPossibleFugures(bool IsFirstPlayer)
        {
          
            List<Move> lst = new List<Move>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Point p = new Point(i, j);
                    var temp = Board[i, j] == null ? null : Board[i, j].GetBeatMove(p, IsFirstPlayer);
                    if (temp != null)
                        lst.AddRange(temp);
                }

            }
            if (lst.Count == 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Point p = new Point(i, j);
                        var temp = Board[i, j] == null ? null : Board[i, j].GetJustMove(p, IsFirstPlayer);
                        if (temp != null)
                            lst.AddRange(temp);
                    }

                }
            }
            return lst;
        }
    }
}
