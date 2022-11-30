using Microsoft.AspNetCore.Mvc;
using shoppingAPPMVC.Models;
namespace shoppingAPPMVC.Controllers
{
    public class shoppingController : Controller
    {
        public IActionResult About()
        {
            ViewBag.orgName = "IIHT Ltd.";
            ViewBag.teamSize = 20;
            ViewBag.projectOwner = "Nikhil Shah";
            ViewBag.isLive = false;
            ViewBag.projectCost = 20.5;

            return View();
        }

        public IActionResult Products()
        {

            //Wrong way of programming and only bad developers will do this
            // string[] categories = new string[10];
           // List<string> categories = new List<string>()
           //{
           //    "Cold-Drinks", "Shoes", "Electronics","Furniture","Accessories"
           //};
           // ViewBag.pCategories = categories;

            

            ProductsModel pObj = new ProductsModel(); //this is the worst code by develoeper, please use DI
            ViewBag.pCategories = pObj.GetCategories();
            ViewBag.plist = pObj.GetProductsModels();


            return View();
        }

        public IActionResult Customers()
        {
            return View();
        }
    }
}
