using FootyCore.DataAccessLayer.Abstract;
using FootyCore.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FootyCore.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly FootyContext _context;

        public GenericRepository(FootyContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            var value = await _context.Set<T>().FindAsync(id);
            if (value == null)
            {
                return;
            }

            _context.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetList()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Insert(T t)
        {
            await _context.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T t)
        {
            _context.Update(t);
            await _context.SaveChangesAsync();
        }
    }
}
