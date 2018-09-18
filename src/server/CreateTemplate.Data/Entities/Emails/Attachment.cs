using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CreateTemplate.Data.Entities.Emails
{
     public class Attachment :EntityBase
    {
      public string FileName { get; set; }

      public string FileDisplayName { get; set; }

      public string FileExtension { get; set; }

      public long FileSize { get; set; }

      public bool IsImage { get; set; }

      public byte[] FileStream { get; set; }

      public byte[] ThumbnailStream { get; set; }

      public Guid ReferenceId { get; set; }

      public string ReferenceType { get; set; }

      public string Remarks { get; set; }
  }
}
