using System.Linq;
using System.Threading.Tasks;

namespace SmartMed.Models.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task DeleteAsync(int id);
        Task<TEntity> GetByAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
    }
}
