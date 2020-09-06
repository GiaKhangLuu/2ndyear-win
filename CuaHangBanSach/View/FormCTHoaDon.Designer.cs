namespace CuaHangBanSach
{
    partial class FormCTHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataSet1 = new System.Data.DataSet();
            this.dataGV_CTHD = new System.Windows.Forms.DataGridView();
            this.colMaHd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_CTHD)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // dataGV_CTHD
            // 
            this.dataGV_CTHD.AllowUserToAddRows = false;
            this.dataGV_CTHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_CTHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaHd,
            this.colTenSanPham,
            this.colSoLuong,
            this.colGia});
            this.dataGV_CTHD.Location = new System.Drawing.Point(16, 15);
            this.dataGV_CTHD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGV_CTHD.MultiSelect = false;
            this.dataGV_CTHD.Name = "dataGV_CTHD";
            this.dataGV_CTHD.ReadOnly = true;
            this.dataGV_CTHD.RowHeadersWidth = 51;
            this.dataGV_CTHD.Size = new System.Drawing.Size(591, 284);
            this.dataGV_CTHD.TabIndex = 1;
            this.dataGV_CTHD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // colMaHd
            // 
            this.colMaHd.HeaderText = "Mã Hóa Đơn";
            this.colMaHd.MinimumWidth = 6;
            this.colMaHd.Name = "colMaHd";
            this.colMaHd.ReadOnly = true;
            this.colMaHd.Width = 125;
            // 
            // colTenSanPham
            // 
            this.colTenSanPham.HeaderText = "Tên Sản Phẩm";
            this.colTenSanPham.MinimumWidth = 6;
            this.colTenSanPham.Name = "colTenSanPham";
            this.colTenSanPham.ReadOnly = true;
            this.colTenSanPham.Width = 125;
            // 
            // colSoLuong
            // 
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.MinimumWidth = 6;
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            this.colSoLuong.Width = 125;
            // 
            // colGia
            // 
            this.colGia.HeaderText = "Giá";
            this.colGia.MinimumWidth = 6;
            this.colGia.Name = "colGia";
            this.colGia.ReadOnly = true;
            this.colGia.Width = 125;
            // 
            // FormCTHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 318);
            this.Controls.Add(this.dataGV_CTHD);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormCTHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết hóa đơn";
            this.Load += new System.EventHandler(this.FormCTHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_CTHD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.DataGridView dataGV_CTHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGia;
    }
}