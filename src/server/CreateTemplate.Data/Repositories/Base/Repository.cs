using System;
using System.Linq;
using System.Threading.Tasks;
using CreateTemplate.Data.Contexts;
using CreateTemplate.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreateTemplate.Data.Repositories.Base
{
  public abstract class Repository<T> : IRepository<T> where T : EntityBase
  {
    protected Repository(ApplicationDbContext context)
    {
      Context = context;
      DbSet = context.Set<T>();
    }

    #region ProtectedFields

    public ApplicationDbContext Context { get; set; }
    protected DbSet<T> DbSet { get; set; }

    #endregion

    #region Methods

    public void Add(T entity)
    {
      try
      {
        entity.UpdateDate = DateTime.Now;
        if (!entity.IsActive.HasValue)
          entity.IsActive = true;
        entity.CreateDate = DateTime.Now;
        entity.IsDelete = false;
        DbSet.Add(entity);
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public virtual T GetById(object id)
    {
      return DbSet.Find(id);
    }

    public virtual void Delete(object id)
    {
      var entityToDelete = DbSet.Find(id);
      entityToDelete.IsDelete = true;
      Update(entityToDelete);
    }

    public async Task<T> GetById(Guid id)
    {
      return await DbSet.FindAsync(id);
    }

    public IQueryable<T> GetAll()
    {
      return DbSet.Where(i => !i.IsDelete);
    }

    public IQueryable<T> GetFull()
    {
      return DbSet.AsQueryable();
    }

    public IQueryable<T> GetActives()
    {
      return GetAll().Where(i => i.IsActive.Value && !i.IsDelete);
    }

    public virtual void Delete(T entityToDelete)
    {
      if (Context.Entry(entityToDelete).State == EntityState.Detached) DbSet.Attach(entityToDelete);

      DbSet.Remove(entityToDelete);
    }

    public virtual void Update(T entityToUpdate)
    {
      entityToUpdate.UpdateDate = DateTime.Now;
      DbSet.Attach(entityToUpdate);
      Context.Entry(entityToUpdate).State = EntityState.Modified;
    }
   #endregion
  }
}
