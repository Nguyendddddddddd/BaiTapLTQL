using BUS;
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
    public partial class frmQuaTrinhLuong : Form
    {
        public frmQuaTrinhLuong()
        {
            InitializeComponent();
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            if (rdoHienTai.Checked)
            {
                dgvQuaTrinhLuong.DataSource = QuaTrinhLuongBUS.selectQuaTrinhLuongBetweenDay(dtpTuNgay.Value, DateTime.Now);
                return;
            }
            dgvQuaTrinhLuong.DataSource = QuaTrinhLuongBUS.selectQuaTrinhLuongBetweenDay(dtpTuNgay.Value, dtpDenNgay.Value);

        }
        public void loadQuaTrinhLuong()
        {
            dgvQuaTrinhLuong.DataSource = QuaTrinhLuongBUS.selectQuaTrinhLuong();
        }
        private void frmQuaTrinhLuong_Load(object sender, EventArgs e)
        {
            loadQuaTrinhLuong();
        }

        private void rdoDenNgay_CheckedChanged(object sender, EventArgs e)
        {
            dtpDenNgay.Enabled = rdoDenNgay.Checked;
        }
    }
}
