using CuaHangBanSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DAO
{
    public class KhachHangDAO
    {
        public static List<KhachHang> LoadKhachHang()
        {
            List<KhachHang> list = new List<KhachHang>();
            string query = "select * from khachhang";
            DataTable table = DataProvider.ExecuteQuery(query);
            foreach(DataRow row in table.Rows)
            {
                list.Add(new KhachHang(row));
            }
            return list;
        }

        public static bool InsertKhachHang(string tenKH, string sdt, string email, string diaChi, int gioiTinh, string ngaySinh)
        {
            string query
                = $"set dateformat dmy insert into khachhang (Ten, SDT, Email, DiaChi, GioiTinh, NgaySinh) " +
                $"values (N'{tenKH}' , N'{sdt}' , N'{email}' , N'{diaChi}' , {gioiTinh} , '{ngaySinh}')";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static bool UpdateKhachang(int maKH, string tenKH, string sdt, string email, string diaChi, int gioiTinh, string ngaySinh)
        {
            string query
                = $"set dateformat dmy update khachhang " +
                $"set Ten = N'{tenKH}', SDT = N'{sdt}', Email = N'{email}', DiaChi = N'{diaChi}', GioiTinh = {gioiTinh}, NgaySinh = '{ngaySinh}' " +
                $"where MaKhachHang = '{maKH}'";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static bool DeleteKhachHang(int maKH)
        {
            string query = $"delete from khachhang where MaKhachHang = '{maKH}'";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static string GetMaKhachHangByCondition(string tenKH, string email, string sdt, string ngaySinh)
        {
            string query = "set dateformat dmy select MaKhachHang from KhachHang where " +
                $"Ten=N'{ tenKH }' AND SDT=N'{ sdt }' AND Email=N'{ email }' AND NgaySinh='{ ngaySinh }'";
            string maKH = DataProvider.ExecuteScalar(query) != null ? DataProvider.ExecuteScalar(query).ToString() : "";
            return maKH;
        }
    }
}
