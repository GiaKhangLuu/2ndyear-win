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
    public partial class FormCTHoaDon : Form
    {
        public FormCTHoaDon()
        {
            InitializeComponent();
            InitCTHD();
        }

        public void InitCTHD()
        {
            List<ThongTinCTHD> cthdGroup = ThongTinCTHD_DAO.LoadCTHD();
            foreach(ThongTinCTHD cthd in cthdGroup)
            {
                dataGV_CTHD.Rows.Add(cthd.ItemArray());
            }
            dataGV_CTHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinBảnThânToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void thôngTinBảnThânToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormCTHoaDon_Load(object sender, EventArgs e)
        {

        }
    }
}
