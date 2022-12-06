using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC_CORS.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult DisplayEmployee()
        {
            return View();
        }
    }
}
