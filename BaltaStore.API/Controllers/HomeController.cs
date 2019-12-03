using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
          return "Hello World 222";
        }
    }
}
