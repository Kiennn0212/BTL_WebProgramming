using Microsoft.AspNetCore.Mvc;

namespace BTL_WebProgramming.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("VaiTro");
            if (role != "QuanTri")
            {
                return RedirectToAction("DangNhap", "Auth", new { area = "" });
            }

            return View();
        }
    }
}
