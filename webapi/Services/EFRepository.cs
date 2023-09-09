using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

using webapi.Data.Models;
using webapi.Services.Intrefaces;

namespace webapi.Services
{
    public class EFRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly DbContext _context;

        public EFRepository(DbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(i => i.Id == id);
            if (entity != null)
            {
                 _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();

            }

        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();


        public async Task<T?> GetAsync(Guid id) => await _context.Set<T>().FirstOrDefaultAsync(i => i.Id == id);
        

        public async Task UpdateAsync(T entity)
        {
            var oldModel = await _context.Set<T>().FirstOrDefaultAsync(i=>i.Id== entity.Id);
            if(oldModel != null)
            {
                oldModel = entity;
                await _context.SaveChangesAsync();
            }

        }
    }
}
