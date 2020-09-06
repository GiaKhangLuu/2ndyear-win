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
    public partial class FormThem_CapNhatTacGia : Form
    {
        public FormThem_CapNhatTacGia()
        {
            InitializeComponent();
        }

        public FormThem_CapNhatTacGia(string maTacGia, string tenTacGia)
        {
            InitializeComponent();
            tbMaTacGia.Text = maTacGia;
            tbTenTacGia.Text = tenTacGia;
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

        private void InsertTacGia(string tenTacGia)
        {

            if (TacGiaDAO.InsertTacGia(tenTacGia))
            {
                MessageBox.Show("Thêm thành công");
                Dispose();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void UpdateTacGia(int maTacGia, string tenTacGia)
        {
            if (TacGiaDAO.UpdateTacGia(maTacGia, tenTacGia))
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
            string maTacGia = tbMaTacGia.Text;
            string tenTacGia = tbTenTacGia.Text;
            if(IsFillAll(new string[] { tenTacGia }))
            {
                if (maTacGia != "")
                {
                    int maTacGiaIntValue = Convert.ToInt32(maTacGia);
                    UpdateTacGia(maTacGiaIntValue, tenTacGia);
                }
                else
                {
                    InsertTacGia(tenTacGia);
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

        private void tbTenTacGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
