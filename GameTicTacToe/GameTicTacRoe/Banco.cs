using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTicTacRoe
{
    class Banco
    {
        public static Pen pen;
        private int _Sodong;
        private int _Socot;
        public Banco(int sodong,int socot)
        {
            pen = new Pen(Color.Blue);
            this.Sodong = sodong;
            this.Socot = socot;
        }

        public int Sodong { get => _Sodong; set => _Sodong = value; }
        public int Socot { get => _Socot; set => _Socot = value; }

        public void Vebanco(Graphics g)
        {
            for(int i=0;i<=Socot;i++)
            {
                g.DrawLine(pen, i * Oco.weigth, 0, i * Oco.weigth, Sodong * Oco.Heigth);
            }

            for (int i = 0; i <= Sodong; i++)
            {
                g.DrawLine(pen, 0, i*Oco.Heigth, Socot*Oco.weigth,i*Oco.Heigth);
            }

        }
        public void Vequanco(Graphics g, Point point, SolidBrush sb)
        {
            g.FillEllipse(sb, point.X+2, point.Y+2, Oco.weigth-4, Oco.Heigth-4);
        }
    }
}
