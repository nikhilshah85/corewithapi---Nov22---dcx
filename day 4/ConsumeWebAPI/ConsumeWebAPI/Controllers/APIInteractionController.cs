using Microsoft.AspNetCore.Mvc;
using ConsumeWebAPI.Models;
namespace ConsumeWebAPI.Controllers
{
    public class APIInteractionController : Controller
    {
        public IActionResult ShowPostdata()
        {
            return View();
        }

        public IActionResult ShowPhotos()
        {
            return View();
        }

        public IActionResult GetPostData()
        {
            PostModel pObj = new PostModel();
            ViewBag.post = pObj.GetPostData();
            return View();

        }
    }
}
