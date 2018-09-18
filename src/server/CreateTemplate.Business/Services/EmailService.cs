using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CreateTemplate.Business.Services.Interfaces;
using CreateTemplate.Core.AppSettings;
using CreateTemplate.Core.EmailModel;

namespace CreateTemplate.Business.Services
{
  public class EmailService : IEmailService
  {
    private readonly IEmailSetting _emailSetting;

    public EmailService(IEmailSetting emailSetting)
    {
      _emailSetting = emailSetting;
    }

    public List<EmailMessage> ReceiveEmail(int maxCount = 10)
    {
      throw new NotImplementedException();
    }

    public async Task Send(EmailMessage email)
    {
      using (var client = new SmtpClient())
      {
        var credential = new NetworkCredential
        {
          UserName = _emailSetting.SmtpUsername,
          Password = _emailSetting.SmtpPassword
        };

        client.Credentials = credential;
        client.Host = _emailSetting.SmtpServer;
        client.Port = _emailSetting.SmtpPort;
        client.EnableSsl = true;

        using (var emailMessage = new MailMessage())
        {
          foreach (var toAddress in email.ToAddresses)
          {
            emailMessage.To.Add(new MailAddress(toAddress.Address, toAddress.Name));
          }

          emailMessage.From = new MailAddress(_emailSetting.SmtpEmailForm);
          emailMessage.Subject = email.Subject;
          emailMessage.Body = email.Body;
          emailMessage.Attachments.Add(new Attachment());
          await client.SendMailAsync(emailMessage);
        }
      }
    }
  }
}
