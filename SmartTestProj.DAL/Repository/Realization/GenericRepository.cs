using Microsoft.EntityFrameworkCore;
using SmartTestProj.DAL.Context;
using SmartTestProj.DAL.Repository.Interface;

namespace SmartTestProj.DAL.Repository.Realization
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext context;
        protected readonly DbSet<T> table;

        protected GenericRepository(AppDbContext context)
        {
            this.context = context;
            table = this.context.Set<T>();
        }

        public virtual async Task Delete(Guid id)
        {
            var item = await table.FindAsync(id);
            table.Remove(item!);
            await context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var items = await table.ToListAsync();
            return items;
        }

        public abstract Task<T> GetCompleteById(Guid id);

        public virtual async Task<T> GetById(Guid id)
        {
            var item = await table.FindAsync(id);
            return item!;
        }

        public virtual async Task Insert(T entity)
        {
            await table.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task Update(T entity)
        {
            table.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
