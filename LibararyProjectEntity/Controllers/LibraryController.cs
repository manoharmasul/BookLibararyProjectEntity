using LibararyProjectEntity.Model;
using LibararyProjectEntity.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibararyProjectEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryAsyncRepository libraryasync;
        public LibraryController(ILibraryAsyncRepository libraryasync)
        {
            this.libraryasync = libraryasync;
        }   
        [HttpPost("AddNewBook")]
        public async Task<IActionResult> AddNewBook(LibraryAdd libraryAdd)
        {
            var result=await libraryasync.AddNewBook(libraryAdd);
            return Ok(result);
        }
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var result=await libraryasync.GetAllBooks();
            return Ok(result);
        }
        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook(LibraryAdd libraryAdd)
        {
            var result = await libraryasync.UpdateBook(libraryAdd);
            return Ok(result);
        }
        [HttpGet("SearchBook")]
        public async Task<IActionResult> SearchBooks(string searchtext)
        {
            var result = await libraryasync.SearchBook(searchtext);
            return Ok(result);
        }
        [HttpGet("SearchBooksFilter")]
        public async Task<IActionResult> SearchBooksFilter(string? searchtext)
        {
            var result = await libraryasync.SearchBooksFilter(searchtext);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long Id)
        {
            var result = await libraryasync.GetBooksById(Id);
            return Ok(result);
        }
    }
}
