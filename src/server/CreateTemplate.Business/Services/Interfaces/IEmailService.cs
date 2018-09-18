using System.Threading.Tasks;
using CreateTemplate.Core.EmailModel;

namespace CreateTemplate.Business.Services.Interfaces
{
  public interface IEmailService
  {
    Task Send(EmailMessage emailMessage);
  }
}