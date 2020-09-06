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
    public partial class FormThem_CapNhatKH : Form
    {
        public FormThem_CapNhatKH()
        {
            InitializeComponent();
        }

        public FormThem_CapNhatKH(string maKH, string tenKH, string sdt, string email, string diaChi, string gioiTinh, DateTime ngaySinh)
        {
            InitializeComponent();
            tbMaKH.Text = maKH;
            tbTenKH.Text = tenKH;
            tbSDT.Text = sdt;
            tbEmail.Text = email;
            tbDiaChi.Text = diaChi;
            cmbGioiTinh.SelectedItem = gioiTinh;
            dtPickerNgaySinh.Value = ngaySinh;
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

        private void InsertKhachHang(string tenKH, string sdt, string email, string diaChi, int gioiTinh, string ngaySinh)
        {

            if (KhachHangDAO.InsertKhachHang(tenKH, sdt, email, diaChi, gioiTinh, ngaySinh))
            {
                MessageBox.Show("Thêm thành công");
                Dispose();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void UpdateKhachHang(int maKH, string tenKH, string sdt, string email, string diaChi, int gioiTinh, string ngaySinh)
        {
            if (KhachHangDAO.UpdateKhachang(maKH, tenKH, sdt, email, diaChi, gioiTinh, ngaySinh))
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
            string maKH = tbMaKH.Text;
            string tenKH = tbTenKH.Text;
            string sdt = tbSDT.Text;
            string email = tbEmail.Text;
            string diaChi = tbDiaChi.Text;
            string gioiTinh = cmbGioiTinh.SelectedItem == null ? "" : cmbGioiTinh.SelectedItem.ToString();
            string ngaySinh = dtPickerNgaySinh.Value.Date.ToString("dd/MM/yyyy");
            if(IsFillAll(new string[] { tenKH }))
            {
                int gioiTinhValue = gioiTinh == "Nam" ? 1 : 0;
                if (maKH != "")
                {
                    int maKHValue = Convert.ToInt32(maKH);
                    UpdateKhachHang(maKHValue, tenKH, sdt, email, diaChi, gioiTinhValue, ngaySinh);
                }
                else
                {
                    InsertKhachHang(tenKH, sdt, email, diaChi, gioiTinhValue, ngaySinh);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền thông tin khách hàng");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void tbTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = true;
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
    }
}
