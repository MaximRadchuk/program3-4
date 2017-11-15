using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Шашки
{
    public class Checker : IFigure
    {
        public Checker(Color Color)
        {
            this.Color = Color;
        }
        public Color Color { get; set; }
        public bool IsKing { get; set; }
        public List<Move> GetJustMove(Point p, bool IsFirstPlayer)
        {
            int i = p.X;
            int j = p.Y;
            List<Move> lst = new List<Move>();
            if (Game.Instance.Board[i, j] == null)
            {
                return null;
            }
            if (!IsFirstPlayer && Game.Instance.Board[i, j].Color == Color.Black)
            {
                if (j >= 0 && j < 7 && i > 0 && i < 7)
                {
                    if (Game.Instance.Board[i + 1, j + 1] == null)
                        lst.Add(new Move(p, new Point(i + 1, j + 1), false));
                    if (Game.Instance.Board[i - 1, j + 1] == null)
                        lst.Add(new Move(p, new Point(i - 1, j + 1), false));
                }
                else if (i == 0 && j >= 0 && j < 7)
                {
                    if (Game.Instance.Board[i + 1, j + 1] == null)
                        lst.Add(new Move(p, new Point(i + 1, j + 1), false));
                }
                else if (i == 7 && j >= 0 && j < 7)
                {
                    if (Game.Instance.Board[i - 1, j + 1] == null)
                        lst.Add(new Move(p, new Point(i - 1, j + 1), false));
                }
            }
            else
                if (IsFirstPlayer && Game.Instance.Board[i, j].Color == Color.White)
                {
                    if (j > 0 && j <= 7 && i > 0 && i < 7)
                    {
                        if (Game.Instance.Board[i + 1, j - 1] == null)
                            lst.Add(new Move(p, new Point(i + 1, j - 1), false));
                        if (Game.Instance.Board[i - 1, j - 1] == null)
                            lst.Add(new Move(p, new Point(i - 1, j - 1), false));
                    }
                    else if (i == 0 && j > 0 && j <= 7)
                    {
                        if (Game.Instance.Board[i + 1, j - 1] == null)
                            lst.Add(new Move(p, new Point(i + 1, j - 1), false));
                    }
                    else if (i == 7 && j > 0 && j <= 7)
                    {
                        if (Game.Instance.Board[i - 1, j - 1] == null)
                            lst.Add(new Move(p, new Point(i - 1, j - 1), false));
                    }
                }
            if (lst.Count == 0)
                return null;
            else
                return lst;
        }
        public List<Move> GetBeatMove(Point p, bool IsFirstPlayer)
        {

            int i = p.X;
            int j = p.Y;
            List<Move> lst = new List<Move>();
            if (Game.Instance.Board[i, j] == null)
            {
                return null;
            }
            if ((!IsFirstPlayer && Game.Instance.Board[i, j].Color == Color.Black) || (IsFirstPlayer && Game.Instance.Board[i, j].Color == Color.White))
            {

                if (i >= 2 && i <= 5 && j >= 2 && j <= 5)
                {
                    if (Game.Instance.Board[i + 1, j + 1] != null && Game.Instance.Board[i + 1, j + 1].Color != Game.Instance.Board[i, j].Color)
                    {
                        if (Game.Instance.Board[i + 2, j + 2] == null)
                            lst.Add(new Move(p, new Point(i + 2, j + 2), true, new Point(i + 1, j + 1)));
                    }
                    if (Game.Instance.Board[i - 1, j + 1] != null && Game.Instance.Board[i - 1, j + 1].Color != Game.Instance.Board[i, j].Color)
                    {
                        if (Game.Instance.Board[i - 2, j + 2] == null)
                            lst.Add(new Move(p, new Point(i - 2, j + 2), true, new Point(i - 1, j + 1)));
                    }
                    if (Game.Instance.Board[i - 1, j - 1] != null && Game.Instance.Board[i - 1, j - 1].Color != Game.Instance.Board[i, j].Color)
                    {
                        if (Game.Instance.Board[i - 2, j - 2] == null)
                            lst.Add(new Move(p, new Point(i - 2, j - 2), true, new Point(i - 1, j - 1)));
                    }
                    if (Game.Instance.Board[i + 1, j - 1] != null && Game.Instance.Board[i + 1, j - 1].Color != Game.Instance.Board[i, j].Color)
                    {
                        if (Game.Instance.Board[i + 2, j - 2] == null)
                            lst.Add(new Move(p, new Point(i + 2, j - 2), true, new Point(i + 1, j - 1)));
                    }
                }

                if (i >= 0 && i <= 1 && j >= 0 && j <= 1)
                {
                    if (Game.Instance.Board[i + 1, j + 1] != null && Game.Instance.Board[i + 1, j + 1].Color != Game.Instance.Board[i, j].Color)
                    {
                        if (Game.Instance.Board[i + 2, j + 2] == null)
                            lst.Add(new Move(p, new Point(i + 2, j + 2), true, new Point(i + 1, j + 1)));
                    }
                }
                else if (i >= 6 && i <= 7 && j >= 0 && j <= 1)
                {
                    if (Game.Instance.Board[i - 1, j + 1] != null && Game.Instance.Board[i - 1, j + 1].Color != Game.Instance.Board[i, j].Color)
                    {
                        if (Game.Instance.Board[i - 2, j + 2] == null)
                            lst.Add(new Move(p, new Point(i - 2, j + 2), true, new Point(i - 1, j + 1)));
                    }
                }
                else if (i >= 0 && i <= 1 && j >= 6 && j <= 7)
                {
                    if (Game.Instance.Board[i + 1, j - 1] != null && Game.Instance.Board[i + 1, j - 1].Color != Game.Instance.Board[i, j].Color)
                    {
                        if (Game.Instance.Board[i + 2, j - 2] == null)
                            lst.Add(new Move(p, new Point(i + 2, j - 2), true, new Point(i + 1, j - 1)));
                    }
                }
                else if (i >= 6 && i <= 7 && j >= 6 && j <= 7)
                {
                    if (Game.Instance.Board[i - 1, j - 1] != null && Game.Instance.Board[i - 1, j - 1].Color != Game.Instance.Board[i, j].Color)
                    {
                        if (Game.Instance.Board[i - 2, j - 2] == null)
                            lst.Add(new Move(p, new Point(i - 2, j - 2), true, new Point(i - 1, j - 1)));
                    }
                }

                else if (i >= 0 && i <= 1 && j >= 2 && j <= 5)
                {
                    if (Game.Instance.Board[i + 1, j - 1] != null && Game.Instance.Board[i + 1, j - 1].Color != Game.Instance.Board[i, j].Color)
                    {
                        if (Game.Instance.Board[i + 2, j - 2] == null)
                            lst.Add(new Move(p, new Point(i + 2, j - 2), true, new Point(i + 1, j - 1)));
                    }
                    if (Game.Instance.Board[i + 1, j + 1] != null && Game.Instance.Board[i + 1, j + 1].Color != Game.Instance.Board[i, j].Color)
                    {
                        if (Game.Instance.Board[i + 2, j + 2] == null)
                            lst.Add(new Move(p, new Point(i + 2, j + 2), true, new Point(i + 1, j + 1)));
                    }
                }
                else if (i >= 6 && i <= 7 && j >= 2 && j <= 5)
                {
                    if (Game.Instance.Board[i - 1, j - 1] != null && Game.Instance.Board[i - 1, j - 1].Color != Game.Instance.Board[i, j].Color)
                    {
                        if (Game.Instance.Board[i - 2, j - 2] == null)
                            lst.Add(new Move(p, new Point(i - 2, j - 2), true, new Point(i - 1, j - 1)));
                    }
                    if (Game.Instance.Board[i - 1, j + 1] != null && Game.Instance.Board[i - 1, j + 1].Color != Game.Instance.Board[i, j].Color)
                    {
                        if (Game.Instance.Board[i - 2, j + 2] == null)
                            lst.Add(new Move(p, new Point(i - 2, j + 2), true, new Point(i - 1, j + 1)));
                    }
                }
                else if (i >= 2 && i <= 5 && j >= 0 && j <= 1)
                {
                    if (Game.Instance.Board[i - 1, j + 1] != null && Game.Instance.Board[i - 1, j + 1].Color != Game.Instance.Board[i, j].Color)
                    {
                        if (Game.Instance.Board[i - 2, j + 2] == null)
                            lst.Add(new Move(p, new Point(i - 2, j + 2), true, new Point(i - 1, j + 1)));
                    }
                    if (Game.Instance.Board[i + 1, j + 1] != null && Game.Instance.Board[i + 1, j + 1].Color != Game.Instance.Board[i, j].Color)
                    {
                        if (Game.Instance.Board[i + 2, j + 2] == null)
                            lst.Add(new Move(p, new Point(i + 2, j + 2), true, new Point(i + 1, j + 1)));
                    }
                }
                else if (i >= 2 && i <= 5 && j >= 6 && j <= 7)
                {
                    if (Game.Instance.Board[i - 1, j - 1] != null && Game.Instance.Board[i - 1, j - 1].Color != Game.Instance.Board[i, j].Color)
                    {
                        if (Game.Instance.Board[i - 2, j - 2] == null)
                            lst.Add(new Move(p, new Point(i - 2, j - 2), true, new Point(i - 1, j - 1)));
                    }
                    if (Game.Instance.Board[i + 1, j - 1] != null && Game.Instance.Board[i + 1, j - 1].Color != Game.Instance.Board[i, j].Color)
                    {
                        if (Game.Instance.Board[i + 2, j - 2] == null)
                            lst.Add(new Move(p, new Point(i + 2, j - 2), true, new Point(i + 1, j - 1)));
                    }
                }

            }
            if (lst.Count == 0)
                return null;
            else
                return lst;
        } 
    }
}
