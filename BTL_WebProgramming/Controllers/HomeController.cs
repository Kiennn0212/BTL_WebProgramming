using System.Diagnostics;
using BTL_WebProgramming.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTL_WebProgramming.Controllers
{
    public class HomeController : Controller
    {
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
            return View();
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
