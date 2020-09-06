using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DTO
{
    public class ThongTinCTHD
    {
        private string maHD, tenSach;
        private int soLuong;
        private double gia;

        public string MaHD { get => maHD; set => maHD = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double Gia { get => gia; set => gia = value; }

        public ThongTinCTHD(DataRow record)
        {
            this.maHD = record["MaHoaDon"].ToString();
            this.tenSach = record["TenSach"].ToString();
            this.soLuong = (int)record["SoLuong"];
            this.gia = Convert.ToDouble(record["Gia"]);
        }

        public object[] ItemArray()
        {
            return new object[] { MaHD, TenSach, SoLuong, Gia };
        }
    }
}
