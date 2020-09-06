using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach.DTO
{
    public class NhanVien
    {
        private int maNV;
        private string tenNV, sdt, email, diaChi;
        private DateTime ngaySinh, ngayVaoLam;
        private int gioiTinh, quyenHan;
        private string tenTK, matKhau;

        public int MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public DateTime NgayVaoLam { get => ngayVaoLam; set => ngayVaoLam = value; }
        public int GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public int QuyenHan { get => quyenHan; set => quyenHan = value; }
        public string TenTK { get => tenTK; set => tenTK = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }

        public NhanVien(int maNV, string tenNV, string sdt, string email, string diaChi, 
            DateTime ngaySinh, DateTime ngayVaoLam, int gioiTinh, int quyenHan, string tenTK, string matKhau)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.sdt = sdt;
            this.email = email;
            this.diaChi = diaChi;
            this.ngaySinh = ngaySinh;
            this.ngayVaoLam = ngayVaoLam;
            this.gioiTinh = gioiTinh;
            this.quyenHan = quyenHan;
            this.tenTK = tenTK;
            this.matKhau = matKhau;
        }

        public NhanVien(DataRow row)
        {
            this.maNV = Convert.ToInt32(row["MaNhanVien"]);
            this.tenNV = row["TenNhanVien"].ToString();
            this.sdt = row["SDT"].ToString();
            this.email = row["Email"].ToString();
            this.diaChi = row["DiaChi"].ToString();
            this.gioiTinh = Convert.ToInt32((row["GioiTinh"]));
            this.ngaySinh = ((DateTime) row["NgaySinh"]).Date;
            this.ngayVaoLam = ((DateTime)row["NgayVaoLam"]).Date;
            this.quyenHan = Convert.ToInt32((row["QuyenHan"]));
            this.tenTK = row["TenTaiKhoan"].ToString();
            this.matKhau = row["MatKhau"].ToString();
        }

        public object[] ItemArray()
        {
            return new object[] { MaNV, TenNV, Sdt, Email, DiaChi, GioiTinh, NgaySinh, NgayVaoLam, QuyenHan, TenTK };
        }
    }
}
