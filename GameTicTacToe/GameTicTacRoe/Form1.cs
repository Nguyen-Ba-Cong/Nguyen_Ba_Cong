using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTicTacRoe
{
    public partial class Form1 : Form
    {
        private CaroChess CaroChess;
        private Graphics grs;
        public Form1()
        {
            InitializeComponent();
            CaroChess = new CaroChess();
            CaroChess.Khoitaomangoco();
            grs = pnlBanco.CreateGraphics();
           
        }

        private void PnlBanco_Paint(object sender, PaintEventArgs e)
        {
            CaroChess.VeBanCo(grs);
        }

        private void PnlBanco_MouseClick(object sender, MouseEventArgs e)
        {
            if (CaroChess.Danhco(e.X, e.Y, grs))
            {
                CaroChess.Danhco(e.X, e.Y, grs);
                if (CaroChess.Wincheck(1) || CaroChess.Wincheck(2) || CaroChess.Hoa())
                {
                    CaroChess.EndGame();
                }

                else
                {
                    CaroChess.play(grs);
                    if (CaroChess.Wincheck(1) || CaroChess.Wincheck(2) || CaroChess.Hoa())
                    {
                        CaroChess.EndGame();
                    }
                }
            }
            
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            grs.Clear(pnlBanco.BackColor);
            CaroChess.luotdi = 1;
            CaroChess.start(grs);
        }
    }
}
