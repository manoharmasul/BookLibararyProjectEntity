using LibararyProjectEntity.Model;

namespace LibararyProjectEntity.Repository.Interface
{
    public interface ILibraryAsyncRepository
    {
        Task<long> AddNewBook(LibraryAdd libraryAdd);
        Task<long> UpdateBook(LibraryAdd libraryAdd);
        Task<List<LibraryGet>> GetAllBooks();
        Task<List<LibraryGet>> SearchBook(string searchtext);
        Task<List<LibraryGet>>  SearchBooksFilter(string? searchtext);
    }
}
