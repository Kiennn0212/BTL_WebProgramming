using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BTL_WebProgramming.Controllers
{
    public class AuthController : Controller
    {
        // ✅ Chuỗi kết nối SQL Server
        private readonly string connectionString =
            "Data Source=localhost;Initial Catalog=TicketBall;Integrated Security=True;TrustServerCertificate=True";

        // -----------------------------
        // 🟢 HIỂN THỊ TRANG ĐĂNG NHẬP
        // -----------------------------
        [HttpGet]
        public IActionResult DangNhap()
        {
            return View();
        }

        // -----------------------------
        // 🟡 XỬ LÝ ĐĂNG NHẬP
        // -----------------------------
        [HttpPost]
        public IActionResult DangNhap(string email, string matkhau)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matkhau))
            {
                ViewBag.Error = "⚠️ Vui lòng nhập đầy đủ thông tin!";
                return View();
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM NguoiDung WHERE Email=@Email AND MatKhau=@MatKhau";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@MatKhau", matkhau);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Lưu thông tin người dùng vào Session
                    HttpContext.Session.SetString("Email", reader["Email"].ToString());
                    HttpContext.Session.SetString("VaiTro", reader["VaiTro"].ToString());
                    HttpContext.Session.SetString("HoTen", reader["HoTen"].ToString());

                    string vaiTro = reader["VaiTro"].ToString().Trim().ToLower();

                    // ✅ Phân quyền
                    if (vaiTro == "quantri")
                        return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
                    else
                        return RedirectToAction("Main", "Home");
                }
                else
                {
                    ViewBag.Error = "❌ Sai tài khoản hoặc mật khẩu!";
                    return View();
                }
            }
        }

        // -----------------------------
        // 🟣 HIỂN THỊ TRANG ĐĂNG KÝ
        // -----------------------------
        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }

        // -----------------------------
        // 🔵 XỬ LÝ ĐĂNG KÝ
        // -----------------------------
        [HttpPost]
        public IActionResult DangKy(string hoten, string email, string matkhau)
        {
            if (string.IsNullOrEmpty(hoten) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matkhau))
            {
                ViewBag.DangKyLoi = "⚠️ Vui lòng nhập đầy đủ thông tin!";
                return View("DangNhap");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kiểm tra email đã tồn tại chưa
                string checkSql = "SELECT COUNT(*) FROM NguoiDung WHERE Email = @Email";
                SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@Email", email);
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    ViewBag.DangKyLoi = "⚠️ Email này đã được sử dụng!";
                    return View("DangNhap");
                }

                // Thêm tài khoản mới (mặc định là KhachHang)
                string insertSql = @"INSERT INTO NguoiDung (HoTen, Email, MatKhau, VaiTro)
                                     VALUES (@HoTen, @Email, @MatKhau, N'KhachHang')";
                SqlCommand cmd = new SqlCommand(insertSql, conn);
                cmd.Parameters.AddWithValue("@HoTen", hoten);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@MatKhau", matkhau);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    ViewBag.DangKyThanhCong = "🎉 Đăng ký thành công! Vui lòng đăng nhập.";
                    return View("DangNhap");
                }
                else
                {
                    ViewBag.DangKyLoi = "❌ Đăng ký thất bại, vui lòng thử lại!";
                    return View("DangNhap");
                }
            }
        }

        // -----------------------------
        // 🔴 ĐĂNG XUẤT
        // -----------------------------
        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("DangNhap");
        }

        // -----------------------------
        // 🧩 TEST KẾT NỐI SQL (tuỳ chọn)
        // -----------------------------
        public IActionResult TestConnection()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return Content("✅ Kết nối SQL Server thành công!");
                }
                catch (Exception ex)
                {
                    return Content("❌ Lỗi kết nối: " + ex.Message);
                }
            }
        }
    }
}
