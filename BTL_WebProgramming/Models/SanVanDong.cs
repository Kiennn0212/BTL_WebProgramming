using System.ComponentModel.DataAnnotations;

namespace BTL_WebProgramming.Models
{
    public class SanVanDong
    {

        [Key]
        public int MaSVD { get; set; }
        public string TenSVD { get; set; }
        public string DiaChi { get; set; }
        public int SucChua { get; set; }

        // Quan hệ 1-n: Một sân vận động có nhiều trận đấu
        public ICollection<TranDau> TranDau { get; set; }

    }
}
