using DI_Demo.Models;
using DI_Demo.Models.EF;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DI_Demo.Controllers
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
            ViewBag.time = DateTime.Now.ToShortTimeString();
            return View();
        }

        public IActionResult Privacy()
        {
            DeptInfo d = new DeptInfo();
            ViewBag.dept = d.GetDeptByLocation("Mumbai");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}