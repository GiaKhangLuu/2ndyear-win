using CuaHangBanSach.DAO;
using CuaHangBanSach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangBanSach
{
    public partial class FormSach : Form
    {
        public FormSach()
        {
            InitializeComponent();
            InitSach();
        }

        private void InitSach()
        {
            dataGVSach.Rows.Clear();
            List<ThongTinSach> sachGroup = ThongTinSachDAO.LoadSach();
            foreach(ThongTinSach sach in sachGroup)
            {
                dataGVSach.Rows.Add(sach.ItemArray());
            }

            dataGVSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThem_CapNhatSach newForm = new FormThem_CapNhatSach();
            this.Visible = false;
            newForm.Show();
            newForm.Disposed += NewForm_Disposed;
        }

        private void NewForm_Disposed(object sender, EventArgs e)
        {
            this.Visible = true;
            InitSach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGVSach.SelectedRows.Count >= 1 ? dataGVSach.SelectedRows[0] : null;
            if (row != null)
            {
                string maSach = row.Cells["colMaSach"].Value.ToString();
                string tenSach = row.Cells["colTenSach"].Value.ToString();
                string tenTacGia = row.Cells["colTacGia"].Value.ToString();
                string tenTheLoai = row.Cells["colTheLoai"].Value.ToString();
                string tenNXB = row.Cells["colNXB"].Value.ToString();
                string gia = row.Cells["colGia"].Value.ToString();
                int soLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                FormThem_CapNhatSach newForm = new FormThem_CapNhatSach(maSach, tenSach, tenTacGia, tenNXB, tenTheLoai, gia, soLuong);
                this.Visible = false;
                newForm.Show();           
                newForm.Disposed += NewForm_Disposed;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sách để sửa");
            }
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGVSach.SelectedRows.Count >= 1 ? dataGVSach.SelectedRows[0] : null;
            if(row != null)
            {
                string maSach = row.Cells["colMaSach"].Value.ToString();
                string tenSach = row.Cells["colTenSach"].Value.ToString();
                string message = $"Bạn có muốn xóa sách {tenSach} không ?";
                string caption = "Xóa Sách";
                if(MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (SachDAO.DeleteSach(maSach))
                    {
                        MessageBox.Show("Xóa sách thành công");
                        InitSach();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sách không thành công");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sách để xóa");
            }
        }
    }
}
