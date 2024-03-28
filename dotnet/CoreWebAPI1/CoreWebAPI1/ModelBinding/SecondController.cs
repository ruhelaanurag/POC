using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAPI1.ModelBinding
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecondController : ControllerBase
    {         
        [HttpGet]
        public IActionResult Method1([ModelBinder(BinderType = typeof(CustomBinder))] string name)
        {
            return Ok(name);
        }

    }
}
