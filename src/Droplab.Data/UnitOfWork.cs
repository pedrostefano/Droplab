using System.Threading.Tasks;
using Droplab.Data.Repositories;
using Droplab.Data.Repositories.Interfaces;

namespace Droplab.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DroplabDbContext _context { get; }
        public UnitOfWork(DroplabDbContext context)
        {
            _context = context;
        }

        public Task CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}