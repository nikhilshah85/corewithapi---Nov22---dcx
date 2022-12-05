using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace firstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {


        [HttpGet]
        [Route("greetings")]
        public IActionResult Greet()
        {
            //collect data from Model
            //return HttpStatus Code with data, exceptions, (information)
            return Ok("Hello and Welcome to WebAPI Development");
        }

        [HttpGet]
        [Route("greet/{guestName}")]
        public IActionResult Greet(string guestName)
        {
            return Ok("Hello and Welcome " + guestName);
        }

        [HttpGet]
        [Route("addition/{num1}/{num2}")]
        public IActionResult AddNumbers(int num1, int num2)
        {

            if (num1 == 0 || num2 == 0)
            {
                return BadRequest("Please enter only positive values");
            }
            return Ok((num1 + num2));
        }
    }
}



