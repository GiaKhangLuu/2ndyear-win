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
    public partial class FormThem_CapNhatSach : Form
    {
        public FormThem_CapNhatSach()
        {
            InitializeComponent();
            InitTheLoai();
            InitTacGia();
            InitNXB();
        }

        public FormThem_CapNhatSach(string maSach, string tenSach, string tenTacGia, string tenNXB, string tenTheLoai, string gia, int soLuong)
        {
            InitializeComponent();
            InitTheLoai();
            InitTacGia();
            InitNXB();
            tbMaSach.Text = maSach;
            tbTenSach.Text = tenSach;
            tbGia.Text = gia;
            numSoLuong.Value = soLuong;
            cmbNXB.SelectedItem = tenNXB;
            cmbTacGia.SelectedItem = tenTacGia;
            cmbTheLoai.SelectedItem = tenTheLoai;
        }

        private void InitTheLoai()
        {
            List<TheLoai> theloaiGroup = TheLoaiDAO.LoadTheLoai();
            foreach(TheLoai item in theloaiGroup)
            {
                cmbTheLoai.Items.Add(item.TenTheLoai);    
            }  
        }

        private void InitTacGia()
        {
            List<TacGia> tacgiaGroup = TacGiaDAO.LoadTacGia();
            foreach (TacGia item in tacgiaGroup)
            {
                cmbTacGia.Items.Add(item.TenTacGia);
            }
        }

        private void InitNXB()
        {
            List<NXB> nxbGroup = NXB_DAO.LoadNXB();
            foreach (NXB item in nxbGroup)
            {
                cmbNXB.Items.Add(item.TenNXB);
            }
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

        private void InsertSach(string tenSach, string tenTacGia, string tenTheLoai, string tenNXB, string gia, string soLuong)
        {
            int maNXB = NXB_DAO.GetIdNXBByName(tenNXB);
            int maTheLoai = TheLoaiDAO.GetIdTheLoaiByName(tenTheLoai);
            int maTacGia = TacGiaDAO.GetIdTacGiaByName(tenTacGia);
            if (SachDAO.InsertSach(tenSach, maNXB, maTacGia, maTheLoai, Convert.ToDouble(gia), Convert.ToInt32(soLuong)))
            {
                MessageBox.Show("Thêm thành công");
                Dispose();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void UpdateSach(string maSach, string tenSach, string tenTacGia, string tenTheLoai, string tenNXB, string gia, string soLuong)
        {
            int maNXB = NXB_DAO.GetIdNXBByName(tenNXB);
            int maTheLoai = TheLoaiDAO.GetIdTheLoaiByName(tenTheLoai);
            int maTacGia = TacGiaDAO.GetIdTacGiaByName(tenTacGia);
            if (SachDAO.UpdateSach(maSach, tenSach, maNXB, maTacGia, maTheLoai, Convert.ToDouble(gia), Convert.ToInt32(soLuong)))
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
            string maSach = tbMaSach.Text;
            string tenSach = tbTenSach.Text;
            string tenTacGia = cmbTacGia.SelectedItem == null ? "" : cmbTacGia.SelectedItem.ToString();
            string tenTheLoai = cmbTheLoai.SelectedItem == null ? "" : cmbTheLoai.SelectedItem.ToString();
            string tenNXB = cmbNXB.SelectedItem == null ? "" : cmbNXB.SelectedItem.ToString();
            string gia = tbGia.Text;
            string soLuong = numSoLuong.Value.ToString();
            if(IsFillAll(new string[] { tenSach, tenTacGia, tenTheLoai, tenNXB, gia }))
            {
                if(maSach != "")
                {
                    UpdateSach(maSach, tenSach, tenTacGia, tenTheLoai, tenNXB, gia, soLuong);
                }
                else
                {
                    InsertSach(tenSach, tenTacGia, tenTheLoai, tenNXB, gia, soLuong);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }

        private void HandleKeyPress(KeyPressEventArgs e, Control ctrl)
        {
            if(ctrl is ComboBox)
            {
                e.Handled = true;
            }
            if(ctrl is TextBox)
            {
                if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }         
        }

        private void tbGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleKeyPress(e, sender as TextBox);
        }

        private void cmbTacGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleKeyPress(e, sender as ComboBox);
        }

        private void cmbNXB_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleKeyPress(e, sender as ComboBox);
        }

        private void cmbTheLoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleKeyPress(e, sender as ComboBox);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
