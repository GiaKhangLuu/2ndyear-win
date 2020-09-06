using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DTO
{
    public class NXB
    {
        private int maNXB;
        private string tenNXB;

        public int MaNXB { get => maNXB; set => maNXB = value; }
        public string TenNXB { get => tenNXB; set => tenNXB = value; }

        public NXB(int maNXB, string tenNXB)
        {
            this.maNXB = maNXB;
            this.tenNXB = tenNXB;
        }

        public NXB(DataRow row)
        {
            this.maNXB = Convert.ToInt32(row["MaNXB"]);
            this.tenNXB = row["TenNXB"].ToString();
        }

        public object[] ItemArray()
        {
            return new object[] { MaNXB, TenNXB };
        }
    }
}
