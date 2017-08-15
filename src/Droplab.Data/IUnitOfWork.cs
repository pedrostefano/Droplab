using System.Threading.Tasks;
using Droplab.Data.Repositories.Interfaces;

namespace Droplab.Data
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }

		Task CompleteAsync();
      
    }
}