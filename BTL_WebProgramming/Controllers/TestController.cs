using Microsoft.AspNetCore.Mvc;
using BTL_WebProgramming.Models;
using BTL_WebProgramming.Data;

namespace BTL_WebProgramming.Controllers
{
    public class TestController : Controller
    {
        private readonly MyDBContext _context;

        public TestController(MyDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            bool canConnect = _context.Database.CanConnect();
            return Content(canConnect ? " Kết nối thành công!" : " Kết nối thất bại!");
        }
    }
}
