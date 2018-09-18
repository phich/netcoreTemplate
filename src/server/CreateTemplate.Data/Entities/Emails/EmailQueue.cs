using System;
using System.Collections.Generic;
using System.Text;

namespace CreateTemplate.Data.Entities.Emails
{
   public class EmailQueue:EntityBase
  {  // [Required]
    public int TrialCount { get; set; }

    //[Required]
    public string SenderEmail { get; set; }

    //[Required]
    public string ReceiverEmails { get; set; }

    //[Required]
    public string CCEmails { get; set; }

    //[Required]
    public string BCCEmails { get; set; }

    //[Required]
    public string EmailTitle { get; set; }

    //[Required]
    public string EmailContent { get; set; }

    public string Attachments { get; set; }

    //[Required]
    public bool IsBodyHtml { get; set; }

    public string EmailTemplate { get; set; }
  }
}
