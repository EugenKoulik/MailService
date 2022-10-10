using System.Net;
using System.Net.Mail;
using MailService.Models;
using MailService.Models.Context;
using MailService.ViewModels;

namespace MailService.Services
{
    public class EmailService 
    {
        private readonly IConfigurationSection  _smtpClientSection;
        private readonly IConfigurationSection _dateTimeSection;
        private readonly EmailLoggerDbContext _db;

        public EmailService(EmailLoggerDbContext db, IConfiguration config)
        {
            _db = db;
            _smtpClientSection = config.GetSection(nameof(SmtpClientSettings));
            _dateTimeSection = config.GetSection("DateTimeFormat");
        }

        /// <summary>
        /// Method of sending messages to users and save messages to the database
        /// </summary>
        /// <param name="subject">User email subject</param>
        /// <param name="body">User email text</param>
        /// <param name="recipientsVm">User emails who need to send an email</param>
        public void Send(string subject, string body, List<string> recipientsVm)
        {
            var dateTimeConfig = _dateTimeSection.Get<string>();
            var smtpConfig = _smtpClientSection.Get<SmtpClientSettings>();
            
            var emailInfo = new EmailInfo()
            {
                Date = DateTime.Now.ToString(dateTimeConfig),
                Subject = subject,
                Body = body,
                Recipients = new List<Recipient>(recipientsVm.Count),
            };
            
            foreach (var currentRecipient in recipientsVm)
            {
                var recipient = new Recipient()
                {
                    EmailInfo = emailInfo,
                    Email = currentRecipient,
                    Result = SendingResult.Ok.ToString(),
                    FailedMessage = "",
                };
                
                try
                {
                    var email = new MailMessage(smtpConfig.CustomerMailId, currentRecipient, subject, body);

                    using (var client = new SmtpClient(smtpConfig.Host, smtpConfig.Port))
                    {
                        client.Credentials =
                            new NetworkCredential(smtpConfig.CustomerMailId, smtpConfig.CustomerPassword);
                        client.EnableSsl = true;
                        client.Timeout = 5000;
                        client.Send(email);
                    }
                }
                catch (Exception ex)
                {
                    recipient.Result = SendingResult.Failed.ToString();
                    recipient.FailedMessage = ex.Message;
                }
                finally
                {
                   emailInfo.Recipients.Add(recipient);
                   _db.Recipients.Add(recipient);
                }
            }

            _db.EmailsInfo.Add(emailInfo);
            _db.SaveChanges();
        }

        /// <summary>
        /// Returns data about all messages from the database
        /// </summary>
        /// <returns>Information about each message sent</returns>
        public List<EmailInfo> GetSendingEmails()
        {
            var emailsInfo = _db.EmailsInfo.AsQueryable().ToList();
            
            foreach (var emailInf in emailsInfo)
            {
                emailInf.Recipients = GetRecipients(emailInf);
            }
            
            return emailsInfo;
        }
        private List<Recipient> GetRecipients(EmailInfo emailInfo)
        {
            return _db.Recipients.Where(q => q.EmailInfo == emailInfo).ToList();
        }
    }
}

