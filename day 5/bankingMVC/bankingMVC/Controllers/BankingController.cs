using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bankingMVC.Controllers
{

    [Authorize]
    public class BankingController : Controller
    {

        [AllowAnonymous]
        public IActionResult BankHome()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Services()
        {
            return View();
        }

        public IActionResult TransferMoney()
        {
            return View();
        }

        public IActionResult DownloadStatement()
        {
            return View();
        }
    }
}
