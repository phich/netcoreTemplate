using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CreateTemplate.Data.Entities.Emails
{
  public class EmailTemplate : EntityBase
  {
    [Required] public string Name { get; set; }

    public string Description { get; set; }

    [Required] public string EmailSubject { get; set; }

    [Required] public string EmailBody { get; set; }

    [Required] public string EmailTemplateStatus { get; set; }

    [Required] public string RecipientsDetails { get; set; }

    [Required] public bool IsSendNotification { get; set; }
  }
}
