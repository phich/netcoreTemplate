using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CreateTemplate.Business.Models;
using CreateTemplate.Core.Results.Gird;
using CreateTemplate.Data.Entities.Emails;

namespace CreateTemplate.Api.Configuration.Mappings
{
    public class EmailMappping:Profile
    {
      public EmailMappping()
      {
        CreateMap<EmailTemplateModel, EmailTemplate>();
        CreateMap<EmailTemplate, EmailTemplateModel>().ForMember(i => i.Id, t => t.Ignore());
        CreateMap<GridResponse<EmailTemplateModel>, GridResponse<EmailTemplate>>();
      }
    }
}
