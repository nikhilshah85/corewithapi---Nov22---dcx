using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using shoppingMVC_EF_SQL.Models.EF;
using System.Threading.Channels;

namespace shoppingMVC_EF_SQL.Controllers
{
    public class ProductsController : Controller
    {

        shoppingDBContext _db = new shoppingDBContext(); //we use DI instead


        public IActionResult ProductList()
        {
            ViewBag.pList = _db.ProductDetails.ToList();
            return View();
        }

        public IActionResult AddNewproduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewproduct(ProductDetail newp)
        {
            _db.ProductDetails.Add(newp);
            _db.SaveChanges();
           return RedirectToAction("ProductList");
        }

        public IActionResult EditProduct(int id)
        {
            var p = (from pr in _db.ProductDetails
                     where pr.PId == id
                     select pr).Single();
            ViewBag.productToEdit = p;
            return View();
        }

        [HttpPost]
        public IActionResult EditProduct(ProductDetail changes)
        {
            var p = (from pr in _db.ProductDetails
                     where pr.PId == changes.PId
                     select pr).Single();

            p.PName = changes.PName;
            p.PPrice = changes.PPrice;
            p.PCategory = changes.PCategory;
            p.PIsInStock = changes.PIsInStock;
            _db.SaveChanges();
            return RedirectToAction("ProductList");
        }


        public IActionResult DeleteProduct(int pid)
        {
            var p = (from pr in _db.ProductDetails
                     where pr.PId == pid
                     select pr).Single();
            ViewBag.productToDelete = p;
            return View();
        }
        [HttpPost]
        public IActionResult DeleteProduct(int id,string pName)
        {
            var p = (from pr in _db.ProductDetails
                     where pr.PId ==id
                     select pr).Single();

            _db.ProductDetails.Remove(p);
            _db.SaveChanges();
            return RedirectToAction("ProductList");

        }


    }
}
