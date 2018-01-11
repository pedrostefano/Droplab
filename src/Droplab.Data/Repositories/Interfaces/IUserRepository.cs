using System.Collections.Generic;
using System.Threading.Tasks;
using Droplab.Data.Models;
using Droplab.VO.ViewModels;

namespace Droplab.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User, UserVO>
    {
        Task<User> GetbyUsername(string username);
        Task<bool> CheckUsername(string username);
    }
}