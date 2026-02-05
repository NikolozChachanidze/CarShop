using CarShop.Data;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Repositorys
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _db;

        public EfRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _db.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
        }
    }
}
