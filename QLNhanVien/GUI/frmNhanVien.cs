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
    public partial class frmNhanVien : Form
    {
        private NhanVienDTO nvSelected = null;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            loadDataCombobox();
            loadDataDataGirdView();
        }
        private void loadDataDataGirdView()
        {
            dgvNhanVien.DataSource = NhanVienBUS.selectNhanVien();
        }
        private void loadDataCombobox()
        {
            cboChucVu.DataSource = ChucVuBUS.selectChucVu();
            cboChucVu.DisplayMember = "tencv";
            cboChucVu.ValueMember = "macv";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtHoNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            if (txtMaNV.Text.Length > 5)
            {
                MessageBox.Show("Mã nhân viên tối đa 5 ký tự!");
                return;
            }
            if (NhanVienBUS.selectNhanVienByManv(txtMaNV.Text.Trim()) != null)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!");
                return;
            }
            NhanVienDTO nv = new NhanVienDTO();
            nv.manv = txtMaNV.Text;
            nv.holot = txtHoNV.Text;
            nv.tennv = txtTenNV.Text;
            nv.ngaysinh = dtpNgaySinh.Value;
            if (rdoNam.Checked)
                nv.phai = "Nam";
            else
                nv.phai = "Nữ";
            nv.macv = cboChucVu.SelectedValue.ToString();

            bool result = NhanVienBUS.insertNhanVien(nv);
            if (!result)
            {
                MessageBox.Show("Không thêm được");
                return;

            }
            loadDataDataGirdView();
            MessageBox.Show("Thêm thành công");
            nvSelected = null;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nvSelected = (NhanVienDTO)dgvNhanVien.Rows[e.RowIndex].DataBoundItem;

            txtMaNV.Text = nvSelected.manv;
            txtHoNV.Text = nvSelected.holot;
            txtTenNV.Text = nvSelected.tennv;
            if (nvSelected.phai == "Nam")
                rdoNam.Checked = true;
            else
                rdoNu.Checked = true;
            dtpNgaySinh.Text = nvSelected.ngaysinh.ToString();
            cboChucVu.SelectedValue = nvSelected.macv;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text == "" || txtHoNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            NhanVienDTO nv = new NhanVienDTO();
            nv.manv = txtMaNV.Text;
            nv.holot = txtHoNV.Text;
            nv.tennv = txtTenNV.Text;
            nv.ngaysinh = dtpNgaySinh.Value;
            if (rdoNam.Checked)
                nv.phai = "Nam";
            else
                nv.phai = "Nữ";
            nv.macv = cboChucVu.SelectedValue.ToString();

            bool result = NhanVienBUS.updateNhanVien(nv);
            if (!result)
            {
                MessageBox.Show("Không sửa được");
                return;

            }
            loadDataDataGirdView();
            nvSelected = null;
            MessageBox.Show("sửa thành công");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (nvSelected == null)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên cần xóa");
                return;
            }
            bool result = NhanVienBUS.deleteNhanVien(nvSelected.manv);
            if (!result)
            {
                MessageBox.Show("Không xóa được");
                return;

            }
            loadDataDataGirdView();
            nvSelected = null;
            MessageBox.Show("xóa thành công");

        }

        private void selectAllTextBox(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            var lstNV = NhanVienBUS.selectNhanVienByHoVaTen(txtTImKiemTenNhanVien.Text.Trim(), txtTimKiemHoNhanVien.Text.Trim());
            if (lstNV == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên");
                return;
            }
            dgvNhanVien.DataSource = lstNV;
        }
    }
}
