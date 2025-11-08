using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BTL_WebProgramming.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHoaDonController : Controller
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=TicketBall;Integrated Security=True;TrustServerCertificate=True";

        public IActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"SELECT H.MaHoaDon, H.NgayLap, H.TongTien, N.HoTen AS TenNguoiDung
                               FROM HoaDon H 
                               JOIN NguoiDung N ON H.MaNguoiDung = N.MaNguoiDung";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return View(dt);
        }

        public IActionResult Xoa(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM HoaDon WHERE MaHoaDon=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
