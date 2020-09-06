using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DTO
{
    public class ThongTinSach
    {
        private string maSach, tenSach, tenTheLoai, tenTacGia, tenNXB;
        private int soLuong;
        private double gia;

        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string TenTheLoai { get => tenTheLoai; set => tenTheLoai = value; }
        public string TenTacGia { get => tenTacGia; set => tenTacGia = value; }
        public string TenNXB { get => tenNXB; set => tenNXB = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double Gia { get => gia; set => gia = value; }

        public ThongTinSach(DataRow row)
        {
            this.maSach = row["MaSach"].ToString();
            this.tenSach = row["TenSach"].ToString();
            this.tenTheLoai = row["TenTheLoai"].ToString();
            this.tenTacGia = row["TenTacGia"].ToString();
            this.tenNXB = row["TenNXB"].ToString();
            this.gia = Convert.ToDouble(row["Gia"]);
            this.SoLuong = (int)row["SoLuong"];
        }

        public object[] ItemArray()
        {
            return new object[] { MaSach, TenSach, TenTheLoai, TenTacGia, TenNXB, Gia, SoLuong };
        }
    }
}
