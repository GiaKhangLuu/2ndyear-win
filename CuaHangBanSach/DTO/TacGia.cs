using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DTO
{
    public class TacGia
    {
        private int maTacGia;
        private string tenTacGia;

        public int MaTacGia { get => maTacGia; set => maTacGia = value; }
        public string TenTacGia { get => tenTacGia; set => tenTacGia = value; }

        public TacGia(int maTacGia, string tenTacGia)
        {
            this.maTacGia = maTacGia;
            this.tenTacGia = tenTacGia;
        }

        public TacGia(DataRow row)
        {
            this.maTacGia = Convert.ToInt32(row["MaTacGia"]);
            this.tenTacGia = row["TenTacGia"].ToString();
        }

        public object[] ItemArray()
        {
            return new object[] { MaTacGia, TenTacGia };
        }
    }
}
