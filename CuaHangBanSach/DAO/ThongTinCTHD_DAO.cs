using CuaHangBanSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DAO
{
    public class ThongTinCTHD_DAO
    {
        public static List<ThongTinCTHD> LoadCTHD()
        {
            List<ThongTinCTHD> cthdGroup = new List<ThongTinCTHD>();
            string query
                = "SELECT hd.mahoadon, s.tensach, cthd.soluong, cthd.gia " +
                    "from ChiTietHoaDon cthd, SACH s, HoaDon hd " +
                    "where cthd.MaSach = s.MaSach AND cthd.MaHoaDon = hd.MaHoaDon";
            DataTable cthd = DataProvider.ExecuteQuery(query);
            foreach(DataRow record in cthd.Rows)
            {
                cthdGroup.Add(new ThongTinCTHD(record));
            }
            return cthdGroup;
        }
    }
}
