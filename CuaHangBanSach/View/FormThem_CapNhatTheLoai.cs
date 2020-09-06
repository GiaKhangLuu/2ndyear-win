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
    public partial class FormThem_CapNhatTheLoai : Form
    {
        public FormThem_CapNhatTheLoai()
        {
            InitializeComponent();
        }

        public FormThem_CapNhatTheLoai(string maTheLoai, string tenTheLoai)
        {
            InitializeComponent();
            tbMaTheLoai.Text = maTheLoai;
            tbTenTheLoai.Text = tenTheLoai;
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

        private void InsertTheLoai(string tenTheLoai)
        {

            if (TheLoaiDAO.InsertTheLoai(tenTheLoai))
            {
                MessageBox.Show("Thêm thành công");
                Dispose();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void UpdateTheLoai(int maTheLoai, string tenTheLoai)
        {
            if (TheLoaiDAO.UpdateTheLoai(maTheLoai, tenTheLoai))
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
            string maTheLoai = tbMaTheLoai.Text;
            string tenTheLoai = tbTenTheLoai.Text;
            if(IsFillAll(new string[] { tenTheLoai }))
            {
                if (maTheLoai != "")
                {
                    int maTheLoaiIntValue = Convert.ToInt32(maTheLoai);
                    UpdateTheLoai(maTheLoaiIntValue, tenTheLoai);
                }
                else
                {
                    InsertTheLoai(tenTheLoai);
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

        private void tbTenTheLoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
