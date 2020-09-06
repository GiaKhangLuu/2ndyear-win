using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DTO
{
    public class HoaDon
    {
        private string mahoadon;
        private int makhachhang, manhanvien;
        private DateTime ngayBan;

        public string Mahoadon { get => mahoadon; set => mahoadon = value; }
        public int Makhachhang { get => makhachhang; set => makhachhang = value; }
        public int Manhanvien { get => manhanvien; set => manhanvien = value; }
        public DateTime NgayBan { get => ngayBan; set => ngayBan = value; }

        public HoaDon(DataRow row)
        {
            this.mahoadon = row["MaHoaDon"].ToString();
            this.makhachhang = Convert.ToInt32(row["MaKhachHang"]);
            this.manhanvien = Convert.ToInt32(row["MaNhanVien"]);
            this.ngayBan = (DateTime)row["NgayBan"];
        }

        public object[] ItemArray()
        {
            return new object[] { Mahoadon, Makhachhang, Manhanvien, ngayBan };
        }
    }
}
