using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DTO
{
    public class ThongTinHoaDon
    {
        private string maHoaDon, tenKhachHang, tenNhanVien;
        private DateTime ngayBan;

        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public DateTime NgayBan { get => ngayBan; set => ngayBan = value; }

        public ThongTinHoaDon(DataRow row)
        {
            this.maHoaDon = row["MaHoaDon"].ToString();
            this.tenKhachHang = row["Ten"].ToString();
            this.tenNhanVien = row["TenNhanVien"].ToString();
            this.ngayBan = (DateTime)row["NgayBan"];
        }

        public object[] ItemArray()
        {
            return new object[] { MaHoaDon, TenKhachHang, tenNhanVien, NgayBan };
        }
    }
}
