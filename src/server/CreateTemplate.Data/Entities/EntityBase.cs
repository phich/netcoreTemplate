using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CreateTemplate.Data.Entities
{
   public class EntityBase
    {
    public EntityBase()
    {
      Id = Guid.NewGuid();
    }

    [Key] public Guid Id { get; set; }

    [Required] public bool? IsActive { get; set; }

    [Required] public DateTime CreateDate { get; set; }

    public Guid? CreatedBy { get; set; }

    [Required] public DateTime UpdateDate { get; set; }

    [Required] public bool IsDelete { get; set; }
  }
}
