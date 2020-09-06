using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DTO
{
    public class KhachHang
    {
        private int maKhachHang;
        private string tenKhachHang, sdt, email, diaChi;
        private int gioitinh;
        private DateTime ngaySinh;

        public int MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public DateTime NgaySinh { get => ngaySinh.Date; set => ngaySinh = value; }
        public int Gioitinh { get => gioitinh; set => gioitinh = value; }

        public KhachHang(DataRow row)
        {
            this.maKhachHang = Convert.ToInt32(row["MaKhachHang"]);
            this.tenKhachHang = row["Ten"].ToString();
            this.sdt = row["SDT"].ToString();
            this.email = row["Email"].ToString();
            this.diaChi = row["DiaChi"].ToString();
            this.gioitinh = Convert.ToInt32(row["Gioitinh"]); 
            string ngaySinhTemp = row["NgaySinh"].ToString();
            if (ngaySinhTemp != "")
                this.ngaySinh = Convert.ToDateTime(ngaySinhTemp).Date;
        }

        public object[] ItemArray()
        {
            return new object[] { MaKhachHang, TenKhachHang, Sdt, Email, DiaChi, Gioitinh, NgaySinh };
        }
    }
}
