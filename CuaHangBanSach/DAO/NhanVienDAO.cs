using CuaHangBanSach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangBanSach.DAO
{
    public class NhanVienDAO
    {
        public static List<NhanVien> LoadNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();
            string query = "select * from nhanvien";
            DataTable table = DataProvider.ExecuteQuery(query);
            foreach(DataRow row in table.Rows)
            {
                list.Add(new NhanVien(row));
            }
            return list;
        }

        public static bool InsertNhanVien(string tenNV, string sdt, string email, string diaChi, int gioiTinh, string ngaySinh, string ngayVaoLam, int chucVu, string tenTK)
        {
            string query
                = $"set dateformat dmy insert into nhanvien (TenNhanVien, SDT, Email, DiaChi, GioiTinh, NgaySinh, NgayVaoLam, QuyenHan, TenTaiKhoan) " +
                $"values (N'{tenNV}' , N'{sdt}' , N'{email}' , N'{diaChi}' , {gioiTinh} , '{ngaySinh}', '{ngayVaoLam}', {chucVu}, N'{tenTK}')";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static bool UpdateNhanVien(int maNV, string tenNV, string sdt, string email, string diaChi, int gioiTinh, string ngaySinh, string ngayVaoLam, int chucVu, string tenTK)
        {
            string query
                = $"set dateformat dmy update nhanvien " +
                $"set TenNhanVien = N'{tenNV}', SDT = N'{sdt}', Email = N'{email}', DiaChi = N'{diaChi}', GioiTinh = {gioiTinh}, NgaySinh = '{ngaySinh}', NgayVaoLam = '{ngayVaoLam}', QuyenHan = '{chucVu}', TenTaiKhoan = N'{tenTK}' " +
                $"where MaNhanVien = '{maNV}'";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static bool DeleteNhanVien(int maNV)
        {
            string query = $"delete from nhanvien where MaNhanVien = '{maNV}'";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static NhanVien GetNhanVienByTenTaiKhoanAndMatKhau(string tenTK, string matKhau)
        {
            string query = $"select * from NhanVien where TenTaiKhoan = N'{ tenTK }' And MatKhau = N'{ matKhau }' ";
            DataTable table = DataProvider.ExecuteQuery(query);
            if (table == null)
                return null;
            if(table.Rows.Count == 1)
            {
                return new NhanVien(table.Rows[0]);
            }
            return null;
        }

        public static bool DoiMatKhau(int maNV, string matKhauMoi)
        {
            string query
                = $"update nhanvien " +
                $"set MatKhau = N'{ matKhauMoi }'" +
                $"where MaNhanVien = '{ maNV }'";
            int row = 0;
            row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static DataTable GetCustomerTodayIsBirthday()
        {
            string query = "set dateformat dmy SELECT Ten, Email " +
                            "FROM KhachHang " +
                             "WHERE MONTH(GETDATE()) = MONTH(NgaySinh) AND DAY(GETDATE()) = DAY(NgaySinh)";
            DataTable rs = DataProvider.ExecuteQuery(query);
            if (rs.Rows.Count > 0)
                return rs;
            return null;

        }
    }
}
