namespace CreateTemplate.Core.AppSettings
{
  public interface IEmailSetting
  {
     string SmtpServer { get; set; }
     int SmtpPort { get; set; }
     string SmtpUsername { get; set; }
     string SmtpPassword { get; set; }
    string SmtpEmailForm { get; set; }
  }
}