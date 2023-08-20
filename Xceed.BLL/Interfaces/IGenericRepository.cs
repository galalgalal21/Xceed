using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xceed.BLL.Interfaces
{
    public interface IGenericRepository<TEntity, TId>
    {
        Task<TEntity> GetById(TId id);
        Task<List<TEntity>> GetAll();
        Task<TEntity> Add(TEntity TEntity);
        Task<int> Update(TEntity TEntity);
        Task<int> Delete(TEntity TEntity);
    }
}
