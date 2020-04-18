using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTicTacRoe
{
    public enum Ketthuc
    {
        Hoa,
        Player,
        Com
    }
    class CaroChess
    {  
        public static SolidBrush sbRed;
        public static SolidBrush sbBlack;
        private Oco[,] _MangOco;
        private Banco _Banco;
        private Ketthuc _ketthuc;
        public int luotdi;

        public CaroChess()
        {
            sbRed = new SolidBrush(Color.Red);
            sbBlack = new SolidBrush(Color.Black);
            _Banco = new Banco(3, 3);
            _MangOco = new Oco[_Banco.Sodong, _Banco.Socot];
            luotdi = 1;
        }
        public void VeBanCo(Graphics g)
        {
            _Banco.Vebanco(g);
        }
        public void Khoitaomangoco()
        {
            for (int i = 0; i < _Banco.Sodong; i++)
            {
                for (int j = 0; j < _Banco.Socot; j++)
                {
                    _MangOco[i, j] = new Oco(i, j, new Point(j * Oco.weigth, i * Oco.Heigth), 0);
                }
            }
        }
        public bool Danhco(int MouseX, int MouseY, Graphics g)
        {
            int cot = MouseX / Oco.weigth;
            int dong = MouseY / Oco.Heigth;
            if (_MangOco[dong, cot].Sohuu == 0)
            {
                switch (luotdi)
                {
                    case 1:
                        _MangOco[dong, cot].Sohuu = 1;
                        _Banco.Vequanco(g, _MangOco[dong, cot].Vitri, sbBlack);
                        luotdi = 2;
                        break;
                    case 2:
                        _MangOco[dong, cot].Sohuu = 2;
                        _Banco.Vequanco(g, _MangOco[dong, cot].Vitri, sbRed);
                        luotdi = 1;
                        break;
                    default:
                        MessageBox.Show("Loi");
                        break;
                }
                return true;
            }
            return false;
        }
        public void start(Graphics g)
        {
            Khoitaomangoco();
            VeBanCo(g);       
        }
        public void EndGame()
        {
            if(_ketthuc==Ketthuc.Com)
            {
                MessageBox.Show("Com win");
            }
            else if (_ketthuc == Ketthuc.Player)
            {
                MessageBox.Show("Player win");
            }
            else if (_ketthuc == Ketthuc.Hoa)
            {
                MessageBox.Show("Hoa");
            }
        }
        public bool Wincheck(int a)
        {
            for(int i=0;i<3;i++)
            {
                if(_MangOco[0,i].Sohuu== a && _MangOco[1,i].Sohuu==a && _MangOco[2,i].Sohuu==a )
                {
                    if(a==1)
                    {
                        _ketthuc = Ketthuc.Player;
                    }
                    else if(a==2)
                    {
                        _ketthuc = Ketthuc.Com;
                    }
                    return true; 
                }
                if (_MangOco[i,0].Sohuu == a && _MangOco[i,1].Sohuu ==a && _MangOco[i,2].Sohuu == a)
                {
                    if (a == 1)
                    {
                        _ketthuc = Ketthuc.Player;
                    }
                    else if (a == 2)
                    {
                        _ketthuc = Ketthuc.Com;
                    }
                    return true;
                }
            }
            if(_MangOco[0,0].Sohuu==a && _MangOco[1,1].Sohuu== a && _MangOco[2,2].Sohuu==a )
            {
                if (a == 1)
                {
                    _ketthuc = Ketthuc.Player;
                }
                else if (a == 2)
                {
                    _ketthuc = Ketthuc.Com;
                }
                return true;
            }
            if (_MangOco[0, 2].Sohuu == a && _MangOco[1, 1].Sohuu == a && _MangOco[2, 0].Sohuu == a)
            {
                if (a == 1)
                {
                    _ketthuc = Ketthuc.Player;
                }
                else if (a == 2)
                {
                    _ketthuc = Ketthuc.Com;
                }
                return true;
            }
            return false;
        }
        public bool Hoa()
        {
            if(Wincheck(0)|| Wincheck(1))
            {
                return false;
            }
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<3;j++)
                {
                    if(_MangOco[i,j].Sohuu==0)
                    {
                        return false;
                    }
                }
            }
            _ketthuc = Ketthuc.Hoa;
            return true;
        }
        public int MaxSearch()
        {
             
             if(Wincheck(1))
             {
                 return 10;
             }
             else if (Wincheck(2))
             {
                 return -10;
             }
             else if(Hoa())
             {
                 return 0;
             }
            else
            {
                int score2 = -1000;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (_MangOco[i, j].Sohuu == 0)
                        {
                            _MangOco[i, j].Sohuu = 1;
                            if (score2 < MinSearch())
                            {
                                score2 = MinSearch();
                            }
                            _MangOco[i, j].Sohuu = 0;
                        }
                    }
                }
                return score2;
            }
        }
        public int MinSearch()
        {
            if (Wincheck(1))
            {
                return 10;
            }
            else if (Wincheck(2))
            {
                return -10;
            }
            else if (Hoa())
            {
                return 0;
            }
            else
            {
                int score2 = 1000;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (_MangOco[i, j].Sohuu == 0)
                        {
                            _MangOco[i, j].Sohuu = 2;
                            if(score2> MaxSearch())
                            {
                                score2 = MaxSearch();
                            }
                            _MangOco[i, j].Sohuu = 0;
                        }
                    }
                }
                
                return score2;
            }
        }
        public Oco Minimax()
        {
            Oco ocoresult = new Oco();
            int score = 1000;
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<3;j++)
                {
                    if(_MangOco[i,j].Sohuu==0)
                    {
                        _MangOco[i, j].Sohuu = 2;

                        int t = MaxSearch();
                     
                        if (t < score)
                        {
                            score = t;                           
                            ocoresult = new Oco(_MangOco[i, j].Dong, _MangOco[i, j].Cot, _MangOco[i, j].Vitri, _MangOco[i, j].Sohuu);                           
                        }
                        _MangOco[i, j].Sohuu = 0;
                    }
                }
            }
            return ocoresult;
        }       
        public void play(Graphics g)
        {
            Oco oco = Minimax();
            Danhco(oco.Vitri.X, oco.Vitri.Y, g);         
        }
    }
}
