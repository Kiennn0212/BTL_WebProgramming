using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BTL_WebProgramming.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminNguoiDungController : Controller
    {
        private readonly string connectionString =
            "Data Source=localhost;Initial Catalog=TicketBall;Integrated Security=True;TrustServerCertificate=True";

        // 🔹 Danh sách người dùng
        public IActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM NguoiDung ORDER BY MaNguoiDung DESC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return View(dt);
        }

        // 🔹 Xem chi tiết người dùng
        public IActionResult ChiTiet(int id)
        {
            DataRow user;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM NguoiDung WHERE MaNguoiDung = @id";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                    return NotFound();
                user = dt.Rows[0];
            }
            return View(user);
        }

        // 🔹 Hiển thị form thêm
        [HttpGet]
        public IActionResult Them()
        {
            return View();
        }

        // 🔹 Xử lý thêm mới
        [HttpPost]
        public IActionResult Them(string hoten, string email, string matkhau, string vaitro)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO NguoiDung (HoTen, Email, MatKhau, VaiTro)
                               VALUES (@HoTen, @Email, @MatKhau, @VaiTro)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@HoTen", hoten);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@MatKhau", matkhau);
                cmd.Parameters.AddWithValue("@VaiTro", vaitro);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // 🔹 Hiển thị form sửa
        [HttpGet]
        public IActionResult Sua(int id)
        {
            DataRow user;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM NguoiDung WHERE MaNguoiDung = @id";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                    return NotFound();
                user = dt.Rows[0];
            }
            return View(user);
        }

        // 🔹 Xử lý sửa
        [HttpPost]
        public IActionResult Sua(int id, string hoten, string email, string matkhau, string vaitro)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE NguoiDung 
                               SET HoTen=@HoTen, Email=@Email, MatKhau=@MatKhau, VaiTro=@VaiTro
                               WHERE MaNguoiDung=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@HoTen", hoten);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@MatKhau", matkhau);
                cmd.Parameters.AddWithValue("@VaiTro", vaitro);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // 🔹 Xóa người dùng
        public IActionResult Xoa(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM NguoiDung WHERE MaNguoiDung=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
