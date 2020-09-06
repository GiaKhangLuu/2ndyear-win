using CuaHangBanSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DAO
{
    public class ThongTinSachDAO
    {
        public static List<ThongTinSach> LoadSach()
        {
            List<ThongTinSach> sachGroup = new List<ThongTinSach>();
            string query 
                = "select s.masach, s.tensach, tl.tentheloai, tg.tentacgia, nxb.TenNXB, s.gia, s.soluong " +
                    "from sach s, TheLoai tl, NhaXuatBan nxb, TacGia tg " + 
                    "where s.MaTheLoai = tl.MaTheLoai AND s.MaTacGia = tg.MaTacGia AND s.MaNXB = nxb.MaNXB";
            DataTable menuSach = DataProvider.ExecuteQuery(query);
            foreach(DataRow record in menuSach.Rows)
            {
                sachGroup.Add(new ThongTinSach(record));
            }
            return sachGroup;
        }
    }
}
