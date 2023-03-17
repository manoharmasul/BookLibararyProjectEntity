using LibararyProjectEntity.Model;
using static LibararyProjectEntity.Model.BaseModel;

namespace LibararyProjectEntity.Repository.Interface
{
    public interface IUserRepository
    {
        Task<string> AddUser(AddUser addUser);
        Task<string> UpdateUser(AddUser addUser);
        Task<long> DeleteUser(DeleteObj deleteobj);
    }
}
