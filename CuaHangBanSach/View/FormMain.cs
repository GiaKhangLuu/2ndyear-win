using CuaHangBanSach.DAO;
using CuaHangBanSach.DTO;
using CuaHangBanSach.View;
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
    public partial class FormMain : Form
    {
        private const int INDEX_FORM_CTHD = 0;
        private const int INDEX_FORM_DOIMATKHAU = 1;
        private const int INDEX_FORM_DANGNHAP = 2;
        private const int INDEX_FORM_HOADON = 3;
        private const int INDEX_FORM_KHACHHANG = 4;
        private const int INDEX_FORM_NHANVIEN = 5;
        private const int INDEX_FORM_NXB = 6;
        private const int INDEX_FORM_SACH = 7;
        private const int INDEX_FORM_TACGIA = 8;
        private const int INDEX_FORM_THELOAI = 9;
        private const int INDEX_FORM_TTCANHAN = 10;
        private const int INDEX_FORM_BANSACH = 11;

        private Form[] arrForm = new Form[12];

        private NhanVien nv;

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(NhanVien nv)
        {
            InitializeComponent();
            this.nv = nv;
            if (nv.QuyenHan == 1)
                menuItemTTNhanVien.Enabled = true;
        }

        private void OpenForm(int formIndex)
        {
            Form formOpening = arrForm[formIndex];
            formOpening.Show();
            formOpening.VisibleChanged += FormOpening_VisibleChanged;
        }

        //set form main hide if any add, update form is showed
        private void FormOpening_VisibleChanged(object sender, EventArgs e)
        {
            Form formOpening = sender as Form;
            if (!formOpening.Visible)
            {
                this.Visible = false;
            }
            else
            {
                this.Visible = true;
            }
        }

        private void DisposeFormOpening()
        {
            foreach(Form form in arrForm)
            {
                if(form != null && form.Visible)
                {
                    //if (form.Visible)
                        form.Dispose();
                }
            }         
        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisposeFormOpening();
            arrForm[INDEX_FORM_NHANVIEN] = new FormNhanVien();
            OpenForm(INDEX_FORM_NHANVIEN);
        }

        private void thôngTinSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisposeFormOpening();
            arrForm[INDEX_FORM_SACH] = new FormSach();
            OpenForm(INDEX_FORM_SACH);
        }

        private void thongTinBanThan_Click(object sender, EventArgs e)
        {
            //if (arrForm[INDEX_FORM_TTCANHAN].IsDisposed)
            //    arrForm[INDEX_FORM_TTCANHAN] = new FormThongTinCaNhan();
            DisposeFormOpening();
            arrForm[INDEX_FORM_TTCANHAN] = new FormThongTinCaNhan(nv);
            OpenForm(INDEX_FORM_TTCANHAN);
            
        }

        private void menuItemDoiMatKhau_Click(object sender, EventArgs e)
        {
            //if (arrForm[INDEX_FORM_DOIMATKHAU].IsDisposed)
            //    arrForm[INDEX_FORM_DOIMATKHAU] = new FormDoiMatKhau();
            DisposeFormOpening();
            arrForm[INDEX_FORM_DOIMATKHAU] = new FormDoiMatKhau(nv);
            OpenForm(INDEX_FORM_DOIMATKHAU);
        }

        private void menuItemTTKhachHang_Click(object sender, EventArgs e)
        {
            //if (arrForm[INDEX_FORM_KHACHHANG].IsDisposed)
            //    arrForm[INDEX_FORM_KHACHHANG] = new FormKhachHang();
            DisposeFormOpening();
            arrForm[INDEX_FORM_KHACHHANG] = new FormKhachHang();
            OpenForm(INDEX_FORM_KHACHHANG);
        }

        private void menuItemTTTacGia_Click(object sender, EventArgs e)
        {
            DisposeFormOpening();
            arrForm[INDEX_FORM_TACGIA] = new FormTacGia();
            OpenForm(INDEX_FORM_TACGIA);
        }

        private void menuItemTTNXB_Click(object sender, EventArgs e)
        {
            DisposeFormOpening();
            arrForm[INDEX_FORM_NXB] = new FormNXB();
            OpenForm(INDEX_FORM_NXB);
        }

        private void menuItemTTTheLoai_Click(object sender, EventArgs e)
        {
            DisposeFormOpening();
            arrForm[INDEX_FORM_THELOAI] = new FormTheLoai();
            OpenForm(INDEX_FORM_THELOAI);
        }

        private void menuItemTTHoaDon_Click(object sender, EventArgs e)
        {
            DisposeFormOpening();
            arrForm[INDEX_FORM_HOADON] = new FormHoaDon();
            OpenForm(INDEX_FORM_HOADON);
        }

        private void menuItemTTCTHoaDon_Click(object sender, EventArgs e)
        {
            DisposeFormOpening();
            arrForm[INDEX_FORM_CTHD] = new FormCTHoaDon();
            OpenForm(INDEX_FORM_CTHD);
        }

        private void menuItemBanSach_Click(object sender, EventArgs e)
        {
            DisposeFormOpening();
            List<Sach> sachGroup = SachDAO.LoadSach();
            if(sachGroup.Count > 0)
            {
                arrForm[INDEX_FORM_BANSACH] = new FormBanSach(nv, sachGroup);
                OpenForm(INDEX_FORM_BANSACH);
            }        
        }

        private void menuItemDangXuat_Click(object sender, EventArgs e)
        {
            string message = "Bạn có muốn đăng xuất ?";
            string caption = "Đăng xuât";
            if(MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DisposeFormOpening();
                Dispose();
                FormDangNhap newForm = new FormDangNhap();
                newForm.Show();
            }
        }
    }
}
