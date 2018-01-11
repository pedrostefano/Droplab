using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Droplab.Data.Models;
using Droplab.Data.Repositories.Interfaces;
using Droplab.VO.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Droplab.Data.Repositories
{
    public class UserRepository : Repository<User, UserVO>, IUserRepository
    {
        public UserRepository(DroplabDbContext context) : base(context)
        {
        }

        public override async Task<User> ToEntity(UserVO vo)
        {
            var entity  = await Get(vo.Id) ?? new User();
            entity.Id = entity != null && entity.Id > 0 ? entity.Id : vo.Id;
            entity.Name = vo.Name;
            entity.LastName = vo.LastName;
            entity.Username = vo.Username;
                        
            return entity;
        }

        public override UserVO ToVo(User entity)
        {
            var vo = new UserVO(){
                Id = entity.Id,
                Name = entity.Name,
                LastName = entity.LastName,
                Username = entity.Username
            };
            return vo;
        }

        public async Task<User> GetbyUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(entity => entity.Username.Equals(username));
        }

        public async Task<bool> CheckUsername(string username)
        {
            return await _context.Users.AnyAsync(entity => entity.Username.Equals(username));
        }
    }
}