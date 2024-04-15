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
    public partial class frmBCBangLuong : Form
    {
        public frmBCBangLuong()
        {
            InitializeComponent();
        }

        private void frmBCBangLuong_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLNVDataSet.BangLuong' table. You can move, or remove it, as needed.
             this.bangLuongTableAdapter.Fill(this.qLNVDataSet.BangLuong);
            this.reportViewer1.RefreshReport();
        }
         
        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.bangLuongTableAdapter.FillBy(this.qLNVDataSet.BangLuong);
                this.reportViewer1.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
