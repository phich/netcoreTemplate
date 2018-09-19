using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CreateTemplate.Data.Contexts;
using CreateTemplate.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreateTemplate.Data.Repositories.Base
{
  public abstract class Repository<T> : IRepository<T>
    where T : EntityBase
  {
    protected Repository(ApplicationDbContext context)
    {
      _context = context;
      _entities = context.Set<T>();
    }

    #region ProtectedFields

    protected readonly DbContext _context;
    protected readonly DbSet<T> _entities;


    #endregion

    #region Methods

    public void Add(T entity)
    {
      _entities.Add(entity);
    }

    public virtual T GetById(object id)
    {
      return _entities.Find(id);
    }


    public void Delete(Guid id)
    {
      var delete = GetById(id).Result;
      delete.IsDeleted = true;
      Update(delete);
    }

    public void Delete(T entity)
    {
      throw new NotImplementedException();
    }

    public async Task<T> GetById(Guid id)
    {
      return await _entities.FindAsync(id);
    }

    public IQueryable<T> GetAll()
    {
      return _entities.Where(i => !i.IsDeleted);
    }

    public IQueryable<T> GetFull()
    {
      return _entities.AsQueryable();
    }

    public IQueryable<T> GetActives()
    {
      return GetAll().Where(i => i.IsActive.Value && !i.IsDeleted);
    }

    public virtual void Update(T entityToUpdate)
    {
      _entities.Update(entityToUpdate);
    }

    #endregion
  }
}
