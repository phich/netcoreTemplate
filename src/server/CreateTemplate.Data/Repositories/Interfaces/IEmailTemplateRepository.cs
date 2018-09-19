using System;
using System.Collections.Generic;
using System.Text;
using CreateTemplate.Data.Entities.Emails;
using CreateTemplate.Data.Repositories.Base;

namespace CreateTemplate.Data.Repositories.Interfaces
{
   public interface IEmailTemplateRepository:IRepository<EmailTemplate>
    {
    }
}
