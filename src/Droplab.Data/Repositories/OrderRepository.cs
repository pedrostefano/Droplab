using Droplab.Data.Models;
using Droplab.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Droplab.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }
    }
}