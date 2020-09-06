using CuaHangBanSach.DAO;
using CuaHangBanSach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangBanSach
{
    public partial class FormHoaDon : Form
    {
        public FormHoaDon()
        {
            InitializeComponent();
            InitHoaDon();
        }

        public void InitHoaDon()
        {
            List<ThongTinHoaDon> ttHoaDonGroup = ThongTinHoaDonDAO.LoadHoaDon();
            foreach(ThongTinHoaDon hoaDon in ttHoaDonGroup)
            {
                dataGVHoaDon.Rows.Add(hoaDon.ItemArray());
            }
            dataGVHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
