using System.Threading.Tasks;
using Droplab.Data;
using Droplab.Data.Models;
using Droplab.Data.Repositories.Interfaces;
using Droplab.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Droplab.Web.Controllers
{
    [Route("/api/order")]
    public class OrderController : BaseController <Order, OrderVO>
    {
        public OrderController(IRepository<Order> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> Get(long id)
        {
            var entity  = await _repository.Get(id);

            if (entity == null)
                return NotFound();

            var vo = new OrderVO(){
                Id = entity.Id,
                Name = entity.Name,
                StateId = entity.StateId
            };

            return Ok(vo);
        }    

        [HttpPost]
        public override async Task<IActionResult> CreateOrEdit([FromBody] OrderVO vo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity  = await _repository.Get(vo.Id) ?? new Order
            {
                Name = vo.Name,
                StateId = vo.StateId
            };

            if (entity.Id > 0){
                _repository.Update(entity);
            }else{
                _repository.Add(entity);
            }

            await _unitOfWork.CompleteAsync();

            entity = await _repository.Get(entity.Id);

            vo = new OrderVO(){
                Id = entity.Id,
                Name = entity.Name,
                StateId = entity.StateId
            };

            return Ok(vo);
        }

        [HttpGet]        
        public override async Task<IActionResult> GetAll(int offset, int limit)
        {
            var entities  = await _repository.GetAll(offset, limit);
            return Ok(entities);
        }

        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(long id)
        {
            var entity  = await _repository.Get(id);

            if (entity == null)
                return NotFound();

            _repository.Remove(entity);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }    
    }
}