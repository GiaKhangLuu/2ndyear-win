using CuaHangBanSach.DAO;
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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private bool IsFillAll(string[] arr)
        {
            foreach (string item in arr)
                if (item == "")
                    return false;
            return true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenTK = tbTaiKhoan.Text;
            string matKhau = tbMatKhau.Text;
            if(IsFillAll(new string[] { tenTK, matKhau }))
            {
                NhanVien nv = NhanVienDAO.GetNhanVienByTenTaiKhoanAndMatKhau(tenTK, matKhau);
                if (nv != null)
                {
                    FormMain newForm = new FormMain(nv);
                    newForm.Show();
                    //newForm.Dispose();
                    this.Visible = false;
                    //Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
                    tbTaiKhoan.Text = "";
                    tbMatKhau.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //FormSach form = new FormSach();
            //form.Show();
            Dispose();
        }
    }
}
