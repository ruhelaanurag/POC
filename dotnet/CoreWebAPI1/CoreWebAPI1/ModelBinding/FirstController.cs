using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAPI1.ModelBinding
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        [BindProperty(SupportsGet =true)]
        public string name { get; set; }
        [HttpGet]
        public IActionResult Method1()
        {
            return Ok(name);
        }

        [HttpGet]
        [Route("query")]
        public IActionResult Method2([FromQuery]string some) //try passing this data from querystring and header, it will pick value from only querystring.
        {
            return Ok(some);
        }

        [HttpGet]
        [Route("head")]
        public IActionResult Method3([FromHeader] string some)//Gets data from header.
        {
            return Ok(some);
        }

        [HttpPost]
        [Route("frmbdy")]
        public IActionResult Method4([FromBody]string some) 
        { return Ok(some); }

        [HttpPost]
        [Route("frmfrm")]
        public IActionResult Method5([FromForm] string some)  //Get the data from the from-data and also from x-urlencoded data.
        {
            return Ok(some);
        }
    }
}
