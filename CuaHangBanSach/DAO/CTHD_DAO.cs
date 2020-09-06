using CuaHangBanSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DAO
{
    public class CTHD_DAO
    {
        public static List<CTHD> LoadCTHD()
        {
            List<CTHD> list = new List<CTHD>();
            string query = "select * from chitiethoadon";
            DataTable table = DataProvider.ExecuteQuery(query);
            foreach(DataRow row in table.Rows)
            {
                list.Add(new CTHD(row));
            }
            return list;
        }

        public static bool InsertCTHD(string maHD, string maSach, int soLuong, double gia)
        {
            string query = "insert into ChiTietHoaDon (MaHoaDon, MaSach, SoLuong, Gia) " +
                $"values (N'{ maHD }', N'{ maSach }', { soLuong }, { gia })";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }
    }
}
