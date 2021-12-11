using System.Collections.Generic;
using System.Threading.Tasks;

namespace GFTTechnicalTest.Domain.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity: class
    {
        public Task AddAsync(TEntity entity);

        public Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
