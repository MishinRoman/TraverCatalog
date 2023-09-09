using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Data;

using webapi.Data.Models;
using webapi.Services.Intrefaces;

namespace webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IRepository<User> _repository;
    public UsersController(IRepository<User> repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<IEnumerable<User>> GetTraverls() => await _repository.GetAllAsync();
    [HttpGet("id")]
    public async Task<User> GetTraverlById(Guid id) => await _repository.GetAsync(id);
    [HttpPost("id")]
    public async Task AddTravel(User model) => await _repository.AddAsync(model);
    [HttpPatch("id")]
    public async Task UpdateTravel(User model) => await _repository.UpdateAsync(model);
    [HttpDelete("id")]
    public async Task DeleteTraver(Guid id) => await _repository.DeleteAsync(id);
   
   
}
