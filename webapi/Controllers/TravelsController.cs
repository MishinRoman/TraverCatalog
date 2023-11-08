using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

using webapi.Data.Models;
using webapi.Services.Intrefaces;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TravelsController : ControllerBase
    {
        private readonly IRepository<Media> _mediaRepository;
        private readonly IRepository<TravelModel> _repository;
        public TravelsController(IRepository<TravelModel> repository, IRepository<Media> mediaRepository)
        {
            _repository = repository;
            _mediaRepository = mediaRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<TravelModel>> GetTraverls([FromQuery] int page)
        {
            var travels = await _repository.GetAllAsync();
            var medias = await _mediaRepository.GetAllAsync();

            foreach (var travel in travels)
            {
                travel.Media = medias.Where(m => m.TravelId == travel.Id).ToList();
            }

            int pageSize = 2;
            int skypedSize = ((int)page * pageSize) - pageSize;
            var result = travels.Skip(skypedSize).Take((int)page * pageSize);


            return result;

        }
        [HttpGet]
        [Route("/count")]
        public async Task<int> GetCount()
        {
            var result = await _repository.GetAllAsync();
            return result.Count();
        }

        [HttpPost]
        public async Task AddTravel(TravelModel model)
        {
            model.StartDate = model.StartDate.ToUniversalTime();
            model.EndDate = model.EndDate.ToUniversalTime();
            await _repository.AddAsync(model);
        }

        [HttpPatch]
        public async Task UpdateTravel([FromBody] TravelModel model) => await _repository.UpdateAsync(model);
        [HttpDelete("id")]
        public async Task DeleteTraver(Guid id) => await _repository.DeleteAsync(id);

        [HttpGet("id")]
        public async Task<TravelModel> GetById(Guid id)
        {

            var media = await _mediaRepository.GetAllAsync();
            var medias = media.Where(media => media.TravelId == id).ToList();
            var model = await _repository.GetAsync(id);
            model.Media = medias;
            return model;

        }
    }
}
