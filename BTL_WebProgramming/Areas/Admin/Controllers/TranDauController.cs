using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BTL_WebProgramming.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TranDauController : Controller
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=TicketBall;Integrated Security=True;TrustServerCertificate=True";

        // 📋 Danh sách trận đấu
        public IActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT TD.MaTranDau, TD.DoiChuNha, TD.DoiKhach, TD.NgayThiDau, TD.MaSVD, TD.GiaVe " +
             "FROM dbo.TranDau TD";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return View(dt);
        }

        // ➕ Hiển thị form thêm mới
        [HttpGet]
        public IActionResult Them()
        {
            return View();
        }

        // 💾 Lưu dữ liệu thêm mới
        [HttpPost]
        public IActionResult Them(string DoiChuNha, string DoiKhach, DateTime NgayThiDau, int MaSVD, decimal GiaVe)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO TranDau (DoiChuNha, DoiKhach, NgayThiDau, MaSVD, GiaVe) VALUES (@a,@b,@c,@d,@e)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@a", DoiChuNha);
                cmd.Parameters.AddWithValue("@b", DoiKhach);
                cmd.Parameters.AddWithValue("@c", NgayThiDau);
                cmd.Parameters.AddWithValue("@d", MaSVD);
                cmd.Parameters.AddWithValue("@e", GiaVe);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // 🗑 Xóa trận đấu
        public IActionResult Xoa(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM TranDau WHERE MaTranDau=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
