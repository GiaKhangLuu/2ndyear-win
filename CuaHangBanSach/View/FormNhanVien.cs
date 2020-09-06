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
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
            InitNhanVien();
        }

        private void InitNhanVien()
        {
            dataGVNhanVien.Rows.Clear();
            List<NhanVien> nhanVienGroup = NhanVienDAO.LoadNhanVien();
            int index = 0;
            foreach(NhanVien item in nhanVienGroup)
            {
                dataGVNhanVien.Rows.Add(item.ItemArray());
                DataGridViewCell cellGioiTinh = dataGVNhanVien.Rows[index].Cells["colGioiTinh"];
                DataGridViewCell cellChucVu = dataGVNhanVien.Rows[index].Cells["colChucVu"];
                cellGioiTinh.Value = Convert.ToInt32(cellGioiTinh.Value) == 1 ? "Nam" : "Nữ";
                cellChucVu.Value = Convert.ToInt32(cellChucVu.Value) == 1 ? "Quản lý" : "Nhân viên";
                index++;
            }
            dataGVNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThem_CapNhatNV newForm = new FormThem_CapNhatNV();
            this.Visible = false;
            newForm.Show();
            newForm.Disposed += NewForm_Disposed;
        }

        private void NewForm_Disposed(object sender, EventArgs e)
        {
            this.Visible = true;
            InitNhanVien();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGVNhanVien.SelectedRows.Count >= 1 ? dataGVNhanVien.SelectedRows[0] : null;
            if(row != null)
            {
                string maNV = row.Cells["colMaNV"].Value.ToString();
                string tenNV = row.Cells["colTenNV"].Value.ToString();
                string sdt = row.Cells["colSDT"].Value.ToString();
                string email = row.Cells["colEmail"].Value.ToString();
                string diaChi = row.Cells["colDiaChi"].Value.ToString();
                string gioiTinh = row.Cells["colGioiTinh"].Value.ToString();
                DateTime ngaySinh = (DateTime)row.Cells["colNgaySinh"].Value;
                DateTime ngayVaoLam = (DateTime)row.Cells["colNgayVaoLam"].Value;
                string chucVu = row.Cells["colChucVu"].Value.ToString();
                string tenTK = row.Cells["colTenTK"].Value.ToString();
                FormThem_CapNhatNV newForm = new FormThem_CapNhatNV(maNV, tenNV, sdt, email, diaChi, gioiTinh, ngaySinh, ngayVaoLam, chucVu, tenTK);
                this.Visible = true;
                newForm.Show();
                newForm.Disposed += NewForm_Disposed;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn nhân viên để sửa");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGVNhanVien.SelectedRows.Count >= 1 ? dataGVNhanVien.SelectedRows[0] : null;
            if(row != null)
            {
                int maNV = Convert.ToInt32(row.Cells["colMaNV"].Value);
                string tenNV = row.Cells["colTenNV"].Value.ToString();
                string message = $"Bạn có muốn xóa nhân viên {tenNV} không ?";
                string caption = "Xóa nhân viên";
                if(MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (NhanVienDAO.DeleteNhanVien(maNV))
                    {
                        MessageBox.Show("Xóa thành công");
                        InitNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn nhân viên để xóa");
            }
        }
    }
}
