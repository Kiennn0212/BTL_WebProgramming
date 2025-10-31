using System.ComponentModel.DataAnnotations;

namespace BTL_WebProgramming.Models
{

    public class HoaDon
    {
        [Key]
        public int MaHoaDon { get; set; }
        public int MaNguoiDung { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }

        // Quan hệ n-1: Hóa đơn thuộc về người dùng
        public NguoiDung NguoiDung { get; set; }

        // Quan hệ 1-n: Hóa đơn có nhiều chi tiết hóa đơn
        public ICollection<ChiTietHoaDon> ChiTietHoaDon { get; set; }
    }



}
