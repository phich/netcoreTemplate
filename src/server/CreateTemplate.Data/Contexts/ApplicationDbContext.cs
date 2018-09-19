using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CreateTemplate.Data.Entities;
using CreateTemplate.Data.Entities.Emails;
using CreateTemplate.Data.Entities.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CreateTemplate.Data.Contexts
{
  public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
  {
    public Guid CurrentUserId { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
    {

    }

    private DbSet<EmailTemplate> EmailTemplates { get; set; }
    public override int SaveChanges()
    {
      UpdateAuditEntities();
      return base.SaveChanges();
    }


    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
      UpdateAuditEntities();
      return base.SaveChanges(acceptAllChangesOnSuccess);
    }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
      UpdateAuditEntities();
      return base.SaveChangesAsync(cancellationToken);
    }


    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
      CancellationToken cancellationToken = default(CancellationToken))
    {
      UpdateAuditEntities();
      return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

    }
    
    private void UpdateAuditEntities()
    {
      var modifiedEntries = ChangeTracker.Entries()
        .Where(x => x.Entity is IEntityBase && (x.State == EntityState.Added || x.State == EntityState.Modified));
      foreach (var entry in modifiedEntries)
      {
        var entity = (IEntityBase)entry.Entity;
        DateTime now = DateTime.UtcNow;

        if (entry.State == EntityState.Added)
        {
          if (!entity.IsActive.HasValue)
            entity.IsActive = true;
          entity.IsDeleted = false;
          entity.CreatedDate = now;
          entity.CreatedBy = CurrentUserId;
        }
        else
        {
          base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
          base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
        }

        entity.UpdatedDate = now;
        entity.UpdatedBy = CurrentUserId;
      }
    }
  }
}
