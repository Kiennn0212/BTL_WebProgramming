using Microsoft.EntityFrameworkCore;

namespace BTL_WebProgramming.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }
        public DbSet<NguoiDung> NguoiDung { get; set; }
        public DbSet<VaiTro> VaiTro { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public DbSet<Ve> Ve { get; set; }
        public DbSet<TranDau> TranDau { get; set; }
        public DbSet<SanVanDong> SanVanDong { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<NguoiDung>().ToTable(nameof(NguoiDung));

            modelBuilder.Entity<VaiTro>().ToTable(nameof(VaiTro));

            modelBuilder.Entity<HoaDon>().ToTable(nameof(HoaDon));
                
            modelBuilder.Entity<ChiTietHoaDon>().ToTable(nameof(ChiTietHoaDon));

            modelBuilder.Entity<Ve>().ToTable(nameof(Ve));

            modelBuilder.Entity<TranDau>().ToTable(nameof(TranDau));

            modelBuilder.Entity<SanVanDong>().ToTable(nameof(SanVanDong));

        }


    }
}
