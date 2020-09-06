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
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
        {
            InitializeComponent();
            InitKhachHang();
        }

        public void InitKhachHang()
        {
            dataGVKhachHang.Rows.Clear();
            List<KhachHang> khachHangGroup = KhachHangDAO.LoadKhachHang();
            int index = 0;
            foreach(KhachHang item in khachHangGroup)
            {
                dataGVKhachHang.Rows.Add(item.ItemArray());
                DataGridViewCell cellGioiTinh = dataGVKhachHang.Rows[index].Cells["colGioiTinh"];
                cellGioiTinh.Value = (Convert.ToInt32(cellGioiTinh.Value)) == 1 ? "Nam" : "Nữ";
                index++;
            }
            dataGVKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThem_CapNhatKH newForm = new FormThem_CapNhatKH();
            this.Visible = false;
            newForm.Show();
            newForm.Disposed += NewForm_Disposed;
        }

        private void NewForm_Disposed(object sender, EventArgs e)
        {
            this.Visible = true;
            InitKhachHang();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGVKhachHang.SelectedRows.Count >= 1 ? dataGVKhachHang.SelectedRows[0] : null;
            if(row != null)
            {
                string maKH = row.Cells["colMaKH"].Value.ToString();
                string tenKH = row.Cells["colTenKH"].Value.ToString();
                string email = row.Cells["colEmail"].Value.ToString();
                string sdt = row.Cells["colSDT"].Value.ToString();
                string diaChi = row.Cells["colDC"].Value.ToString();
                string gioiTinh = row.Cells["colGioiTinh"].Value.ToString();
                DateTime ngaySinh = (DateTime)row.Cells["colNgaySinh"].Value;
                FormThem_CapNhatKH newForm = new FormThem_CapNhatKH(maKH, tenKH, sdt, email, diaChi, gioiTinh, ngaySinh);
                this.Visible = false;
                newForm.Show();
                newForm.Disposed += NewForm_Disposed;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn khách hàng để sửa");
;            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGVKhachHang.SelectedRows.Count >= 1 ? dataGVKhachHang.SelectedRows[0] : null;
            if (row != null)
            {
                int maKhachHang = Convert.ToInt32(row.Cells["colMaKH"].Value);
                string tenKhachHang = row.Cells["colTenKH"].Value.ToString();
                string message = $"Bạn có muốn xóa khách hàng {tenKhachHang} không ?";
                string caption = "Xóa Khách Hàng";
                if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { 
                    if (KhachHangDAO.DeleteKhachHang(maKhachHang))
                    {
                        MessageBox.Show("Xóa khách hàng thành công");
                        InitKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Xóa khách hàng không thành công");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn khách hàng để xóa");
            }
        }
    }
}
