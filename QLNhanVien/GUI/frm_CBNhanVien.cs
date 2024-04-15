using BUS;
using DTO;
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
    public partial class frm_CBNhanVien : Form
    {
        public frm_CBNhanVien()
        {
            InitializeComponent();
        }

        private void frm_CBNhanVien_Load(object sender, EventArgs e)
        {   var chucVu = ChucVuBUS.selectChucVu();
            cboChucVu.DataSource = chucVu;
            chucVu.Add(new ChucVuDTO()
            {
                heSoPC = 0,
                tenCV = "Tất cả",
                maCV = ""
            });
            cboChucVu.DisplayMember = "tencv";
            cboChucVu.ValueMember = "macv";
           
            this.nhanVienChucVuTableAdapter.Fill(this.qLNVDataSet.NhanVienChucVu);
            this.reportViewer1.RefreshReport();
        }
        private void cboChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cboChucVu.SelectedValue.ToString().Equals(""))
                    this.nhanVienChucVuTableAdapter.Fill(this.qLNVDataSet.NhanVienChucVu);
                else
                    this.nhanVienChucVuTableAdapter.FillByChucVu(this.qLNVDataSet.NhanVienChucVu,cboChucVu.SelectedValue.ToString());
                
                this.reportViewer1.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
