using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.ViewModel;

namespace UsersApi.Persistance
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;
        private int _primaryKey = -1;
        public UserRepository()
        {
            var initDataStr = File.ReadAllTextAsync("init_data.json").GetAwaiter().GetResult();
            _users = JsonConvert.DeserializeObject<List<User>>(initDataStr);
            _users.ForEach(x => x.CreatedDate = DateTime.UtcNow);
            _primaryKey = _users.Max(x => x.Id) + 1;
        }


        public Task<List<User>> GetAllUser()
        {
            return Task.FromResult(_users);
        }

        public Task<User> GetUser(int id)
        {
            User user = _users.Where(x => x.Id == id).FirstOrDefault();
            return Task.FromResult(user);
        }

        public Task<User> AddUser(User user)
        {
            user.Id = _primaryKey++;
            user.CreatedDate = DateTime.UtcNow;
            _users.Add(user);
            return Task.FromResult(user);
        }

        public async Task<User> UpdateUser(User user)
        {
            var existingUser = await this.GetUser(user.Id);
            if (existingUser != null)
            {
                existingUser.Avatar = user.Avatar;
                existingUser.First_name = user.First_name;
                existingUser.Last_name = user.Last_name;
                existingUser.Email = user.Email;
                existingUser.UpdatedDate = DateTime.UtcNow;
            }
            return user;
        }

        public async Task DeleteUser(int id)
        {
            var existingUser = await this.GetUser(id);
            if (existingUser != null)
            {
                _users.Remove(existingUser);
            }
        }
    }
}
