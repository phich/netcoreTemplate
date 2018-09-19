using System;
using System.Collections.Generic;
using System.Text;
using CreateTemplate.Data.Contexts;
using CreateTemplate.Data.Entities.Emails;
using CreateTemplate.Data.Repositories.Base;
using CreateTemplate.Data.Repositories.Interfaces;

namespace CreateTemplate.Data.Repositories
{
   public class EmailTemplateRepository:Repository<EmailTemplate>, IEmailTemplateRepository
  {
      public EmailTemplateRepository(ApplicationDbContext context) : base(context)
      {
      }
    }
}
