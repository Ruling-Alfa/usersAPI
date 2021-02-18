using System.Collections.Generic;
using System.Threading.Tasks;
using UsersApi.ViewModel;

namespace UsersApi.Domain
{
    public interface IUserDomain
    {
        Task<User> AddUser(User user);
        Task DeleteUser(int id);
        Task<List<User>> GetAllUser();
        Task<User> GetUser(int id);
        Task<User> UpdateUser(User user);
    }
}