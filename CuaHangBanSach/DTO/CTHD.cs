using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DTO
{
    public class CTHD
    {
        private string maHoaDon, maSach;
        private int soLuong;
        private double gia;

        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string MaSach { get => maSach; set => maSach = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double Gia { get => gia; set => gia = value; }

        public CTHD(DataRow row)
        {
            this.maHoaDon = row["MaHoaDon"].ToString();
            this.maSach = row["MaSach"].ToString();
            this.soLuong = (int)row["SoLuong"];
            this.gia = Convert.ToDouble(row["Gia"]);
        }

        public object[] ItemArray()
        {
            return new object[] { MaHoaDon, MaSach, SoLuong, Gia };
        }
    }
}
