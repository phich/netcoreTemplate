using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CreateTemplate.Business.Models
{
    public class EmailTemplateModel
    {
      public Guid Id { get; set; }
      [Required] public string Name { get; set; }

      public string Description { get; set; }

      [Required] public string EmailSubject { get; set; }

      [Required] public string EmailBody { get; set; }

      [Required] public string EmailTemplateStatus { get; set; }

      [Required] public string RecipientsDetails { get; set; }

      [Required] public bool IsSendNotification { get; set; }
  }
}
