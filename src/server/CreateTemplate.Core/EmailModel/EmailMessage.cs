﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CreateTemplate.Core.EmailModel
{
    public class EmailMessage
    {
      public EmailMessage()
      {
        ToAddresses = new List<EmailAddress>();
        FromAddresses = new List<EmailAddress>();
      }

      public List<EmailAddress> ToAddresses { get; set; }
      public List<EmailAddress> FromAddresses { get; set; }
      public string Subject { get; set; }
      public string Body { get; set; }
  }
}