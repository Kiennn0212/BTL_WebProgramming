using System.ComponentModel.DataAnnotations;

namespace BTL_WebProgramming.Models
{
    public class Ve
    {
        [Key]
        public int MaVe { get; set; }
        public int MaTranDau { get; set; }
        public string SoGhe { get; set; }
        public string TrangThai { get; set; }

        // Quan hệ n-1: Vé thuộc về một trận đấu
        public TranDau? TranDau { get; set; }

        // Quan hệ 1-n: Một vé có thể xuất hiện trong nhiều chi tiết hóa đơn
        public ICollection<ChiTietHoaDon> ? ChiTietHoaDon { get; set; }
    }

}
