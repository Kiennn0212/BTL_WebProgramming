using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BTL_WebProgramming.Controllers
{
    public class AuthController : Controller
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=TicketBall;Integrated Security=True;TrustServerCertificate=True";

        [HttpGet]
        public IActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangNhap(string email, string matkhau)
        {
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
                    HttpContext.Session.SetString("Email", reader["Email"].ToString());
                    HttpContext.Session.SetString("VaiTro", reader["VaiTro"].ToString());
                    HttpContext.Session.SetString("HoTen", reader["HoTen"].ToString());

                    if (reader["VaiTro"].ToString() == "QuanTri")
                        return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Sai tài khoản hoặc mật khẩu!";
                    return View();
                }
            }
        }

        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("DangNhap");
        }
    }
}
