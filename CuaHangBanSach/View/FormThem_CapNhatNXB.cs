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
    public partial class FormThem_CapNhatNXB : Form
    {
        public FormThem_CapNhatNXB()
        {
            InitializeComponent();
        }

        public FormThem_CapNhatNXB(string maNXB, string tenNXB)
        {
            InitializeComponent();
            tbMaNXB.Text = maNXB;
            tbTenNXB.Text = tenNXB;
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

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void InsertNXB(string tenNXB)
        {

            if (NXB_DAO.InsertNXB(tenNXB))
            {
                MessageBox.Show("Thêm thành công");
                Dispose();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void UpdateNXB(int maNXB, string tenNXB)
        {
            if (NXB_DAO.UpdateNXB(maNXB, tenNXB))
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
            string maNXB = tbMaNXB.Text;
            string tenNXB = tbTenNXB.Text;
            if(IsFillAll(new string[] { tenNXB }))
            {
                if (maNXB != "")
                {
                    int maNXBIntValue = Convert.ToInt32(maNXB);
                    UpdateNXB(maNXBIntValue, tenNXB);
                }
                else
                {
                    InsertNXB(tenNXB);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }

       

        private void tbGia_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbGia_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void cmbNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string name = (sender as ComboBox).SelectedItem.ToString();
            //MessageBox.Show(NXB_DAO.GetIdNXBByName(name).ToString());
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void tbTenNXB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
