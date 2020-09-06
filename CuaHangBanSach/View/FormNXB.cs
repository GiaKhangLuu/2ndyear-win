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
    public partial class FormNXB : Form
    {
        public FormNXB()
        {
            InitializeComponent();
            InitNXB();
        }

        public void InitNXB()
        {
            dataGVNXB.Rows.Clear();
            List<NXB> list = NXB_DAO.LoadNXB();
            foreach(NXB item in list)
            {
                dataGVNXB.Rows.Add(item.ItemArray());
            }
            dataGVNXB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThem_CapNhatNXB newForm = new FormThem_CapNhatNXB();
            this.Visible = false;
            newForm.Show();
            newForm.Disposed += NewForm_Disposed;
        }

        private void NewForm_Disposed(object sender, EventArgs e)
        {
            this.Visible = true;
            InitNXB();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGVNXB.SelectedRows.Count >= 1 ? dataGVNXB.SelectedRows[0] : null;
            if(row != null)
            {
                string maNXB = row.Cells["colMaNXB"].Value.ToString();
                string tenNXB = row.Cells["colTenNXB"].Value.ToString();
                FormThem_CapNhatNXB newForm = new FormThem_CapNhatNXB(maNXB, tenNXB);
                this.Visible = false;
                newForm.Show();
                newForm.Disposed += NewForm_Disposed;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn nhà xuât bản để sửa");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGVNXB.SelectedRows.Count >= 1 ? dataGVNXB.SelectedRows[0] : null;
            if (row != null)
            {
                int maNXB = Convert.ToInt32(row.Cells["colMaNXB"].Value);
                string tenNXB = row.Cells["colTenNXB"].Value.ToString();
                string message = $"Bạn có muốn xóa nhà xuất bản {tenNXB} không ?";
                string caption = "Xóa nhân viên";
                if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (NXB_DAO.DeleteNXB(maNXB))
                    {
                        MessageBox.Show("Xóa thành công");
                        InitNXB();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn nhà xuất bản để xóa");
            }
        }
    }
}
