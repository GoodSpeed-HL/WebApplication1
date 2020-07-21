using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetList();
        Task<User> GetOne(int id);
        Task<User> UpdateOne(User user);
        Task<User> CreateOne(User user);
        Task<User> DeleteOne(int id);
    }
}
