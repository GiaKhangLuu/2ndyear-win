using CuaHangBanSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DAO
{
    public class ThongTinHoaDonDAO
    { 
        public static List<ThongTinHoaDon> LoadHoaDon()
        {
            List<ThongTinHoaDon> hoaDonGroup = new List<ThongTinHoaDon>();
            string query
                = "select hd.mahoadon, kh.Ten, nv.tennhanvien, hd.ngayban " +
                    "from HoaDon hd, KhachHang kh, NhanVien nv " +
                    "where hd.MaKhachHang = kh.MaKhachHang AND nv.MaNhanVien = hd.MaNhanVien";
            DataTable menuHoaDon = DataProvider.ExecuteQuery(query);
            foreach(DataRow record in menuHoaDon.Rows)
            {
                hoaDonGroup.Add(new ThongTinHoaDon(record));
            }
            return hoaDonGroup;
        }
    }
}
