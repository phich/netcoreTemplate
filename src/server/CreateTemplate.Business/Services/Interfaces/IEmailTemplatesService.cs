using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CreateTemplate.Business.Models;
using CreateTemplate.Core;
using CreateTemplate.Core.Results;
using CreateTemplate.Core.Results.Gird;
using CreateTemplate.Data.Entities.Emails;
using Optional;

namespace CreateTemplate.Business.Services.Interfaces
{
    public interface IEmailTemplatesService
    {
        GridResponse<EmailTemplate> Search(GridModel model);
      Task<ResponseResult> Create(EmailTemplateModel model);
      Task<ResponseResult> Update(EmailTemplateModel model,Guid id);
    }
    
}
