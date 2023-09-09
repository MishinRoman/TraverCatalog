using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using webapi.Data.Models;
using webapi.Services.Intrefaces;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly IRepository<TravelModel> _repository;
        public TravelsController(IRepository<TravelModel> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IEnumerable<TravelModel>> GetTraverls() => await _repository.GetAllAsync();
        [HttpGet("id")]
        public async Task<TravelModel> GetTraverlById(Guid id) => await _repository.GetAsync(id);
        [HttpPost]
        public async Task AddTravel(TravelModel model) => await _repository.AddAsync(model);
        [HttpPatch]
        public async Task UpdateTravel([FromBody] TravelModel model)=>await _repository.UpdateAsync(model);
        [HttpDelete("id")]
        public async Task DeleteTraver(Guid id) => await _repository.DeleteAsync(id);
    }
}
