using BTL_WebProgramming.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace BTL_WebProgramming.Controllers
{
    public class HomeController : Controller
    {
        private readonly string connectionString =
          "Data Source=localhost;Initial Catalog=TicketBall;Integrated Security=True;TrustServerCertificate=True";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    //Trang chính
        public IActionResult Main()
        {
            return View();
        }
        public IActionResult DangNhap()
        {
            return View();
        }

        public IActionResult LichThiDau()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"SELECT MaTranDau, DoiChuNha, DoiKhach, NgayThiDau, MaSVD, GiaVe 
                               FROM TranDau
                               ORDER BY NgayThiDau ASC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }

            return View(dt);
        }
        public IActionResult MuaVe()
        {
            return View();
        }
        public IActionResult LienHe()
        {
            return View();
        }
    //Trang phụ
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
