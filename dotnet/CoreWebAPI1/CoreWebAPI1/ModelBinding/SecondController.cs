using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace CoreWebAPI1.ModelBinding
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class SecondController : ControllerBase
    {         
        [HttpGet]
        [ApiVersion("2")]
        public IActionResult Method1([ModelBinder(BinderType = typeof(CustomBinder))] string name)
        {
            return Ok(name);
        }

    }
}
