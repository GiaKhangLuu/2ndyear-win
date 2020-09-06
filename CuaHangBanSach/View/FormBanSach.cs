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

namespace CuaHangBanSach.View
{
    public partial class FormBanSach : Form
    {
        private NhanVien nv;
        private List<Sach> sachGroup;
        public FormBanSach(NhanVien nv, List<Sach> sachGroup)
        {
            InitializeComponent();
            this.nv = nv;
            this.sachGroup = sachGroup;
            dataGVGioHang.AllowUserToAddRows = false;
            dataGVGioHang.ReadOnly = true;
            InitNhanVien();
            InitSach();
        }

        private void InitNhanVien()
        {
            if(nv != null)
            {
                tbMaNV.Text = nv.MaNV.ToString();
                tbTenNV.Text = nv.TenNV;
                tbEmail_NV.Text = nv.Email;
                tbSDT_NV.Text = nv.Sdt;
            }
        }

        private void InitSach()
        {
            if(sachGroup != null)
            {
                foreach (Sach sach in sachGroup)
                {
                    cmbTenSach.Items.Add(sach.TenSach);
                }
            }    
        }

        private void cmbTenSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbTenSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbTenSach.SelectedIndex;
            string maSach = sachGroup[index].MaSach;
            int soLuongConLai = sachGroup[index].SoLuong;
            tbMaSach.Text = maSach;
            numSoLuong.Value = 1;
            tbSoLuongConLai.Text = soLuongConLai.ToString();
        }

        private void tbTen_KH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void tbSDT_KH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private double GetTotal()
        {
            double total = 0;
            foreach(DataGridViewRow record in dataGVGioHang.Rows)
            {
                double temp = Convert.ToDouble(record.Cells["colSoLuong"].Value) * Convert.ToDouble(record.Cells["colGia"].Value);
                total += temp;
            }
            return total;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(tbMaSach.Text != "")
            {
                int index = cmbTenSach.SelectedIndex;
                Sach sach = sachGroup[index];
                string maSach = sach.MaSach;
                string tenSach = sach.TenSach;
                string soLuong = numSoLuong.Value.ToString();
                string gia = sach.Gia.ToString();
                AddToCart(maSach, tenSach, soLuong, gia);
                tbTongTien.Text = GetTotal().ToString();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sách để thêm vào giỏ hàng");
            }
        }

        private int FindIndexOfItemInCart(string maSach)
        {
            for(int i = 0; i < dataGVGioHang.Rows.Count; i++)
            {
                DataGridViewRow record = dataGVGioHang.Rows[i];
                if (maSach == record.Cells["colMaSach"].Value.ToString())
                    return i;
            }
            return -1;
        }

        private void AddToCart(string maSach, string tenSach, string soLuong, string gia)
        {
            int index = FindIndexOfItemInCart(maSach);
            if(index != -1)
            {
                //Them san pham khi san pham da co trong gio hang
                int qty = Convert.ToInt32(dataGVGioHang.Rows[index].Cells["colSoLuong"].Value);
                int quantyToAdd = qty + Convert.ToInt32(soLuong);
                int quantyInStock = Convert.ToInt32(tbSoLuongConLai.Text);
                if(IsAvailable(quantyToAdd, quantyInStock))
                {
                    dataGVGioHang.Rows[index].Cells["colSoLuong"].Value = quantyToAdd;
                }
                else
                {
                    MessageBox.Show("Số lượng muốn thêm vượt quá số lượng trong kho");
                }
            }
            else
            {
                //Them san pham khi san pham chua co trong gio hang
                int quantyToAdd = Convert.ToInt32(soLuong);
                int quantyInStock = Convert.ToInt32(tbSoLuongConLai.Text);
                if(IsAvailable(quantyToAdd, quantyInStock))
                {
                    dataGVGioHang.Rows.Add(new string[] { maSach, tenSach, soLuong, gia });
                    dataGVGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    MessageBox.Show("Số lượng muốn thêm vượt quá số lượng trong kho");
                }
            }
        }

        private bool IsAvailable(int quantyToAdd, int quantyInStock)
        {
            if (quantyToAdd > quantyInStock)
                return false;
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGVGioHang.SelectedRows.Count == 1 ? dataGVGioHang.SelectedRows[0] : null;
            if(row != null)
            {
                string message = "Bạn có muốn xóa sản phẩm khỏi giỏ hàng";
                string caption = "Xóa sản phẩm khỏi giỏ hàng";
                if(MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dataGVGioHang.Rows.Remove(row);
                    tbTongTien.Text = GetTotal().ToString();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm để xóa khỏi giỏ hàng");
            }
        }

        private int GetMaKH(string tenKH, string email, string sdt, string ngaySinh)
        {
            string maKH = KhachHangDAO.GetMaKhachHangByCondition(tenKH, email, sdt, ngaySinh);
            while (maKH == "")
            {
                KhachHangDAO.InsertKhachHang(tenKH, sdt, email, "", 0, ngaySinh);
                maKH = KhachHangDAO.GetMaKhachHangByCondition(tenKH, email, sdt, ngaySinh);
            }
            return Convert.ToInt32(maKH);
        }

        private int getQuantityInStockByMaSach(string maSach)
        {
            foreach(Sach item in sachGroup)
            {
                if (maSach == item.MaSach)
                    return item.SoLuong;
            }
            return -1;
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            if(dataGVGioHang.Rows.Count > 0)
            {
                string tenKH = tbTen_KH.Text;
                string email = tbEmail_KH.Text;
                string sdt = tbSDT_KH.Text;
                string ngaySinh = dtPickerNgaySinh_KH.Value.Date.ToString("dd/MM/yyyy");
                int maKH = GetMaKH(tenKH, email, sdt, ngaySinh);
                string ngayBan = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
                int maNV = nv.MaNV;
                HoaDonDAO.InsertHoaDon(maNV, maKH, ngayBan);
                string maHD = HoaDonDAO.GetMaHoaDonByCondition(maNV, maKH, ngayBan);
                foreach(DataGridViewRow record in dataGVGioHang.Rows)
                {
                    string maSach = record.Cells["colMaSach"].Value.ToString();
                    int soLuong = Convert.ToInt32(record.Cells["colSoLuong"].Value);
                    double gia = Convert.ToDouble(record.Cells["colGia"].Value);
                    if (CTHD_DAO.InsertCTHD(maHD, maSach, soLuong, gia))
                    {                        
                        SachDAO.UpdateSoLuong(maSach, getQuantityInStockByMaSach(maSach) - soLuong);
                    }
                }
                MessageBox.Show("Hoàn tất đơn hàng");
                Dispose();
                FormBanSach newForm = new FormBanSach(this.nv, SachDAO.LoadSach());
                newForm.Show();
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm nào trong giỏ hàng");
            }
        }
        private void numSoLuong_ValueChanged(object sender, EventArgs e)
        {
            decimal value = numSoLuong.Value;
            if (value < 1)
                numSoLuong.Value = 1;
        }
    }
}
