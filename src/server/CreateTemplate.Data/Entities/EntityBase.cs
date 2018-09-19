using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CreateTemplate.Data.Entities.Interface;

namespace CreateTemplate.Data.Entities
{
  public class EntityBase : IEntityBase
  {
    public EntityBase()
    {
      Id = Guid.NewGuid();
    }

    [Key] public Guid Id { get; set; }

    [Required] public bool? IsActive { get; set; }

    [Required] public Guid CreatedBy { get; set; }
    [Required] public Guid UpdatedBy { get; set; }
    [Required] public DateTime CreatedDate { get; set; }
    [Required] public DateTime UpdatedDate { get; set; }
    [Required] public bool IsDeleted { get; set; }
  }
}