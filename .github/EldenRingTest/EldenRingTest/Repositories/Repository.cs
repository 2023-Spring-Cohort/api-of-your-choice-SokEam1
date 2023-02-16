using EldenRingTutorial.Context;
using EldenRingTutorial.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EldenRingTutorial.Repositories

    //Virtual = other classes that use the repository class can override these classes if they need to
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly GameContext context;
        public Repository(GameContext dbcontext)
        {
            context = dbcontext;
        }

        protected DbContext Context { get { return context; } } //Converting a GameContext to a DbContext 
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity); //Recording all changes to be saved to the database
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            TEntity? entity = await GetByIdAsync(id);
            if (entity != null)
            {
                Context.Remove(entity);
                await Context.SaveChangesAsync();
            }
        }

        public virtual List<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public virtual async Task<TEntity>? GetByIdAsync(int id)
        {
             TEntity? entity = await Context.Set<TEntity>()
                                   .Where(w => EF.Property<int>(w, "Id") == id) //Told EF to look for Id, and it should be a INT... (Id is a key)
                                   .FirstOrDefaultAsync(); //Lamba Expression
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity)
                .State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }
    }
}
