using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiInMemoryDB.Entity;
using WebApiInMemoryDB.Repository;

namespace WebApiInMemoryDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        [HttpGet]
        public ActionResult<List<Author>> Get()
        {
            return Ok(_authorRepository.GetAuthors());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            var id = _authorRepository.AddAuthor(author);
            return Ok(id);
        }
    }
}
