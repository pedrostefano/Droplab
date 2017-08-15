using System.Threading.Tasks;
using Droplab.Data.Repositories;
using Droplab.Data.Repositories.Interfaces;

namespace Droplab.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DroplabDbContext _context { get; }
        IOrderRepository _orders;

        public UnitOfWork(DroplabDbContext context)
        {
            _context = context;
        }
        public IOrderRepository Orders
        {
            get
            {
                if (_orders == null)
                    _orders = new OrderRepository(_context);

                return _orders;
            }
        }

        public Task CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}