using LibararyProjectEntity.Model;
using LibararyProjectEntity.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibararyProjectEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookIssueDetailsController : ControllerBase
    {
        private readonly IBookIssueDetailsAsync bookIssueDetailsAsync;
        public BookIssueDetailsController(IBookIssueDetailsAsync bookIssueDetailsAsync)
        {
            this.bookIssueDetailsAsync = bookIssueDetailsAsync;
        }
        [HttpPost("IssueBook")]
        public async Task<IActionResult> IssueBook(BookIssueDetailsAdd issueBook)
        {
            var result=await bookIssueDetailsAsync.IssueBook(issueBook);
            if (result != null)
            {
                return Ok(result);
            }
            return Ok("Something Is Wrong");
        }
        [HttpPut("ReturnBook")]
        public async Task<IActionResult> ReturnBook(BookIssueDetailsAdd issueBook)
        {
            var result = await bookIssueDetailsAsync.UpdateIssueBook(issueBook);
            if (result != null)
            {
                return Ok(result);
            }
            return Ok("Something Is Wrong");
        }
        [HttpGet("GetAllIssueBook")]
        public async Task<IActionResult> GetAllIssueBook()
        {
            var result = await bookIssueDetailsAsync.GetAllIssueBook();
            if (result != null)
            {
                return Ok(result);
            }
            return Ok("Something Is Wrong");
        }
        [HttpGet("GetAllIssueBooksByUserId")]
        public async Task<IActionResult> GetAllIssueBooksByUserId(long Id)
        {
            var result = await bookIssueDetailsAsync.GetAllIssueBooksByUserId(Id);
            if (result != null)
            {
                return Ok(result);
            }
            return Ok("Something Is Wrong");
        }
        [HttpGet("GetAllReturnBooks")]
        public async Task<IActionResult> GetAllReturnBooks()
        {
            var result = await bookIssueDetailsAsync.GetAllReturnBooks();
            if (result != null)
            {
                return Ok(result);
            }
            return Ok("Something Is Wrong");
        }
    }
}
