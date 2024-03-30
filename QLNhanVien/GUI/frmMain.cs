using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void nhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien fNhanVien = new frmNhanVien();
            fNhanVien.MdiParent = this;
            fNhanVien.Show();
        }

        private void chucVuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChucVu fChucVu = new frmChucVu();
            fChucVu.MdiParent = this;
            fChucVu.Show();
        }

        private void quaTrinhLuongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuaTrinhLuong fQuaTrinhLuong = new frmQuaTrinhLuong();
            fQuaTrinhLuong.MdiParent=this;
            fQuaTrinhLuong.Show();
        }

        private void bcNhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_CBNhanVien fBCNhanVien = new frm_CBNhanVien();
            fBCNhanVien.MdiParent = this;
            fBCNhanVien.Show();
        }
    }
}
