using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Caro
{
    class O_Co
    {
        public const int _ChieuRong = 16;
        public const int _ChieuCao = 16;

        private int _Dong;
        private int _Cot;
        private Point _ViTri;
        private int _SoHuu;


        public int Dong { get => _Dong; set => _Dong = value; }
        public int Cot { get => _Cot; set => _Cot = value; }
        public Point ViTri { get => _ViTri; set => _ViTri = value; }
        public int SoHuu { get => _SoHuu; set => _SoHuu = value; }
        public O_Co(int dong, int cot, Point vitri, int sohuu)
        {
            _Dong = dong;
            _Cot = cot;
            _ViTri = vitri;
            _SoHuu = sohuu; 
        }
        public O_Co() { }
    }
}
