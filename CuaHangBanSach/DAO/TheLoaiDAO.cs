using CuaHangBanSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangBanSach.DAO
{
    class TheLoaiDAO
    {
        public static List<TheLoai> LoadTheLoai()
        {
            List<TheLoai> list = new List<TheLoai>();
            string query = "select * from theloai";
            DataTable table = DataProvider.ExecuteQuery(query);
            foreach(DataRow row in table.Rows)
            {
                TheLoai theloai = new TheLoai(row);
                list.Add(theloai);
            }
            return list;
        }

        public static int GetIdTheLoaiByName(string name)
        {
            string query = $"select MaTheLoai from TheLoai where TenTheLoai = N'{name}'";
            int id = DataProvider.ExecuteScalar(query) != null ? Convert.ToInt32(DataProvider.ExecuteScalar(query)) : -1;
            return id;
        }

        public static bool InsertTheLoai(string tenTheLoai)
        {
            string query = $"insert into TheLoai (TenTheLoai) values (N'{tenTheLoai}')";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static bool UpdateTheLoai(int maTheLoai, string tenTheLoai)
        {
            string query = $"update TheLoai set TenTheLoai = N'{tenTheLoai}' where MaTheLoai = {maTheLoai}";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static bool DeleteTheLoai(int maTheLoai)
        {
            string query = $"delete TheLoai where MaTheLoai = {maTheLoai}";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }
    }
}
