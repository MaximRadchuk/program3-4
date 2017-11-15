using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Шашки
{
    public partial class Form1 : Form
    {
        Board board;
        private readonly HumanAdapter playerAdapter;
        public Form1()
        {
            InitializeComponent();
            board = new Board(boardPic.Width,boardPic.Height);
            playerAdapter = new HumanAdapter();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void boardPic_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = e.X.ToString() + " ; " + e.Y.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Start_Game_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Game.CreateInstance(radioButton2.Checked ? false : true, radioButton4.Checked ? false : true,boardPic.Width,boardPic.Height);
            boardPic.Image = board.DrawFigures((Bitmap)boardPic.Image);
            //
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            boardPic.Image = board.DrawBoard();

        }

        public void ShowVictory(string player)
        {
            MessageBox.Show(player + " win!");
        }

        private void boardPic_MouseClick(object sender, MouseEventArgs e)
        {
            /*try
            {
                if (board.CellIsEmpty(new Point(e.X, e.Y)))
                    boardPic.Image = board.GetCells(new Point((int)e.X, (int)e.Y), (Bitmap)boardPic.Image);
            }
            catch
            {
                MessageBox.Show("Вы нажали вне поля");
            }
             */
            playerAdapter.Click(ChangeCoor(new Point(e.X,e.Y)));
            boardPic.Image = Game.Instance.visio.Update();
           
        }

        private void boardPic_Click(object sender, EventArgs e)
        {

        }
        
        private Point ChangeCoor(Point p)
        {
            int step = 75;
            return new Point(p.X / step, p.Y / step);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            boardPic.Image = Game.Instance.visio.Update();
            /*boardPic.Image = board.DrawBoard();
            boardPic.Image = board.DrawFigures((Bitmap)boardPic.Image);
            boardPic.Image = board.GetCells((Bitmap)boardPic.Image);
             */
        }
    }
}
