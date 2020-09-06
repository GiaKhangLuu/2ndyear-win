using CuaHangBanSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DAO
{
    public class HoaDonDAO
    {
        public static List<HoaDon> LoadHoaDon()
        {
            List<HoaDon> list = new List<HoaDon>();
            string query = "select * from hoadon";
            DataTable table = DataProvider.ExecuteQuery(query);
            foreach(DataRow row in table.Rows)
            {
                list.Add(new HoaDon(row));
            }
            return list;
        }

        public static bool InsertHoaDon(int maNV, int maKH, string ngayBan)
        {
            string query = "set dateformat dmy insert into HoaDon (MaNhanVien, MaKhachHang, NgayBan) " +
                   $"values ({ maNV }, { maKH }, '{ ngayBan }')";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static string GetMaHoaDonByCondition(int maNV, int MaKH, string ngayBan)
        {
            string query = "set dateformat dmy select MaHoaDon from HoaDon where " +
                $"MaNhanVien={ maNV } AND MaKhachHang={ MaKH } AND NgayBan='{ ngayBan }'";//ngay ban bat buoc phai la datetime vi ngay ban se phan biet hoa don nao ban trc hoa don nao ban sau neu manv va makh trung nhau
            string maHD = DataProvider.ExecuteScalar(query) != null ? DataProvider.ExecuteScalar(query).ToString() : "";
            return maHD;
        }
    }
}
