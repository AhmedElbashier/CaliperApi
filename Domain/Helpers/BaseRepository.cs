using System;
using System.Linq;

namespace CaliperApi.Domain.Helpers
{
    public interface IBaseRepository<T>
    {
        T Find(int id);
    }

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public T Find(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }
    }
}