using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace Шашки
{
    public class Board
    {
        Bitmap bm;
       
        public IFigure[,] boardMatr;
        public Board(int width, int height)
        {
            bm = new Bitmap(width, height);
            boardMatr = new IFigure[8, 8];
        }
        public Board()
        {

        }
        public Bitmap DrawBoard()
        {
            Draw();
            return bm;
        }
        private void Draw()
        {
            
            SolidBrush blackBrush = new SolidBrush(Color.LightGray);
            SolidBrush whiteBrush = new SolidBrush(Color.White);

            using (Graphics g = Graphics.FromImage(bm))
            {
               
                g.Clear(Color.Gray);

                int startX = 20;
                int startY = 20;
                int step = 75;
                DrawStr(g, startX - 20, startY + 28);
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1)
                        {
                            g.FillRectangle(blackBrush, startX, startY, step, step);
                            startX += step;
                        }
                        else
                        {
                            g.FillRectangle(whiteBrush, startX, startY, step, step);
                            startX += step;
                        }
                    }
                    startX = 20;
                    startY += step;
                }
                blackBrush.Dispose();
                whiteBrush.Dispose();
            }
        }
        private void DrawStr(Graphics g, int startX, int startY)
        {
            int step = 75;
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            Font f = new Font("Colibri", 10);
            for (int i = 0; i < 8; i++)
            {
                g.DrawString((i + 1).ToString(), f, blackBrush, startX, startY);
                startY += step;
            }
            blackBrush.Dispose();
            f.Dispose();
        }
        public Bitmap DrawFigures(Bitmap bm)
        {
            using (Graphics g = Graphics.FromImage(bm))
            {
                
                int ChangeCoor = 75;
                int step = 55;
                SolidBrush blackBrush = new SolidBrush(Color.Black);
                SolidBrush whiteBrush = new SolidBrush(Color.LightYellow);
                Font f = new Font("Arial",26);
                
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (Game.Instance.Board[i,j] != null)
                        {
                            if(Game.Instance.Board[i,j].Color == Color.White)
                            {
                                g.FillEllipse(whiteBrush, i*ChangeCoor +30, j*ChangeCoor +30, step, step);
                                if (Game.Instance.Board[i, j].IsKing)
                                    g.DrawString("D", f, blackBrush, i * ChangeCoor + 40, j * ChangeCoor + 40);
                            }
                            if (Game.Instance.Board[i, j].Color == Color.Black)
                            {
                                g.FillEllipse(blackBrush, i * ChangeCoor + 30, j * ChangeCoor + 30, step, step);
                                if (Game.Instance.Board[i, j].IsKing)
                                    g.DrawString("D", f, whiteBrush, i * ChangeCoor + 40, j * ChangeCoor + 40);
                            }
                        }
                    }
                }

                blackBrush.Dispose();
                whiteBrush.Dispose();
                f.Dispose();
            }
            return bm;
        }
        public Bitmap GetCells(Bitmap bm)
        {
            if (Game.Instance.PossibleCells == null)
            {
                return bm ;
            }
            int startX = 20;
            int startY = 20;
            int step = 75;
            using (Graphics g = Graphics.FromImage(bm))
            {
                Pen pen = new Pen(Color.LightGreen, 5);
                Pen greenPen = new Pen(Color.Green,5);
                
                    foreach (Move pt in Game.Instance.PossibleCells)
                    {
                        g.DrawRectangle(pen, pt.to.X * step + startX, pt.to.Y * step + startY, step, step);
                    }
                pen.Dispose();
            }
            return bm;
        }
        /*public Bitmap GetGreen(Point p, Bitmap bm)
        {
            int startX = 20;
            int startY = 20;
            int step = 75;
            int x = p.X / step;
            int y = p.Y / step;
            List<Point> cell = boardMatr[0, 0].GetCells(p, boardMatr);
            x = x * step + startX;
            y = y * step + startY;
            using (Graphics g = Graphics.FromImage(bm))
            {
                Pen pen = new Pen(Color.LightGreen, 5);
                Pen greenPen = new Pen(Color.Green, 5);
                g.DrawRectangle(greenPen, x, y, step, step);
                foreach (Point pt in cell)
                {
                    y = pt.X * step + startY;
                    x = pt.Y * step + startX;
                    g.DrawRectangle(pen, x, y, step, step);
                }
                pen.Dispose();
            }
            return bm;
        }
         */
        public bool CellIsEmpty(Point p)
        {
            int step = 75;
            int j = p.X / step;
            int i = p.Y / step;
                if (boardMatr[i, j] == null)
                    return false;
                else
                    return true;

        }
        public Bitmap Update()
        {
            bm = DrawBoard();
            bm = DrawFigures(bm);
            bm = GetCells(bm);
            return bm;
        }
    }
}
