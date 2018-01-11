using System.Threading.Tasks;
using Droplab.Data.Models;
using Droplab.VO.ViewModels;

namespace Droplab.Web.Interfaces
{
    public interface IAuthenticationService
    {
        Task<User> Authenticate(string username, string password);
        Task<User> CreateUser(User user, string password);
        
    }
}