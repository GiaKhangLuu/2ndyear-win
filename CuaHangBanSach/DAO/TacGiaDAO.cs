using CuaHangBanSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DAO
{
    public class TacGiaDAO
    {
        public static List<TacGia> LoadTacGia()
        {
            List<TacGia> list = new List<TacGia>();
            string query = "select * from tacgia";
            DataTable table = DataProvider.ExecuteQuery(query);
            foreach(DataRow row in table.Rows)
            {
                TacGia tg = new TacGia(row);
                list.Add(tg);
            }
            return list;
        }

        public static int GetIdTacGiaByName(string name)
        {
            string query = $"select MaTacGia from TacGia where TenTacGia = N'{name}'";
            int id = DataProvider.ExecuteScalar(query) != null ? Convert.ToInt32(DataProvider.ExecuteScalar(query)) : -1;
            return id;
        }

        public static bool InsertTacGia(string tenTacGia)
        {
            string query = $"insert into TacGia (TenTacGia) values (N'{tenTacGia}')";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static bool UpdateTacGia(int maTacGia, string tenTacGia)
        {
            string query = $"update TacGia set TenTacGia = N'{tenTacGia}' where MaTacGia = {maTacGia}";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }

        public static bool DeleteTacGia(int maTacGia)
        {
            string query = $"delete TacGia where MaTacGia = {maTacGia}";
            int row = DataProvider.ExecuteNonQuery(query);
            return row > 0;
        }
    }
}
