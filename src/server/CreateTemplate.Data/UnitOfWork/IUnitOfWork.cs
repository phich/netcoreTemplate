
using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using CreateTemplate.Data.Contexts;

namespace CreateTemplate.Data.UnitOfWork
{
  public interface IUnitOfWork: IDisposable
  {
    #region DbContext

    ApplicationDbContext _context { get; }
    void Commit();
    Task<int> CommitAsync();

    #endregion
  }
}
