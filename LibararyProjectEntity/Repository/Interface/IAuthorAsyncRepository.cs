using LibararyProjectEntity.Model;

namespace LibararyProjectEntity.Repository.Interface
{
    public interface IAuthorAsyncRepository
    {
        Task<long> AddNewAurhor(AuthorAdd author);
        Task<long> UpdateAuthor(AuthorAdd author);
        Task<List<AuthorGet>> GetAllAuthor();
    }
}
