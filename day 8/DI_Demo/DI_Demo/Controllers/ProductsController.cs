using Microsoft.AspNetCore.Mvc;
using DI_Demo.Models;
namespace DI_Demo.Controllers
{
    public class ProductsController : Controller
    {

        // Products pObj = new Products(); 
        //this is a heavy obj, you should write core to destroy it

        Products _pObj; //let framework create that object and inject it here

        public ProductsController(Products pObjREF)
        {
            _pObj= pObjREF;
        }

        
        public IActionResult ShowProducts()
        {
            return View(_pObj.GetAllProducts());
        }
    }
}
