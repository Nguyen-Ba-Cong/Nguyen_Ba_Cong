using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTicTacRoe
{
    class Oco
    {
        public const int Heigth = 65;
        public const int weigth = 65;
        private int _Dong;
        private int _Cot;
        private Point _Vitri;
        private int _Sohuu;
        public int Dong { get => _Dong; set => _Dong = value; }
       
        public int Cot { get => _Cot; set => _Cot = value; }
        public Point Vitri { get => _Vitri; set => _Vitri = value; }
        public int Sohuu { get => _Sohuu; set => _Sohuu = value; }
        public Oco(int dong,int cot,Point vitri,int sohuu)
        {
            this.Dong = dong;
            this.Cot = cot;
            this.Vitri = vitri;
            this.Sohuu = sohuu;
        }
      public Oco()
        {

        }
        
    }
}
