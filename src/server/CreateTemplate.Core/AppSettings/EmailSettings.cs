using System;
using System.Collections.Generic;
using System.Text;

namespace CreateTemplate.Core.AppSettings
{
    public class EmailSettings: IEmailSetting
  {
      public string SmtpServer { get; set; }
      public int SmtpPort { get; set; }
      public string SmtpUsername { get; set; }
      public string SmtpPassword { get; set; }
      public string SmtpEmailForm { get; set; }
  }
}
