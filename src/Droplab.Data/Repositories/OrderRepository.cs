using System.Threading.Tasks;
using Droplab.Data.Models;
using Droplab.Data.Repositories.Interfaces;
using Droplab.VOs.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Droplab.Data.Repositories
{
    public class OrderRepository : Repository<Order, OrderVO>, IOrderRepository
    {
        public OrderRepository(DroplabDbContext context) : base(context)
        {
        }

        public override async Task<Order> ToEntity(OrderVO vo)
        {
            var entity  = await Get(vo.Id) ?? new Order();
            entity.Id = entity != null && entity.Id > 0 ? entity.Id : vo.Id;
            entity.Name = vo.Name;
            entity.StateId = vo.StateId;            
            return entity;
        }

        public override OrderVO ToVo(Order entity)
        {
            var vo = new OrderVO(){
                Id = entity.Id,
                Name = entity.Name,
                StateId = entity.StateId
            };
            return vo;
        }
    }
}