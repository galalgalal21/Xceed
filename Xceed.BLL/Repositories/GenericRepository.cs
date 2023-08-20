using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xceed.BLL.Interfaces;
using Xceed.DAL.Contexts;

namespace Xceed.BLL.Repositories
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class
    {
        private readonly XceedDbContext context;

        public GenericRepository(XceedDbContext context)
        {
            this.context = context;
        }
        public async Task<TEntity> Add(TEntity TEntity)
        {
            await context.Set<TEntity>().AddAsync(TEntity);
            return TEntity;
        }

        public async Task<int> Delete(TEntity TEntity)
        {
            context.Set<TEntity>().Remove(TEntity);
            return await context.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> GetAll()
            => await context.Set<TEntity>().ToListAsync();

        public virtual async Task<TEntity> GetById(TId id)
            => await context.Set<TEntity>().FindAsync(id);
        

        public async Task<int> Update(TEntity TEntity)
        {
            context.Set<TEntity>().Update(TEntity);
            return await context.SaveChangesAsync();
        }
    }
}
