namespace CuaHangBanSach
{
    partial class FormMain
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
            this.menuHeader = new System.Windows.Forms.MenuStrip();
            this.tàiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTTCaNhan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemTTNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTTKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemTTSach = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTTTacGia = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTTNXB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTTTheLoai = new System.Windows.Forms.ToolStripMenuItem();
            this.bánSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBanSach = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemTTHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTTCTHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuHeader
            // 
            this.menuHeader.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tàiToolStripMenuItem,
            this.quảnLýToolStripMenuItem,
            this.bánSáchToolStripMenuItem});
            this.menuHeader.Location = new System.Drawing.Point(0, 0);
            this.menuHeader.Name = "menuHeader";
            this.menuHeader.Size = new System.Drawing.Size(1068, 28);
            this.menuHeader.TabIndex = 0;
            this.menuHeader.Text = "menuStrip1";
            // 
            // tàiToolStripMenuItem
            // 
            this.tàiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemTTCaNhan,
            this.menuItemDoiMatKhau,
            this.menuItemDangXuat,
            this.toolStripSeparator4,
            this.menuItemTTNhanVien});
            this.tàiToolStripMenuItem.Name = "tàiToolStripMenuItem";
            this.tàiToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.tàiToolStripMenuItem.Text = "Tài khoản";
            // 
            // menuItemTTCaNhan
            // 
            this.menuItemTTCaNhan.Name = "menuItemTTCaNhan";
            this.menuItemTTCaNhan.Size = new System.Drawing.Size(230, 26);
            this.menuItemTTCaNhan.Text = "Thông Tin Cá Nhân";
            this.menuItemTTCaNhan.Click += new System.EventHandler(this.thongTinBanThan_Click);
            // 
            // menuItemDoiMatKhau
            // 
            this.menuItemDoiMatKhau.Name = "menuItemDoiMatKhau";
            this.menuItemDoiMatKhau.Size = new System.Drawing.Size(230, 26);
            this.menuItemDoiMatKhau.Text = "Đổi Mật Khẩu";
            this.menuItemDoiMatKhau.Click += new System.EventHandler(this.menuItemDoiMatKhau_Click);
            // 
            // menuItemDangXuat
            // 
            this.menuItemDangXuat.Name = "menuItemDangXuat";
            this.menuItemDangXuat.Size = new System.Drawing.Size(230, 26);
            this.menuItemDangXuat.Text = "Đăng Xuất";
            this.menuItemDangXuat.Click += new System.EventHandler(this.menuItemDangXuat_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(227, 6);
            // 
            // menuItemTTNhanVien
            // 
            this.menuItemTTNhanVien.Enabled = false;
            this.menuItemTTNhanVien.Name = "menuItemTTNhanVien";
            this.menuItemTTNhanVien.Size = new System.Drawing.Size(230, 26);
            this.menuItemTTNhanVien.Text = "Thông Tin Nhân Viên";
            this.menuItemTTNhanVien.Click += new System.EventHandler(this.danhSáchNhânViênToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemTTKhachHang,
            this.toolStripSeparator2,
            this.menuItemTTSach,
            this.menuItemTTTacGia,
            this.menuItemTTNXB,
            this.menuItemTTTheLoai});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // menuItemTTKhachHang
            // 
            this.menuItemTTKhachHang.Name = "menuItemTTKhachHang";
            this.menuItemTTKhachHang.Size = new System.Drawing.Size(252, 26);
            this.menuItemTTKhachHang.Text = "Thông Tin Khách Hàng";
            this.menuItemTTKhachHang.Click += new System.EventHandler(this.menuItemTTKhachHang_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(249, 6);
            // 
            // menuItemTTSach
            // 
            this.menuItemTTSach.Name = "menuItemTTSach";
            this.menuItemTTSach.Size = new System.Drawing.Size(252, 26);
            this.menuItemTTSach.Text = "Thông Tin Sách";
            this.menuItemTTSach.Click += new System.EventHandler(this.thôngTinSáchToolStripMenuItem_Click);
            // 
            // menuItemTTTacGia
            // 
            this.menuItemTTTacGia.Name = "menuItemTTTacGia";
            this.menuItemTTTacGia.Size = new System.Drawing.Size(252, 26);
            this.menuItemTTTacGia.Text = "Thông Tin Tác Giả";
            this.menuItemTTTacGia.Click += new System.EventHandler(this.menuItemTTTacGia_Click);
            // 
            // menuItemTTNXB
            // 
            this.menuItemTTNXB.Name = "menuItemTTNXB";
            this.menuItemTTNXB.Size = new System.Drawing.Size(252, 26);
            this.menuItemTTNXB.Text = "Thông Tin Nhà Xuất Bản";
            this.menuItemTTNXB.Click += new System.EventHandler(this.menuItemTTNXB_Click);
            // 
            // menuItemTTTheLoai
            // 
            this.menuItemTTTheLoai.Name = "menuItemTTTheLoai";
            this.menuItemTTTheLoai.Size = new System.Drawing.Size(252, 26);
            this.menuItemTTTheLoai.Text = "Thông Tin Thể Loại";
            this.menuItemTTTheLoai.Click += new System.EventHandler(this.menuItemTTTheLoai_Click);
            // 
            // bánSáchToolStripMenuItem
            // 
            this.bánSáchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemBanSach,
            this.toolStripSeparator1,
            this.menuItemTTHoaDon,
            this.menuItemTTCTHoaDon});
            this.bánSáchToolStripMenuItem.Name = "bánSáchToolStripMenuItem";
            this.bánSáchToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.bánSáchToolStripMenuItem.Text = "Bán Sách";
            // 
            // menuItemBanSach
            // 
            this.menuItemBanSach.Name = "menuItemBanSach";
            this.menuItemBanSach.Size = new System.Drawing.Size(243, 26);
            this.menuItemBanSach.Text = "Bán Sách";
            this.menuItemBanSach.Click += new System.EventHandler(this.menuItemBanSach_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(240, 6);
            // 
            // menuItemTTHoaDon
            // 
            this.menuItemTTHoaDon.Name = "menuItemTTHoaDon";
            this.menuItemTTHoaDon.Size = new System.Drawing.Size(243, 26);
            this.menuItemTTHoaDon.Text = "Thông Tin Hóa Đơn";
            this.menuItemTTHoaDon.Click += new System.EventHandler(this.menuItemTTHoaDon_Click);
            // 
            // menuItemTTCTHoaDon
            // 
            this.menuItemTTCTHoaDon.Name = "menuItemTTCTHoaDon";
            this.menuItemTTCTHoaDon.Size = new System.Drawing.Size(243, 26);
            this.menuItemTTCTHoaDon.Text = "Thông Tin CT Hóa Đơn";
            this.menuItemTTCTHoaDon.Click += new System.EventHandler(this.menuItemTTCTHoaDon_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(16, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 633);
            this.panel1.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuHeader);
            this.MainMenuStrip = this.menuHeader;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chủ";
            this.menuHeader.ResumeLayout(false);
            this.menuHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuHeader;
        private System.Windows.Forms.ToolStripMenuItem tàiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemTTCaNhan;
        private System.Windows.Forms.ToolStripMenuItem menuItemDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem menuItemTTNhanVien;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemTTKhachHang;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuItemTTSach;
        private System.Windows.Forms.ToolStripMenuItem menuItemTTTacGia;
        private System.Windows.Forms.ToolStripMenuItem menuItemTTNXB;
        private System.Windows.Forms.ToolStripMenuItem menuItemTTTheLoai;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.ToolStripMenuItem menuItemDangXuat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem bánSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemBanSach;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemTTHoaDon;
        private System.Windows.Forms.ToolStripMenuItem menuItemTTCTHoaDon;
    }
}