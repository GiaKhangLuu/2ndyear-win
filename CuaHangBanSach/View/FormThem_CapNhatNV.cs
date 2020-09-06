using CuaHangBanSach.DAO;
using CuaHangBanSach.DTO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangBanSach
{
    public partial class FormThem_CapNhatNV : Form
    {
        public FormThem_CapNhatNV()
        {
            InitializeComponent();
        }

        public FormThem_CapNhatNV(string maNV, string tenNV, string sdt, string email, string diaChi, string gioiTinh, DateTime ngaySinh, DateTime ngayVaoLam, string chucVu, string tenTaiKhoan)
        {
            InitializeComponent();
            tbMaNV.Text = maNV;
            tbTenNV.Text = tenNV;
            tbSDT.Text = sdt;
            tbEmail.Text = email;
            tbDiaChi.Text = diaChi;
            cmbGioiTinh.SelectedItem = gioiTinh;
            dtPickerNgaySinh.Value = ngaySinh;
            dtPickerNgayVaoLam.Value = ngayVaoLam;
            cmbChucVu.SelectedItem = chucVu;
            tbTenTK.Text = tenTaiKhoan;
        }

        private bool IsFillAll(string[] items)
        {
            foreach(string item in items)
            {
                if (item.Equals(""))
                    return false;
            }
            return true;
        }

        private void InsertNhanVien(string tenNV, string sdt, string email, string diaChi, int gioiTinh, string ngaySinh, string ngayVaoLam, int chucVu, string tenTK)
        {

            if (NhanVienDAO.InsertNhanVien(tenNV, sdt, email, diaChi, gioiTinh, ngaySinh, ngayVaoLam, chucVu, tenTK))
            {
                MessageBox.Show("Thêm thành công");
                Dispose();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void UpdateNhanVien(int maNV, string tenNV, string sdt, string email, string diaChi, int gioiTinh, string ngaySinh, string ngayVaoLam, int chucVu, string tenTK)
        {
            if (NhanVienDAO.UpdateNhanVien(maNV, tenNV, sdt, email, diaChi, gioiTinh, ngaySinh, ngayVaoLam, chucVu, tenTK))
            {
                MessageBox.Show("Cập nhật thành công");
                Dispose();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maNV = tbMaNV.Text;
            string tenNV = tbTenNV.Text;
            string sdt = tbSDT.Text;
            string email = tbEmail.Text;
            string diaChi = tbDiaChi.Text;
            string gioiTinh = cmbGioiTinh.SelectedItem == null ? "" : cmbGioiTinh.SelectedItem.ToString();
            string ngaySinh = dtPickerNgaySinh.Value.Date.ToString("dd/MM/yyyy");
            string ngayVaoLam = dtPickerNgayVaoLam.Value.Date.ToString("dd/MM/yyyy");
            string chucVu = cmbChucVu.SelectedItem == null ? "" : cmbChucVu.SelectedItem.ToString();
            string tenTK = tbTenTK.Text;
            if(IsFillAll(new string[] { tenNV, sdt, email, diaChi, gioiTinh, chucVu, tenTK }))
            {
                int gioiTinhIntValue = gioiTinh == "Nam" ? 1 : 0;
                int chucVuIntValue = chucVu == "Quản lý" ? 1 : 0;
                if (maNV != "")
                {
                    int maNVIntValue = Convert.ToInt32(maNV);
                    UpdateNhanVien(maNVIntValue, tenNV, sdt, email, diaChi, gioiTinhIntValue, ngaySinh, ngayVaoLam, chucVuIntValue, tenTK);
                }
                else
                {
                    InsertNhanVien(tenNV, sdt, email, diaChi, gioiTinhIntValue, ngaySinh, ngayVaoLam, chucVuIntValue, tenTK);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void tbSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cmbGioiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tbTenNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

    }
}
