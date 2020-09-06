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
    public partial class FormTacGia : Form
    {
        public FormTacGia()
        {
            InitializeComponent();
            InitTacGia();
        }

        public void InitTacGia()
        {
            dataGVTacGia.Rows.Clear();
            List<TacGia> list = TacGiaDAO.LoadTacGia();
            foreach(TacGia item in list)
            {
                dataGVTacGia.Rows.Add(item.ItemArray());
            }
            dataGVTacGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThem_CapNhatTacGia newForm = new FormThem_CapNhatTacGia();
            this.Visible = false;
            newForm.Show();
            newForm.Disposed += NewForm_Disposed;
        }

        private void NewForm_Disposed(object sender, EventArgs e)
        {
            this.Visible = true;
            InitTacGia();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGVTacGia.SelectedRows.Count >= 1 ? dataGVTacGia.SelectedRows[0] : null;
            if (row != null)
            {
                string maTacGia = row.Cells["colMaTG"].Value.ToString();
                string tenTacGia = row.Cells["colTenTG"].Value.ToString();
                FormThem_CapNhatTacGia newForm = new FormThem_CapNhatTacGia(maTacGia, tenTacGia);
                this.Visible = false;
                newForm.Show();
                newForm.Disposed += NewForm_Disposed;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tác giả để sửa");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGVTacGia.SelectedRows.Count >= 1 ? dataGVTacGia.SelectedRows[0] : null;
            if (row != null)
            {
                int maTacGia = Convert.ToInt32(row.Cells["colMaTG"].Value);
                string tenTacGia = row.Cells["colTenTG"].Value.ToString();
                string message = $"Bạn có muốn xóa tác giả {tenTacGia} không ?";
                string caption = "Xóa nhân viên";
                if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (TacGiaDAO.DeleteTacGia(maTacGia))
                    {
                        MessageBox.Show("Xóa thành công");
                        InitTacGia();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tác giả để xóa");
            }
        }
    }
}
