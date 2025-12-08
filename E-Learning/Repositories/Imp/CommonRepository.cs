
using Azure.Core;
using E_Learning.Domain.Comon;
using E_Learning.Infrastructure.Persistence;
using E_Learning.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repositories.Imp
{
    public class CommonRepository<T> : ICommonRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public CommonRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<ListPages<T>> GetAllAsync(short? page, short? pageSize)
        {
            var totalCount = await _dbSet.CountAsync(x => !x.IsDeleted);

            short defaultPage = page ?? 1;
            short defaultPageSize = pageSize ?? 20;

            var items = await _dbSet
                .Where(x => !x.IsDeleted)
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .Skip((defaultPage - 1) * defaultPageSize)
                .Take(defaultPageSize)
                .ToListAsync();

            return new ListPages<T>
            {
                Items = items,
                TotalCount = totalCount,
                Page = defaultPage,
                PageSize = defaultPageSize
            };
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> AddListAsync(List<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> UpdateListAsync(List<T> entities)
        {
            _dbSet.UpdateRange(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteListAsync(List<Guid> ids)
        {
            var entities = await _dbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
            if (!entities.Any()) return false;

            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
