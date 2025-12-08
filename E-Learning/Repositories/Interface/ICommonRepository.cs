using E_Learning.Domain.Comon;

namespace E_Learning.Repositories.Interface
{
    public interface ICommonRepository<T> where T : BaseEntity
    {
        Task<ListPages<T>> GetAllAsync(short? page, short? pageSize);

        Task<T?> GetByIdAsync(Guid id);

        Task<T> AddAsync(T entity);

        Task<List<T>> AddListAsync(List<T> entities);

        Task<T> UpdateAsync(T entity);

        Task<List<T>> UpdateListAsync(List<T> entities);

        Task<bool> DeleteAsync(Guid id);

        Task<bool> DeleteListAsync(List<Guid> ids);
    }
}
