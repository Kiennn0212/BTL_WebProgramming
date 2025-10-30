using System.ComponentModel.DataAnnotations;

namespace BTL_WebProgramming.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int MaCTHD { get; set; }
        public int MaHoaDon { get; set; }
        public int MaVe { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }

        // Quan hệ n-1
        public HoaDon HoaDon { get; set; }
        public Ve Ve { get; set; }

    }
}
