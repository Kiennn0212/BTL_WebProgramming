using System.ComponentModel.DataAnnotations;

namespace BTL_WebProgramming.Models
{
    public class TranDau
    {
        [Key]
        public int MaTranDau { get; set; }
        public string DoiChuNha { get; set; }
        public string DoiKhach { get; set; }
        public DateTime NgayThiDau { get; set; }
        public int MaSVD { get; set; }
        public decimal GiaVe { get; set; }

        // Quan hệ n-1: Một trận đấu thuộc về một sân vận động
        public SanVanDong ?SanVanDong { get; set; }

        // Quan hệ 1-n: Một trận có nhiều vé
        public ICollection<Ve>? Ve { get; set; }

    }
}
