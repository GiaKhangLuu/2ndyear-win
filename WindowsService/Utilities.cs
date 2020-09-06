
using CuaHangBanSach.DAO;
using CuaHangBanSach.DTO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsService
{
    public class Utilities
    {

        private static DataTable GetSachNearlyOutOfStock()
        {
            string query = "select masach, tensach, soluong from sach where soluong <= 20";// tim sach co so luong thap hon 20 cuon
            DataTable rs = DataProvider.ExecuteQuery(query);
            if (rs.Rows.Count > 0)
                return rs;
            return null;
        } 

        private static DataTable GetSummaryInvoiceInYesterday()
        {
            string dt = DateTime.Now.Date.ToString("dd/MM/yyyy");
            string query = "set dateformat dmy SELECT s.MaSach, s.TenSach, cthd.SoLuong, cthd.Gia, hd.NgayBan, hd.MaHoaDon " +
                            "from sach s, ChiTietHoaDon cthd, HoaDon hd " +
                            $"WHERE s.MaSach = cthd.MaSach and cthd.MaHoaDon = hd.MaHoaDon and DATEDIFF(DAY, NgayBan, '{ dt }') = 1;";
            DataTable rs = DataProvider.ExecuteQuery(query);
            if (rs == null)
                return null;
            if (rs.Rows.Count > 0)
                return rs;
            return null;
        }

        //Send mail voi ten tk nguoi gui la luugiakhangggg@gmail.com
        public static void SendMail()
        {
            DataTable cusGroup = NhanVienDAO.GetCustomerTodayIsBirthday();
            if(cusGroup != null)
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("luugiakhangggg@gmail.com", "CuaHangBanSach");
                mail.Subject = "Chúc Mừng Sinh Nhật";
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("luugiakhangggg@gmail.com", "946GiaKhang");
                foreach(DataRow record in cusGroup.Rows)
                {
                    string tenKH = record["Ten"].ToString();
                    string email = record["email"].ToString();
                    if(email != "")
                    {
                        mail.To.Add(email);
                        mail.Body = $"Chúc mừng sinh nhật khách hàng { tenKH }. Cám ơn bạn đã mua sách tại cửa hàng chúng tôi. Chúc bạn có một ngày sinh nhật thật ý nghĩa";
                        client.Send(mail);
                        mail.To.Clear();
                    }
                    
                }
            }
        }

        //Viet file notepad xuat ra man hinh desktop
        public static void WriteText()
        {
            DataTable sachGroup = GetSachNearlyOutOfStock();
            using(StreamWriter writer = new StreamWriter("C:\\Users\\HUYEN\\Desktop\\ThongBaoSachSapHetHang.txt"))
            {
                StringBuilder sb = new StringBuilder();
                if(sachGroup != null)
                {
                    foreach(DataRow record in sachGroup.Rows)
                    {
                        string maSach = record["masach"].ToString();
                        string tenSach = record["tenSach"].ToString();
                        string soLuong = record["soluong"].ToString();
                        string line = $"{ maSach } { tenSach } chỉ còn { soLuong } cuốn ";
                        sb.AppendLine(line);
                    }
                }
                else
                {
                    sb.AppendLine("Không có sách nào sắp hết hàng");
                }
                writer.WriteLine(sb);
                writer.Flush();
                writer.Close();
            }
        }

        //Viet file excel xuat ra man hinh desktop
        public static void WriteReport()
        {
            DataTable invoiceGroup = GetSummaryInvoiceInYesterday();
            //Ghi file excel
            DateTime dt = DateTime.Now;
            //lay ngay hom qua
            dt = dt.AddDays(-1).Date;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage excel = new ExcelPackage(new FileInfo("C:\\Users\\HUYEN\\Desktop\\DanhSachSanPhamDaBanTrongNgay.xlsx")))
            {
                //Tao WorkSheet
                ExcelWorksheet workSheet = null;
                if(excel.Workbook.Worksheets.Count == 0)
                {
                    workSheet = excel.Workbook.Worksheets.Add("Sheet 1");
                }
                else
                {
                    workSheet = excel.Workbook.Worksheets[0];
                }
                workSheet.Cells.Clear();
                //Tao Title
                ExcelRange titleCell = workSheet.Cells[1, 1, 1, 6];
                titleCell.Merge = true;
                titleCell.Value = $"Danh sách các sản phẩm bán trong ngày { dt.ToString("dd/MM/yyyy") }";
                //Dinh dang cho title
                titleCell.Style.Font.Bold = true;
                titleCell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                titleCell.Style.Font.Size = 14;
                titleCell.Style.Font.Color.SetColor(Color.Red);
                workSheet.Row(1).Height = 30;
                //Tao header
                workSheet.Cells[2, 1].Value = "Mã sách";
                workSheet.Cells[2, 2].Value = "Tên sách";
                workSheet.Cells[2, 3].Value = "Số lượng";
                workSheet.Cells[2, 4].Value = "Giá";
                workSheet.Cells[2, 5].Value = "Ngày bán";
                workSheet.Cells[2, 6].Value = "Mã hóa đơn";
                //Dinh dang cho header
                foreach (ExcelRangeBase range in workSheet.Cells["A2:F2"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Border.BorderAround(ExcelBorderStyle.Thick);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.AutoFitColumns();
                }
                //do du lieu vao file excel
                if (invoiceGroup != null)
                {
                    int row = 3;
                    //Tao chieu rong cho cac cot ten, soluong, gia, ngayban
                    workSheet.Column(2).Width = 22;
                    workSheet.Column(3).Width = 11;
                    workSheet.Column(4).Width = 15;
                    workSheet.Column(5).Width = 22;
                    double total = 0;
                    foreach (DataRow record in invoiceGroup.Rows)
                    {
                        int col = 1;
                        int soLuong = Convert.ToInt32(record["SoLuong"]);
                        double gia = Convert.ToDouble(record["Gia"]);
                        double temp = gia * soLuong;
                        workSheet.Cells[row, col].Value = record["MaSach"].ToString();
                        workSheet.Cells[row, ++col].Value = record["TenSach"].ToString();
                        workSheet.Cells[row, ++col].Value = soLuong;
                        workSheet.Cells[row, ++col].Value = gia;
                        workSheet.Cells[row, ++col].Value = record["NgayBan"].ToString();
                        workSheet.Cells[row, ++col].Value = record["MaHoaDon"].ToString();
                        total += temp;
                        row++;
                    }
                    int rowThanhTien = invoiceGroup.Rows.Count + 2 + 1;
                    workSheet.Cells[rowThanhTien, 3].Value = "Thành tiền";
                    workSheet.Cells[rowThanhTien, 4].Value = total;
                    workSheet.Cells[rowThanhTien, 4].Style.Font.Bold = true;
                    //dinh dang tien VND
                    workSheet.Cells[3, 4, rowThanhTien, 4].Style.Numberformat.Format = "#,##0 \"VND\" ";
                }
                else
                {
                    workSheet.Cells[2, 1].Value = $"Không sản phẩm nào được bán vào ngày { dt }";
                }
                excel.Save();
            }
        }
    }
}
