using LibararyProjectEntity.Model;
using LibararyProjectEntity.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibararyProjectEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorAsyncRepository authorasync;
        public AuthorController(IAuthorAsyncRepository authorasync)
        {
            this.authorasync = authorasync;
        }
        [HttpPost("AddNewAuthor")]
        public async Task<IActionResult> AddNewAuthor(AuthorAdd authoradd)
        {
            var result = await authorasync.AddNewAurhor(authoradd);
            return Ok(result);

        }
        [HttpPut("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor(AuthorAdd aut)
        {
            var result=await authorasync.UpdateAuthor(aut);
            return Ok(result);
        }
        [HttpGet("GetAllAuthor")]
        public async Task<IActionResult> GetAllAuthor()
        {
            var result = await authorasync.GetAllAuthor();
            return Ok(result);
        }
    }
}
