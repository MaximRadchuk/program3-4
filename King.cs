using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Шашки
{
    public class King : IFigure
    {
        public King(Color Color)
        {
            this.Color = Color;
        }
        public Color Color { get; set; }
        public bool IsKing { get; set; }
        public List<Move> GetCells(Point p, bool IsFirstPlayer)
        {
           /* int x = p.X / step + startX;
            int y = p.Y / step + startY;
            Point[] cells = new Point[2];
            /*using (Graphics g = Graphics.FromImage(bm))
            {
                Pen pen = new Pen(Color.Green, 8);
                g.DrawRectangle(pen,x,y,step,step);
               // List<Point> points = new List<Point>();
               
            }*/
           return new List<Move>();
        }
        public List<Move> GetJustMove(Point p, bool IsFirstPlayer)
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
                while (i < 7 && j < 7)
                {
                    if (Game.Instance.Board[i + 1, j + 1] == null)
                        lst.Add(new Move(p, new Point(i + 1, j + 1), false));
                    else //if (Game.Instance.Board[i + 1, j + 1] != null && Game.Instance.Board[i + 1, j + 1].Color == Game.Instance.Board[p.X, p.Y].Color)
                        i = 8;
                    i++;
                    j++;
                }
                i = p.X;
                j = p.Y;
                while (i > 0 && j > 0)
                {
                    if (Game.Instance.Board[i - 1, j - 1] == null)
                        lst.Add(new Move(p, new Point(i - 1, j - 1), false));
                    else //if (Game.Instance.Board[i - 1, j - 1] != null && Game.Instance.Board[i - 1, j - 1].Color == Game.Instance.Board[p.X, p.Y].Color)
                        i = 0;
                    i--;
                    j--;
                }
                i = p.X;
                j = p.Y;
                while (i > 0 && j < 7)
                {
                    if (Game.Instance.Board[i - 1, j + 1] == null)
                        lst.Add(new Move(p, new Point(i - 1, j + 1), false));
                    else// if (Game.Instance.Board[i - 1, j + 1] != null && Game.Instance.Board[i - 1, j + 1].Color == Game.Instance.Board[p.X, p.Y].Color)
                        i = 0;
                    i--;
                    j++;
                }
                i = p.X;
                j = p.Y;
                while (i < 7 && j > 0)
                {
                    if (Game.Instance.Board[i + 1, j - 1] == null)
                        lst.Add(new Move(p, new Point(i + 1, j - 1), false));
                    else// if (Game.Instance.Board[i + 1, j - 1] != null && Game.Instance.Board[i + 1, j - 1].Color == Game.Instance.Board[p.X, p.Y].Color)
                        i = 8;
                    i++;
                    j--;
                }               
            }
            if (lst.Count == 0)
                return null;
            else
                return lst;
        }
        public List<Move> GetBeatMove(Point p, bool IsFirstPlayer)
        {
            int x = p.X;
            int y = p.Y;
            List<Move> beat = new List<Move>();
            if (Game.Instance.Board[x, y] == null)
            {
                return null;
            }
            if ((!IsFirstPlayer && Game.Instance.Board[x, y].Color == Color.Black) || (IsFirstPlayer && Game.Instance.Board[x, y].Color == Color.White))
            {
                while (x < 6 && y < 6)
                {
                    if (Game.Instance.Board[x + 1, y + 1] != null && Game.Instance.Board[x + 1, y + 1].Color != Game.Instance.Board[p.X, p.Y].Color && Game.Instance.Board[x + 2, y + 2] == null)
                    {  
                            beat.Add(new Move(p, new Point(x+2, y+2), true, new Point(x + 1, y + 1)));
                            x = 8;
                    }
                    else if (Game.Instance.Board[x + 1, y + 1] != null && Game.Instance.Board[x + 1, y + 1].Color == Game.Instance.Board[p.X, p.Y].Color)
                    {
                        x = 8;
                    }
                    else
                    {
                        x++;
                        y++;
                    }
                }
                x = p.X;
                y = p.Y;
                while(x>1 && y>1)
                {
                    if (Game.Instance.Board[x - 1, y - 1] != null && Game.Instance.Board[x - 1, y - 1].Color != Game.Instance.Board[p.X, p.Y].Color &&Game.Instance.Board[x - 2, y - 2] == null)
                    {
                        beat.Add(new Move(p, new Point(x-2,y-2), true, new Point(x - 1, y - 1)));
                            x = 0;                     
                    }
                    else if (Game.Instance.Board[x - 1, y - 1] != null && Game.Instance.Board[x - 1, y - 1].Color == Game.Instance.Board[p.X, p.Y].Color)
                    {
                        x = 0;
                    }
                    else
                    {
                        x--;
                        y--;
                    }
                }
                x = p.X;
                y = p.Y;
                while (x > 1 && y < 6)
                {
                    if (Game.Instance.Board[x - 1, y + 1] != null && Game.Instance.Board[x - 1, y + 1].Color != Game.Instance.Board[p.X, p.Y].Color && Game.Instance.Board[x - 2, y + 2] == null)
                    {
                        beat.Add(new Move(p, new Point(x-2,y+2), true, new Point(x - 1, y + 1)));
                            x = 0;                        
                    }
                    else if (Game.Instance.Board[x - 1, y + 1] != null && Game.Instance.Board[x - 1, y + 1].Color == Game.Instance.Board[p.X, p.Y].Color)
                    {
                        x = 0;
                    }
                    else
                    {
                        x--;
                        y++;
                    }
                }
                while (x < 6 && y >1)
                {
                    if (Game.Instance.Board[x + 1, y - 1] != null && Game.Instance.Board[x + 1, y - 1].Color != Game.Instance.Board[p.X, p.Y].Color &&Game.Instance.Board[x + 2, y - 2] == null)
                    {
                        beat.Add(new Move(p, new Point(x+2,y-2), true, new Point(x + 1, y - 1)));
                            x = 8;                       
                    }
                    else if (Game.Instance.Board[x + 1, y - 1] != null && Game.Instance.Board[x + 1, y - 1].Color == Game.Instance.Board[p.X, p.Y].Color)
                    {
                        x = 8;
                    }
                    else
                    {
                        x++;
                        y--;
                    }
                }
          }
            if (beat.Count == 0)
                return null;
            else
                return beat;
        }
    }
}
