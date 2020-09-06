using CuaHangBanSach.DTO;
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
    public partial class FormThongTinCaNhan : Form
    {
        private NhanVien nv;
        public FormThongTinCaNhan(NhanVien nv)
        {
            InitializeComponent();
            this.nv = nv;
            LoadNhanVien();
        }

        private void LoadNhanVien()
        {
            tbMaNV.Text = nv.MaNV.ToString();
            tbTenNV.Text = nv.TenNV;
            tbSDT.Text = nv.Sdt;
            tbEmail.Text = nv.Email;
            tbDiaChi.Text = nv.DiaChi;
            tbGioiTinh.Text = nv.GioiTinh == 1 ? "Nam" : "Nữ";
            tbNgaySinh.Text = nv.NgaySinh.ToString();
            tbNgayVaoLam.Text = nv.NgayVaoLam.ToString();
            tbChucVu.Text = nv.QuyenHan == 1 ? "Quản lý" : "Nhân viên";
            tbTaiKhoan.Text = nv.TenTK;
            tbMatKhau.Text = nv.MatKhau;
        }
    }
}
