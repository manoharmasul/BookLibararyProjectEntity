using LibararyProjectEntity.Context;
using LibararyProjectEntity.Model;
using LibararyProjectEntity.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibararyProjectEntity.Repository
{
    public class LibraryAsyncRepository : ILibraryAsyncRepository
    {
        private readonly MyContext context;
        public LibraryAsyncRepository(MyContext context)
        {
            this.context = context;
        }

        public async Task<long> AddNewBook(LibraryAdd libraryAdd)
        {
            Library library = new Library();
            library.BookName = libraryAdd.BookName;
            library.AuthorId = libraryAdd.AuthorId;
            library.CategoryId = libraryAdd.CategoryId;
            library.LanguageId = libraryAdd.LanguageId;
            library.CreatedBy = libraryAdd.CreatedBy;
            library.ModifiedBy = 0;
            var query = context.AddAsync(library);
            var result = await context.SaveChangesAsync();
            return result;
        }

        public async Task<List<LibraryGet>> GetAllBooks()
        {
            var query = from books in context.Library
                        join auth in context.Authorcc on books.AuthorId equals auth.Id
                        join lang in context.LanguageModels on books.LanguageId equals lang.Id
                        join cate in context.tblCategory on books.CategoryId equals cate.Id
                        where books.IsDeleted == false

                        select new LibraryGet
                        {
                            Id = books.Id,
                            BookName = books.BookName,
                            AuthorName = auth.AuthorName,
                            Category = cate.Category,
                            Language = lang.Language
                        };
            var booklist = await query.ToListAsync();
            return booklist;
        }

        public async Task<List<LibraryGet>> SearchBook(string searchtext)
        {
            var query = from books in context.Library
                        join auth in context.Authorcc on books.AuthorId equals auth.Id
                        join lang in context.LanguageModels on books.LanguageId equals lang.Id
                        join cate in context.tblCategory on books.CategoryId equals cate.Id
                        where books.IsDeleted == false && books.BookName==searchtext ||  auth.AuthorName==searchtext
                        || lang.Language==searchtext || cate.Category==searchtext

                        select new LibraryGet
                        {
                            Id = books.Id,
                            BookName = books.BookName,
                            AuthorName = auth.AuthorName,
                            Category = cate.Category,
                            Language = lang.Language
                        };
            var booklist = await query.ToListAsync();
            return booklist;
        }

        public async Task<List<LibraryGet>> SearchBooksFilter(string? searchtext)
        {
            if (searchtext == null)
            {
                searchtext = "";
            }
            var query = from books in context.Library
                        join auth in context.Authorcc on books.AuthorId equals auth.Id
                        join lang in context.LanguageModels on books.LanguageId equals lang.Id
                        join cate in context.tblCategory on books.CategoryId equals cate.Id
                        where books.IsDeleted == false && books.BookName.Contains(searchtext) || auth.AuthorName.Contains(searchtext)
                        || lang.Language.Contains(searchtext) || cate.Category.Contains(searchtext)

                        select new LibraryGet
                        {
                            Id = books.Id,
                            BookName = books.BookName,
                            AuthorName = auth.AuthorName,
                            Category = cate.Category,
                            Language = lang.Language
                        };
                        var booklist = await query.ToListAsync();
                        return booklist;
        }

        public async Task<long> UpdateBook(LibraryAdd libraryAdd)
        {
            var book=await context.Library.FindAsync(libraryAdd.Id);

            book.BookName = libraryAdd.BookName;
            book.ModifiedBy = libraryAdd.CreatedBy;
            book.AuthorId=libraryAdd.AuthorId;
            book.CategoryId = libraryAdd.CategoryId;
            book.LanguageId=libraryAdd.LanguageId;
            book.ModifiedDate = DateTime.Now;

            var query= context.Update(book);
            var result = await context.SaveChangesAsync();
            return result;  
        }
    }
}
