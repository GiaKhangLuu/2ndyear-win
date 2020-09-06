using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DTO
{
    public class Sach
    {
        private string maSach, tenSach;
        private int theLoai, tacGia, nxb;
        private double gia;
        private int soLuong;

        public Sach() { }
        
        public Sach(DataRow row)
        {
            this.maSach = row["MaSach"].ToString();
            this.tenSach = row["TenSach"].ToString();
            this.theLoai = Convert.ToInt32(row["MaTheLoai"]);
            this.tacGia = Convert.ToInt32(row["MaTacGia"]);
            this.nxb = Convert.ToInt32(row["MaNXB"]);
            this.Gia = Convert.ToDouble(row["Gia"]);
            this.SoLuong = Convert.ToInt32(row["SoLuong"]);
        }

        public object[] ItemArray()
        {
            return new object[] { MaSach, TenSach, TheLoai, TacGia, Nxb, Gia, SoLuong };
        }

        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public int TheLoai { get => theLoai; set => theLoai = value; }
        public int TacGia { get => tacGia; set => tacGia = value; }
        public int Nxb { get => nxb; set => nxb = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double Gia { get => gia; set => gia = value; }
    }
}
