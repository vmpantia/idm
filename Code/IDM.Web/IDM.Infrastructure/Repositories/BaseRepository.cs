using IDM.Common;
using IDM.Domain.Contractors;
using IDM.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace IDM.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _db;
        private readonly DbSet<T> _table;
        public BaseRepository(IDMDbContext db)
        {
            _db = db;
            _table = db.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _table.ToListAsync();
            if (result == null)
                throw new ArgumentNullException(Constants.ERROR_NO_RECORD_FOUND);

            return result;
        }

        public async Task<T> GetByIDAsync(object id)
        {
            var result = await _table.FindAsync(id);
            if (result == null)
                throw new ArgumentNullException(Constants.ERROR_NO_RECORD_FOUND);

            return result;
        }

        public bool IsDataExist(Func<T, bool> condition)
        {
            var result = _table.Where(condition);
            return result != null && result.Count() > 0;
        }

        public async Task AddAsync(T t)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t));

            await _table.AddAsync(t);
            var result = await _db.SaveChangesAsync();

            if (result <= 0)
                throw new Exception(Constants.ERROR_CREATING_DATA);
        }

        public async Task UpdateAsync(object id, object model)
        {
            var data = await GetByIDAsync(id);
            if (data != null)
            {
                _db.Entry(data).CurrentValues.SetValues(model);
                var result = await _db.SaveChangesAsync();

                if (result <= 0)
                    throw new Exception(Constants.ERROR_UPDATING_DATA);
            }
        }

        public async Task DeleteAsync(object id)
        {
            var data = await GetByIDAsync(id);
            if (data != null)
            {
                _table.Remove(data);
                var result = await _db.SaveChangesAsync();

                if (result <= 0)
                    throw new Exception(Constants.ERROR_DELETING_DATA);
            }
        }
    }
}
