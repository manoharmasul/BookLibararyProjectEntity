using LibararyProjectEntity.Model;

namespace LibararyProjectEntity.Repository.Interface
{
    public interface IBookIssueDetailsAsync
    {
        Task<string> IssueBook(BookIssueDetailsAdd issuedbook);
        Task<string> UpdateIssueBook(BookIssueDetailsAdd issuedbook);
        Task<List<BookIssueDetailsGet>> GetAllIssueBook();
        Task<List<BookIssueDetailsGet>> GetAllIssueBooksByUserId(long Id);
        Task<List<BookIssueDetailsGet>> GetAllReturnBooks();


    }
}
