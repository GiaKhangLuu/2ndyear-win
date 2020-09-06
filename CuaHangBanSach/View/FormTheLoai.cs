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
    public partial class FormTheLoai : Form
    {
        public FormTheLoai()
        {
            InitializeComponent();
            InitTheLoai();
        }

        public void InitTheLoai()
        {
            dataGVTheLoai.Rows.Clear();
            List<TheLoai> list = TheLoaiDAO.LoadTheLoai();
            foreach(TheLoai item in list)
            {
                dataGVTheLoai.Rows.Add(item.ItemArray());
            }
            dataGVTheLoai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinBảnThânToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThem_CapNhatTheLoai newForm = new FormThem_CapNhatTheLoai();
            this.Visible = false;
            newForm.Show();
            newForm.Disposed += NewForm_Disposed;
        }

        private void NewForm_Disposed(object sender, EventArgs e)
        {
            this.Visible = true;
            InitTheLoai();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGVTheLoai.SelectedRows.Count >= 1 ? dataGVTheLoai.SelectedRows[0] : null;
            if (row != null)
            {
                string maTheLoai = row.Cells["colMaTL"].Value.ToString();
                string tenTheLoai = row.Cells["colTenTL"].Value.ToString();
                FormThem_CapNhatTheLoai newForm = new FormThem_CapNhatTheLoai(maTheLoai, tenTheLoai);
                this.Visible = false;
                newForm.Show();
                newForm.Disposed += NewForm_Disposed;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn thể loại để sửa");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGVTheLoai.SelectedRows.Count >= 1 ? dataGVTheLoai.SelectedRows[0] : null;
            if (row != null)
            {
                int maTheLoai = Convert.ToInt32(row.Cells["colMaTL"].Value);
                string tenTheLoai = row.Cells["colTenTL"].Value.ToString();
                string message = $"Bạn có muốn xóa thể loại {tenTheLoai} không ?";
                string caption = "Xóa nhân viên";
                if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (TheLoaiDAO.DeleteTheLoai(maTheLoai))
                    {
                        MessageBox.Show("Xóa thành công");
                        InitTheLoai();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn thể loại để xóa");
            }
        }
    }
}
