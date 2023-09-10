using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using webapi.Data.Models;
using webapi.Services.Intrefaces;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediasController:ControllerBase
    {
        private readonly IRepository<Media> _repository;
        public MediasController(IRepository<Media> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IEnumerable<Media>> GetMedias() => await _repository.GetAllAsync();
        //[HttpGet("id")]
        //public async Task<Media> GetMediaById(Guid id) => await _repository.GetAsync(id);
        [HttpPost]
        public async Task AddMedia(Media model) => await _repository.AddAsync(model);
        [HttpPatch]
        public async Task UpdateMedia(Media model) => await _repository.UpdateAsync(model);
        [HttpDelete("id")]
        public async Task DeleteMedia(Guid id) => await _repository.DeleteAsync(id);
        [HttpGet("travelId")]
        public async Task<List<Media>> GetUsersOnTravel(Guid TravelId)
        {
            var medias = await _repository.GetAllAsync();
            if (medias != null)
            {

                return medias.Where(m => m.TravelId == TravelId).ToList();
            }

            Results.NotFound(medias);
            return new List<Media>();
        }
    }
}

