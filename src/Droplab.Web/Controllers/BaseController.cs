using System.Threading.Tasks;
using Droplab.Data;
using Droplab.Data.Repositories.Interfaces;
using Droplab.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Droplab.Web.Controllers
{
    public abstract class BaseController<TEntity, VO> : Controller 
    where TEntity : class 
    where VO : class 
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseController(IRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

        public abstract Task<IActionResult> Get(long id);
        public abstract Task<IActionResult> GetAll(int offset, int limit);
        public abstract Task<IActionResult> Delete(long id);
        public abstract Task<IActionResult> CreateOrEdit([FromBody] VO vo);

    }
}