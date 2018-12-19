using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_Caro
{
    class Ban_Co
    {
        private int _SoDong;
        private int _SoCot;

        public int SoCot { get => _SoCot; set => _SoCot = value; }
        public int SoDong { get => _SoDong; set => _SoDong = value; }

        public Ban_Co()
        {
            _SoDong = 0;
            _SoCot = 0;
        }
        public Ban_Co(int Dong, int Cot)
        {
            _SoCot = Cot;
            _SoDong = Dong;
        }
        public void VeBanCo(Graphics g)
        {
            for(int i = 0; i <= _SoCot; i++)
            {
                g.DrawLine(Caro_Chess.pen, i * O_Co._ChieuRong, 0, i * O_Co._ChieuRong, _SoDong * O_Co._ChieuCao); 
            }
            for(int j = 0; j <= _SoDong; j++)
            {
                g.DrawLine(Caro_Chess.pen, 0, j * O_Co._ChieuCao, _SoCot * O_Co._ChieuRong, j * O_Co._ChieuCao);
            }
        }
        public void VeQuanCo(Graphics g, Point point, SolidBrush sb)
        {
            g.FillEllipse(sb, point.X + 1, point.Y + 1, O_Co._ChieuRong - 2, O_Co._ChieuCao - 2);
        }
        public void XoaQuanCo(Graphics g, Point point, SolidBrush sb)
        {
            g.FillRectangle(sb, point.X + 1, point.Y +1 , O_Co._ChieuRong - 2, O_Co._ChieuCao -2 );
        }
    }
}
