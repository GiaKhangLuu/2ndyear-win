using CuaHangBanSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DAO
{
    public class SachDAO
    {
        public static List<Sach> LoadSach()
        {
            List<Sach> tableList = new List<Sach>();
            string query = "select masach, tensach, matheloai, matacgia, manxb, gia, soluong from sach";
            DataTable table = DataProvider.ExecuteQuery(query);
            foreach(DataRow row in table.Rows)
            {
                Sach sach = new Sach(row);
                tableList.Add(sach);
            }
            return tableList;
        }

        public static bool InsertSach(string tenSach, int maNXB, int maTacGia, int maTheLoai, double gia, double soLuong)
        {
            string query
                = $"insert into sach (TheLoai, TenSach, MaNXB, MaTacGia, MaTheLoai, Gia, soluong) " +
                $"values ( 'S' , N'{ tenSach }' , { maNXB } , { maTacGia } , { maTheLoai } , { gia } , { soLuong } )";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static bool UpdateSach(string maSach, string tenSach, int maNXB, int maTacGia, int maTheLoai, double gia, double soLuong)
        {
            string query
                = $"update sach " +
                $"set TenSach = N'{tenSach}', MaNXB = {maNXB}, MaTacGia = {maTacGia}, MaTheLoai = {maTheLoai}, SoLuong = {soLuong}, Gia = {gia} " +
                $"where MaSach = N'{maSach}'";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static bool UpdateSoLuong(string maSach, int soLuong)
        {
            string query = $"update Sach set SoLuong={ soLuong } where MaSach=N'{ maSach }'";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static bool DeleteSach(string maSach)
        {
            string query = $"delete from sach where MaSach = N'{maSach}'";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }
    }
}
