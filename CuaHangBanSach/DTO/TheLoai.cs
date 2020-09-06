using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DTO
{
    public class TheLoai
    {
        private int id;
        private string tenTheLoai;

        public int Id { get => id; set => id = value; }
        public string TenTheLoai { get => tenTheLoai; set => tenTheLoai = value; }

        public TheLoai(int id, string tenTheLoai)
        {
            this.id = id;
            this.tenTheLoai = tenTheLoai;
        }

        public TheLoai(DataRow row)
        {
            this.id = Convert.ToInt32(row["MaTheLoai"]);
            this.tenTheLoai = row["TenTheLoai"].ToString();
        }

        public object[] ItemArray()
        {
            return new object[] { Id, TenTheLoai };
        }
    }
}
