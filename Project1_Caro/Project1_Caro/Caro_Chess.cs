using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1_Caro
{
    public enum KETTHUC
    {
        Hoa,
        Player1,
        Player2,
        Player,
        COM
    }
    class Caro_Chess
    {
        public static Pen pen;
        public static SolidBrush sbWhite;
        public static SolidBrush sbBlack;
        public static SolidBrush sbGray;
        private O_Co[,] _MangOCo;
        private Ban_Co _BanCo;
        private Stack<O_Co> stack_CacNuocDaDi;
        private Stack<O_Co> stack_CacNuocUndo;
        private int _LuotDi;
        private bool _SanSang;
        private KETTHUC _KetThuc;
        private int _PlayMode;

        public bool SanSang { get => _SanSang; set => _SanSang = value; }
        public int PlayMode { get => _PlayMode; set => _PlayMode = value; }

        public Caro_Chess()
        {
            pen = new Pen(Color.Black);
            sbWhite = new SolidBrush(Color.White);
            sbBlack = new SolidBrush(Color.Black);
            sbGray = new SolidBrush(Color.Gray);
            _BanCo = new Ban_Co(20, 23);
            _MangOCo = new O_Co[_BanCo.SoDong, _BanCo.SoCot];
            stack_CacNuocDaDi = new Stack<O_Co>();
            stack_CacNuocUndo = new Stack<O_Co>();
            _LuotDi = 1;
        }
        #region Tương tác với bàn cờ
        public void VeBanCo(Graphics g)
        {
            _BanCo.VeBanCo(g);
        }
        public void KhoiTaoMangOCo()
        {
            for (int i = 0; i < _BanCo.SoDong; i++)
            {
                for (int j = 0; j < _BanCo.SoCot; j++)
                {
                    _MangOCo[i, j] = new O_Co(i, j, new Point(j * O_Co._ChieuRong, i * O_Co._ChieuCao), 0);

                }
            }
        }
        public bool DanhCo(int MouseX, int MouseY, Graphics g)
        {
            if (MouseX % O_Co._ChieuRong == 0
                || MouseY % O_Co._ChieuCao == 0)
                return false;
            int Cot = MouseX / O_Co._ChieuRong;
            int Dong = MouseY / O_Co._ChieuCao;
            if (_MangOCo[Dong, Cot].SoHuu != 0)
            {
                return false;
            }


            switch (_LuotDi)
            {
                case 1:
                    _MangOCo[Dong, Cot].SoHuu = 1;
                    _BanCo.VeQuanCo(g, _MangOCo[Dong, Cot].ViTri, sbBlack);
                    _LuotDi = 2;
                    break;
                case 2:
                    _MangOCo[Dong, Cot].SoHuu = 2;
                    _BanCo.VeQuanCo(g, _MangOCo[Dong, Cot].ViTri, sbWhite);
                    _LuotDi = 1;
                    break;
                default:
                    MessageBox.Show("Error!!!");
                    break;
            }
            stack_CacNuocUndo = new Stack<O_Co>();
            O_Co oco = new O_Co(_MangOCo[Dong, Cot].Dong, _MangOCo[Dong, Cot].Cot, _MangOCo[Dong, Cot].ViTri, _MangOCo[Dong, Cot].SoHuu);
            stack_CacNuocDaDi.Push(oco);
            return true;
        }
        public void VeLaiQuanCo(Graphics g)
        {
            foreach (O_Co oco in stack_CacNuocDaDi)
            {
                if (oco.SoHuu == 1)
                    _BanCo.VeQuanCo(g, oco.ViTri, sbBlack);
                else if (oco.SoHuu == 2)
                    _BanCo.VeQuanCo(g, oco.ViTri, sbWhite);
            }
        }
        #endregion
        public void StartPlayervsPlayer(Graphics g)
        {
            _SanSang = true;
            stack_CacNuocDaDi = new Stack<O_Co>();
            stack_CacNuocUndo = new Stack<O_Co>();
            _LuotDi = 1;
            PlayMode = 1;
            KhoiTaoMangOCo();
            VeBanCo(g);
        }
        public void StartPlayervsCom(Graphics g)
        {
            _SanSang = true;
            stack_CacNuocDaDi = new Stack<O_Co>();
            stack_CacNuocUndo = new Stack<O_Co>();
            _LuotDi = 1;
            PlayMode = 2;
            KhoiTaoMangOCo();
            VeBanCo(g);
            StartComputer(g);   
        }
        #region Undo Redo
        public void Undo(Graphics g)
        {
            if (stack_CacNuocDaDi.Count != 0)
            {
                if(_PlayMode == 1)
                {
                    O_Co oco = stack_CacNuocDaDi.Pop();

                    stack_CacNuocUndo.Push(new O_Co(oco.Dong, oco.Cot, oco.ViTri, oco.SoHuu));
                    _MangOCo[oco.Dong, oco.Cot].SoHuu = 0;
                    _BanCo.XoaQuanCo(g, oco.ViTri, sbGray);
                    if (_LuotDi == 1)
                        _LuotDi = 2;
                    else
                        _LuotDi = 1;
                }
                else
                {
                    if (stack_CacNuocDaDi.Count == 1) return;
                    O_Co del = stack_CacNuocDaDi.Pop();
                    O_Co oco = stack_CacNuocDaDi.Pop();
                    stack_CacNuocUndo.Push(new O_Co(del.Dong, del.Cot, del.ViTri, del.SoHuu));
                    
                   
                    _MangOCo[del.Dong, del.Cot].SoHuu = 0;
                    _BanCo.XoaQuanCo(g, del.ViTri, sbGray);
                    

                   
                    stack_CacNuocUndo.Push(new O_Co(oco.Dong, oco.Cot, oco.ViTri, oco.SoHuu));
                    _MangOCo[oco.Dong, oco.Cot].SoHuu = 0;
                    _BanCo.XoaQuanCo(g, oco.ViTri, sbGray);
                    _LuotDi = 2;

                }
            }

            //VeBanCo(g);
            //VeLaiQuanCo(g);

        }
        public void Redo(Graphics g)
        {
            if (stack_CacNuocUndo.Count != 0)
            {
                if (_PlayMode == 1)
                {
                    O_Co oco = stack_CacNuocUndo.Pop();
                    stack_CacNuocDaDi.Push(new O_Co(oco.Dong, oco.Cot, oco.ViTri, oco.SoHuu));
                    _MangOCo[oco.Dong, oco.Cot].SoHuu = oco.SoHuu;
                    _BanCo.VeQuanCo(g, oco.ViTri, oco.SoHuu == 1 ? sbBlack : sbWhite);
                    if (_LuotDi == 1)
                        _LuotDi = 2;
                    else
                        _LuotDi = 1;
                }
                else
                {
                    if(stack_CacNuocUndo.Count >= 2)
                    {
                        O_Co oco = stack_CacNuocUndo.Pop();
                        stack_CacNuocDaDi.Push(new O_Co(oco.Dong, oco.Cot, oco.ViTri, oco.SoHuu));
                        O_Co del = stack_CacNuocUndo.Pop();
                        stack_CacNuocDaDi.Push(new O_Co(del.Dong, del.Cot, del.ViTri, del.SoHuu));
                        _MangOCo[oco.Dong, oco.Cot].SoHuu = oco.SoHuu;
                        _BanCo.VeQuanCo(g, oco.ViTri, oco.SoHuu == 1 ? sbBlack : sbWhite);


                        _MangOCo[del.Dong, del.Cot].SoHuu = del.SoHuu;
                        _BanCo.VeQuanCo(g, del.ViTri, del.SoHuu == 1 ? sbBlack : sbWhite);

                        _LuotDi = 2;
                    }
                    
                }
            }

            //VeBanCo(g);
            //VeLaiQuanCo(g);

        }
        #endregion
        #region Duyệt chiến thắng
        public void KetThucGame()
        {
            switch (_KetThuc)
            {
                case KETTHUC.Hoa:
                    MessageBox.Show("Hòa rồi!!!");
                    stack_CacNuocDaDi.Clear();
                    break;
                case KETTHUC.Player1:
                    MessageBox.Show("Người chơi 1 chiến thắng!");
                    stack_CacNuocDaDi.Clear();
                    break;
                case KETTHUC.Player2:
                    MessageBox.Show("Người chơi 2 chiến thắng!");
                    stack_CacNuocDaDi.Clear();
                    break;
                case KETTHUC.Player:
                    MessageBox.Show("Người chơi chiến thắng!");
                    stack_CacNuocDaDi.Clear();
                    break;
                case KETTHUC.COM:
                    MessageBox.Show("Máy thắng!");
                    stack_CacNuocDaDi.Clear();
                    break;
            }
            _SanSang = false;
        }


        public bool KiemTraChienThang()
        {
            if (stack_CacNuocDaDi.Count == _BanCo.SoCot * _BanCo.SoDong)
            {
                _KetThuc = KETTHUC.Hoa;
                return true;
            }
            foreach (O_Co oco in stack_CacNuocDaDi)
            {
                if (DuyetDoc(oco.Dong, oco.Cot, oco.SoHuu)
                    || DuyetNgang(oco.Dong, oco.Cot, oco.SoHuu)
                    || DuyetCheoXuong(oco.Dong, oco.Cot, oco.SoHuu)
                    || DuyetCheoLen(oco.Dong, oco.Cot, oco.SoHuu))
                {
                    if(PlayMode == 1)
                    {
                        _KetThuc = oco.SoHuu == 1 ? KETTHUC.Player1 : KETTHUC.Player2;
                        return true;
                    }
                    else
                    {
                        _KetThuc = oco.SoHuu == 1 ? KETTHUC.COM : KETTHUC.Player;
                        return true;
                    }

                }
            }


            return false;
        }
        private bool DuyetDoc(int curDong, int curCot, int curSoHuu)
        {
            if (curDong > _BanCo.SoDong - 5)
            {
                return false;
            }
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (_MangOCo[curDong + Dem, curCot].SoHuu != curSoHuu)
                {
                    return false;
                }
            }
            if (curDong == 0 || curDong + Dem == _BanCo.SoDong)
            {
                return true;
            }
            if (_MangOCo[curDong - 1, curCot].SoHuu == 0
                || _MangOCo[curDong + Dem, curCot].SoHuu == 0)
            {
                return true;
            }
            return false;
        }
        private bool DuyetNgang(int curDong, int curCot, int curSoHuu)
        {
            if (curCot > _BanCo.SoCot - 5)
            {
                return false;
            }
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (_MangOCo[curDong, curCot + Dem].SoHuu != curSoHuu)
                {
                    return false;
                }
            }
            if (curCot == 0 || curCot + Dem == _BanCo.SoCot)
            {
                return true;
            }
            if (_MangOCo[curDong, curCot - 1].SoHuu == 0
                || _MangOCo[curDong, curCot + Dem].SoHuu == 0)
            {
                return true;
            }
            return false;
        }
        private bool DuyetCheoXuong(int curDong, int curCot, int curSoHuu)
        {
            if (curDong > _BanCo.SoDong - 5
                || curCot > _BanCo.SoCot - 5)
            {
                return false;
            }
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (_MangOCo[curDong + Dem, curCot + Dem].SoHuu != curSoHuu)
                {
                    return false;
                }
            }
            if (curDong == 0
                || curDong + Dem == _BanCo.SoDong
                || curCot == 0
                || curCot + Dem == _BanCo.SoCot)
            {
                return true;
            }
            if (_MangOCo[curDong - 1, curCot - 1].SoHuu == 0
                || _MangOCo[curDong + Dem, curCot + Dem].SoHuu == 0)
            {
                return true;
            }
            return false;
        }
        private bool DuyetCheoLen(int curDong, int curCot, int curSoHuu)
        {
            if (curDong < 4 || curCot > _BanCo.SoCot - 5)
            {
                return false;
            }
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (_MangOCo[curDong - Dem, curCot + Dem].SoHuu != curSoHuu)
                {
                    return false;
                }
            }
            if (curDong == 4
                || curDong == _BanCo.SoDong - 1
                || curCot == 0
                || curCot + Dem == _BanCo.SoCot)
            {
                return true;
            }
            if (_MangOCo[curDong + 1, curCot - 1].SoHuu == 0
                || _MangOCo[curDong - Dem, curCot + Dem].SoHuu == 0)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region AI
        private long[] AttackPoint = new long[7] {0, 9, 54, 162, 1458, 13112, 118008};
        private long[] DefensivePoint = new long[7] {0, 3, 27, 99,  729, 6561, 59049};
        //private long[] AttackPoint = new long[7] { 0, 3, 24, 192, 1536, 12288, 9830 };
        //private long[] DefensivePoint = new long[7] { 0, 1, 9, 81, 729, 6561, 59049 };
        public void StartComputer(Graphics g)
        {
            if(stack_CacNuocDaDi.Count == 0)
            {
                DanhCo( _BanCo.SoCot / 2 * O_Co._ChieuRong -1, _BanCo.SoDong / 2 * O_Co._ChieuCao-1, g);

            }
            else
            {
                O_Co oco = TimKiemNuocDi();
                DanhCo(oco.ViTri.X + 1, oco.ViTri.Y + 1, g);
            }
        }
        private O_Co TimKiemNuocDi()
        {
            O_Co OCoResult = new O_Co();
            long DiemMax = 0;
            for(int i = 0; i < _BanCo.SoDong; i++)
            {
                for(int j = 0; j < _BanCo.SoCot; j++)
                {
                    if(_MangOCo[i, j].SoHuu == 0)
                    {
                        long DiemTanCong = DiemTC_DuyetDoc(i, j) + DiemTC_DuyetNgang(i, j) + DiemTC_DuyetCheoXuong(i, j) + DiemTC_DuyetCheoLen(i, j);
                        long DiemPhongNgu = DiemPN_DuyetDoc(i, j) + DiemPN_DuyetNgang(i, j) + DiemPN_DuyetCheoXuong(i, j) + DiemPN_DuyetCheoLen(i, j);
                        long DiemTam = DiemTanCong > DiemPhongNgu ? DiemTanCong : DiemPhongNgu;
                        if(DiemMax < DiemTam)
                        {
                            DiemMax = DiemTam;
                            OCoResult = new O_Co(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].ViTri, _MangOCo[i, j].SoHuu);
                        }
                    }

                }
            }

            return OCoResult;
        }
        #region Tấn công
        private long DiemTC_DuyetDoc(int curDong, int curCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            //Duyệt xuống
            for (int Dem = 1; Dem < 6 && curDong + Dem < _BanCo.SoDong; Dem++)
            {
                if (_MangOCo[curDong + Dem, curCot].SoHuu == 1)
                {
                    SoQuanTa++;
                }
                else if (_MangOCo[curDong + Dem, curCot].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break; 
            }
            //Duyệt Lên
            for (int Dem = 1; Dem < 6 && curDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[curDong - Dem, curCot].SoHuu == 1)
                {
                    SoQuanTa++;
                }
                else if (_MangOCo[curDong - Dem, curCot].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2)
                return 0;
            DiemTong -= DefensivePoint[SoQuanDich + 1];
            DiemTong += AttackPoint[SoQuanTa];
            return DiemTong;
        }
        private long DiemTC_DuyetNgang(int curDong, int curCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            //Duyệt trái qua
            for (int Dem = 1; Dem < 6 && curCot + Dem < _BanCo.SoCot; Dem++)
            {
                if (_MangOCo[curDong, curCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                }
                else if (_MangOCo[curDong, curCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            //Duyệt phải qua
            for (int Dem = 1; Dem < 6 && curCot - Dem >= 0; Dem++)
            {
                if (_MangOCo[curDong, curCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                }
                else if (_MangOCo[curDong, curCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2)
                return 0;
            DiemTong -= DefensivePoint[SoQuanDich + 1];
            DiemTong += AttackPoint[SoQuanTa];
            return DiemTong;
        }
        private long DiemTC_DuyetCheoXuong(int curDong, int curCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            //Duyệt Xuống
            for (int Dem = 1; Dem < 6 && curCot + Dem < _BanCo.SoCot && curDong + Dem < _BanCo.SoDong; Dem++)
            {
                if (_MangOCo[curDong +Dem, curCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                }
                else if (_MangOCo[curDong + Dem, curCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            //Duyệt phải qua
            for (int Dem = 1; Dem < 6 && curCot - Dem >= 0 && curDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[curDong -Dem, curCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                }
                else if (_MangOCo[curDong - Dem, curCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2)
                return 0;
            DiemTong -= DefensivePoint[SoQuanDich + 1];
            DiemTong += AttackPoint[SoQuanTa];
            return DiemTong; 
        }
        private long DiemTC_DuyetCheoLen(int curDong, int curCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            //Duyệt Lên
            for (int Dem = 1; Dem < 6 && curCot + Dem < _BanCo.SoCot && curDong -Dem >= 0; Dem++)
            {
                if (_MangOCo[curDong - Dem, curCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                }
                else if (_MangOCo[curDong - Dem, curCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            //Duyệt Xuống
            for (int Dem = 1; Dem < 6 && curCot - Dem >= 0 && curDong + Dem < _BanCo.SoDong; Dem++)
            {
                if (_MangOCo[curDong + Dem, curCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                }
                else if (_MangOCo[curDong + Dem, curCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2)
                return 0;
            DiemTong -= DefensivePoint[SoQuanDich + 1];
            DiemTong += AttackPoint[SoQuanTa];
            return DiemTong;
        }
        #endregion
        #region Phòng Thủ
        private long DiemPN_DuyetDoc(int curDong, int curCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            //Duyệt xuống
            for (int Dem = 1; Dem < 6 && curDong + Dem < _BanCo.SoDong; Dem++)
            {
                if (_MangOCo[curDong + Dem, curCot].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[curDong + Dem, curCot].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            //Duyệt Lên
            for (int Dem = 1; Dem < 6 && curDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[curDong - Dem, curCot].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[curDong - Dem, curCot].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            if (SoQuanTa == 2)
                return 0;
            DiemTong += DefensivePoint[SoQuanDich];
            return DiemTong;
        }
        private long DiemPN_DuyetNgang(int curDong, int curCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            //Duyệt trái qua
            for (int Dem = 1; Dem < 6 && curCot + Dem < _BanCo.SoCot; Dem++)
            {
                if (_MangOCo[curDong, curCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[curDong, curCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            //Duyệt phải qua
            for (int Dem = 1; Dem < 6 && curCot - Dem >= 0; Dem++)
            {
                if (_MangOCo[curDong, curCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[curDong, curCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            if (SoQuanTa == 2)
                return 0;
            DiemTong += DefensivePoint[SoQuanDich ];
            return DiemTong;
        }
        private long DiemPN_DuyetCheoXuong(int curDong, int curCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            //Duyệt Xuống
            for (int Dem = 1; Dem < 6 && curCot + Dem < _BanCo.SoCot && curDong + Dem < _BanCo.SoDong; Dem++)
            {
                if (_MangOCo[curDong + Dem, curCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[curDong + Dem, curCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            //Duyệt phải qua
            for (int Dem = 1; Dem < 6 && curCot - Dem >= 0 && curDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[curDong - Dem, curCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[curDong - Dem, curCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            if (SoQuanTa == 2)
                return 0;
            DiemTong += DefensivePoint[SoQuanDich];
            return DiemTong;
        }
        private long DiemPN_DuyetCheoLen(int curDong, int curCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            //Duyệt Lên
            for (int Dem = 1; Dem < 6 && curCot + Dem < _BanCo.SoCot && curDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[curDong - Dem, curCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[curDong - Dem, curCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            //Duyệt Xuống
            for (int Dem = 1; Dem < 6 && curCot - Dem >= 0 && curDong + Dem < _BanCo.SoDong; Dem++)
            {
                if (_MangOCo[curDong + Dem, curCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[curDong + Dem, curCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else
                    break;
            }
            if (SoQuanTa == 2)
                return 0;
            DiemTong += DefensivePoint[SoQuanDich];
            return DiemTong;
        }
        #endregion
        #endregion

    }
}