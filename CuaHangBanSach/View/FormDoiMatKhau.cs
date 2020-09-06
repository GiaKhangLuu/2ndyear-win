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
    public partial class FormDoiMatKhau : Form
    {
        private NhanVien nv;
        public FormDoiMatKhau(NhanVien nv)
        {
            InitializeComponent();
            this.nv = nv;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string matKhauCu = tbMatKhauCu.Text;
            string matKhauMoi = tbMatKhauMoi.Text;
            string nhapLaiMKMoi = tbNhapLaiMatKhau.Text;
            if(IsFillAll(new string[] { matKhauCu, matKhauMoi, nhapLaiMKMoi }))
            {
                if(matKhauCu == nv.MatKhau)
                {
                    if(matKhauMoi == nhapLaiMKMoi)
                    {
                        if (NhanVienDAO.DoiMatKhau(nv.MaNV, matKhauMoi))
                        {
                            MessageBox.Show("Đổi mật khẩu thành công");
                        }
                        else
                        {
                            MessageBox.Show("Đổi mật khẩu không thành công");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhập lại mật khẩu không đúng");
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }
        }

        private bool IsFillAll(string[] itemArr)
        {
            foreach (string item in itemArr)
                if (item == "")
                    return false;
            return true;
        }
    }
}
