namespace IDM.Domain.Contractors
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIDAsync(object id);
        Task AddAsync(T entity);
        Task UpdateAsync(object id, object model);
        Task DeleteAsync(object id);
        bool IsDataExist(Func<T, bool> condition);
    }
}
