using System.ComponentModel.DataAnnotations;

namespace BTL_WebProgramming.Models
{

    public class NguoiDung
    {
        [Key]
        public int MaNguoiDung { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public int MaVaiTro { get; set; }

        // Quan hệ n-1
        public VaiTro? VaiTro { get; set; }

        // Quan hệ 1-n
        public ICollection<HoaDon> ? HoaDon { get; set; }
    }



}
