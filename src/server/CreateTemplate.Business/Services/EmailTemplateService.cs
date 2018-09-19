using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CreateTemplate.Business.Models;
using CreateTemplate.Business.Services.Interfaces;
using CreateTemplate.Core;
using CreateTemplate.Core.Results;
using CreateTemplate.Core.Results.Gird;
using CreateTemplate.Data.Entities.Emails;
using CreateTemplate.Data.UnitOfWork;
using Optional;

namespace CreateTemplate.Business.Services
{
  public class EmailTemplateService : ServiceBase, IEmailTemplatesService
  {
    private IMapper _mapper;
    public EmailTemplateService(IUnitOfWork unitOfWork, IMapper mapper)
      : base(unitOfWork)
    {
      _mapper = mapper;
    }

    public GridResponse<EmailTemplate> Search(GridModel model)
    {
      var lstEmailTemplate = _unitOfWork.EmailTemplateRepository.GetAll();
      var count = lstEmailTemplate.Count();
      lstEmailTemplate = OrderAndPaging(lstEmailTemplate, model);
      return new GridResponse<EmailTemplate>(lstEmailTemplate, count);
    }

    public async Task<ResponseResult> Create(EmailTemplateModel model)
    {
      var emailtemplate = _mapper.Map<EmailTemplate>(model);
      _unitOfWork.EmailTemplateRepository.Add(emailtemplate);
      await _unitOfWork.CommitAsync();
      return new ResponseResult(true);

    }

    public async Task<ResponseResult> Update(EmailTemplateModel model, Guid id)
    {
      var emailTemplate =await _unitOfWork.EmailTemplateRepository.GetById(id);
      emailTemplate = _mapper.Map<EmailTemplate>(model);
      await _unitOfWork.CommitAsync();
      return new ResponseResult(true);
    }
  }
}
