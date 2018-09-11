using System;
using System.Threading.Tasks;
using CreateTemplate.Data.Contexts;


namespace CreateTemplate.Data.UnitOfWork
{
  public class UnitOfWork : IUnitOfWork
  {
 
    public UnitOfWork(ApplicationDbContext context)
    {
      _context = context;
    }

    public ApplicationDbContext _context { get; set; }

  
    public void Commit()
    {
      try
      {
        _context.SaveChanges();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    public async Task<int> CommitAsync()
    {
      return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }


    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (_context != null)
        {
          _context.Dispose();
          _context = null;
        }
      }
    }

   
  }
}
