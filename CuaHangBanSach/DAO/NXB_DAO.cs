using CuaHangBanSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DAO
{
    public class NXB_DAO
    {
        public static List<NXB> LoadNXB()
        {
            List<NXB> list = new List<NXB>();
            string query = "select * from nhaxuatban";
            DataTable table = DataProvider.ExecuteQuery(query);
            foreach(DataRow row in table.Rows)
            {
                list.Add(new NXB(row));
            }
            return list;
        }

        public static int GetIdNXBByName(string name)
        {
            string query = $"select MaNXB from NhaXuatBan where TenNXB = N'{ name }'";
            int id = DataProvider.ExecuteScalar(query) != null ? Convert.ToInt32(DataProvider.ExecuteScalar(query)) : -1;
            return id;
        }

        public static bool InsertNXB(string tenNXB)
        {
            string query = $"insert into NhaXuatBan (TenNXB) values (N'{tenNXB}')";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static bool UpdateNXB(int maNXB, string tenNXB)
        {
            string query = $"update NhaXuatBan set TenNXB = N'{tenNXB}' where MaNXB = {maNXB}";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static bool DeleteNXB(int maNXB)
        {
            string query = $"delete NhaXuatBan where MaNXB = {maNXB}";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }
    }
}
