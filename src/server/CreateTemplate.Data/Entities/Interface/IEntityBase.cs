using System;

namespace CreateTemplate.Data.Entities.Interface
{
  public interface IEntityBase
  {
    Guid CreatedBy { get; set; }
    Guid UpdatedBy { get; set; }
    DateTime CreatedDate { get; set; }
    DateTime UpdatedDate { get; set; }
    bool? IsActive { get; set; }

    bool IsDeleted { get; set; }
  }
}