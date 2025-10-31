using System.ComponentModel.DataAnnotations;

namespace BTL_WebProgramming.Models
{

    public class VaiTro
    {
        [Key]
        public int MaVaiTro { get; set; }
        public string TenVaiTro { get; set; }

        // 1 vai trò có nhiều người dùng
        public ICollection<NguoiDung> ? NguoiDung { get; set; }
    }


}
