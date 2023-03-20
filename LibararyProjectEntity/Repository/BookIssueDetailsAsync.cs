using LibararyProjectEntity.Context;
using LibararyProjectEntity.Model;
using LibararyProjectEntity.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibararyProjectEntity.Repository
{
    public class BookIssueDetailsAsync:IBookIssueDetailsAsync
    {
        private readonly MyContext context;
        public BookIssueDetailsAsync(MyContext context)
        {
            this.context = context;
        }

        public async Task<List<BookIssueDetailsGet>> GetAllIssueBook()
        {
          

            var query = from books in context.BookIssueDetails
                        join user in context.User on books.IssueTo equals user.Id
                        join library in context.Library on books.BookId equals library.Id
                        where books.IsDeleted == false where books.ReturnDate==null
                        select new BookIssueDetailsGet
                        {
                            Id= books.Id,
                            BookName = library.BookName,
                            IssueTo = user.UserName,
                            IssueDate = books.IssueDate,
                            ReturnDate = books.ReturnDate,
                            CreatedBy = books.CreatedBy,

                        };
            var issueDetails=await query.ToListAsync();

            return issueDetails;

        }

        public async Task<List<BookIssueDetailsGet>> GetAllIssueBooksByUserId(long Id)
        {
            var query = from books in context.BookIssueDetails
                        join user in context.User on books.IssueTo equals user.Id
                        join library in context.Library on books.BookId equals library.Id
                        where books.IsDeleted == false &&  books.IssueTo==Id
                        select new BookIssueDetailsGet
                        {
                            Id = books.Id,
                            BookName = library.BookName,
                            IssueTo = user.UserName,
                            IssueDate = books.IssueDate,
                            ReturnDate = books.ReturnDate,
                            CreatedBy = books.CreatedBy,

                        };
            var result = await query.ToListAsync();
            return result;

        }

        public async Task<List<BookIssueDetailsGet>> GetAllReturnBooks()
        {

            var query = from books in context.BookIssueDetails
                        join user in context.User on books.IssueTo equals user.Id
                        join library in context.Library on books.BookId equals library.Id
                        where books.IsDeleted == false
                        where books.ReturnDate != null orderby books.Id descending
                        select new BookIssueDetailsGet
                        {
                            Id = books.Id,
                            BookName = library.BookName,
                            IssueTo = user.UserName,
                            IssueDate = books.IssueDate,
                            ReturnDate = books.ReturnDate,
                            CreatedBy = books.CreatedBy,

                        };
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<string> IssueBook(BookIssueDetailsAdd issuedbook)
        {
            BookIssueDetails bookissuedetails = new BookIssueDetails();

            bookissuedetails.BookId = issuedbook.BookId;
            bookissuedetails.IssueTo = issuedbook.IssueTo;
            bookissuedetails.IssueDate = issuedbook.IssueDate;
            bookissuedetails.CreatedBy = issuedbook.CreatedBy;
            bookissuedetails.CreatedDate = DateTime.Now;
            bookissuedetails.IsDeleted = false;
            bookissuedetails.ModifiedBy = 0;

            context.AddAsync(bookissuedetails);

            var result = await context.SaveChangesAsync();

            return "Book Issue Successfully";

            

        }

        public async Task<string> UpdateIssueBook(BookIssueDetailsAdd issuedbook)
        {
            var bookissuedetails = await context.BookIssueDetails.FindAsync(issuedbook.Id);

            bookissuedetails.ModifiedBy = issuedbook.CreatedBy;
            bookissuedetails.ModifiedDate = DateTime.Now;
            bookissuedetails.ReturnDate = DateTime.Now;
            context.BookIssueDetails.Update(bookissuedetails);

            var result= await context.SaveChangesAsync();

            return "Record Updated Successfully...!";


        }
    }
}
