using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1_Caro
{
    public partial class frmCaro : Form
    {
        private Caro_Chess caroChess;
        private Graphics grs;
        public frmCaro()
        {
            InitializeComponent();
            btnPlayervsPlayer.Click += new EventHandler(PvsP);
            caroChess = new Caro_Chess();
            caroChess.KhoiTaoMangOCo();
            grs = pnlBanCo.CreateGraphics();
            string sLuatChoi = "Luật chơi\n - Bên nào đánh được 5 quân cờ liên tiếp nhau không bị chặn hai đầu sẽ là người chiến thắng\n- Bàn cờ đầy sẽ được tính là hòa";
            gboxLuatChoi.Text = sLuatChoi;
            playerVsComToolStripMenuItem.Click += new EventHandler(PvsC_Click);
            btnPlayervsCom.Click += new EventHandler(PvsC_Click);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmCaro_Load(object sender, EventArgs e)
        {
            caroChess.VeBanCo(grs); 
        }

        private void pnlBanCo_Paint(object sender, PaintEventArgs e)
        {
            caroChess.VeBanCo(grs);
            caroChess.VeLaiQuanCo(grs);
        }

        private void pnlBanCo_MouseClick(object sender, MouseEventArgs e)
        {
            if (!caroChess.SanSang) return;
            if (caroChess.DanhCo(e.X, e.Y, grs))
            {
                if (caroChess.KiemTraChienThang())
                {
                    caroChess.KetThucGame();
                }
                else
                {
                    if (caroChess.PlayMode == 2)
                    {
                        caroChess.StartComputer(grs);
                        if (caroChess.KiemTraChienThang())
                        {
                            caroChess.KetThucGame();
                        }

                    }
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PvsP(object sender, EventArgs e)
        {
            grs.Clear(pnlBanCo.BackColor);
            caroChess.StartPlayervsPlayer(grs);  

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //grs.Clear(pnlBanCo.BackColor);
            caroChess.Undo(grs);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            caroChess.Redo(grs);
        }
        private void PvsC_Click(object Sender, EventArgs e)
        {
            grs.Clear(pnlBanCo.BackColor);
            caroChess.StartPlayervsCom(grs);

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đồ án I: Tìm hiểu C#\nDemo: Game cờ Caro\nGVHD: TS. Thân Quang Khoát\nSinh viên: Cao Văn Đức\nMSSV: 20161056");
        }
    }
}
