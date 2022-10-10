using MailService.Services;
using MailService.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MailService.Controllers
{
    public class ApiController : Controller
    {
        private readonly EmailService _emailService;
        
        public ApiController(EmailService emailService)
        {
            _emailService = emailService;
        }
        
        /// <summary>
        /// Method of sending messages to users
        /// </summary>
        /// <param name="request">Data to send</param>
        /// <returns>Http request status</returns>
        [HttpPost]
        public IActionResult Mails([FromBody] RequestVm request)
        {
            _emailService.Send(request.Subject, request.Body, request.Recipients);
            return Ok();
        }

        /// <summary>
        /// Method to get list of all sent messages
        /// </summary>
        /// <returns>Json string with information about each message sent</returns>
        [HttpGet]
        public IActionResult Mails()
        {
            var emailsInfo = _emailService.GetSendingEmails();
            var emailsInfoVm = new List<ResponseVm>();

            foreach (var emailInfo in emailsInfo)
            {
                var recipients = emailInfo.Recipients.Select(recipient => new RecipientVm()
                {
                    Email = recipient.Email,
                    Result = recipient.Result,
                    FailedMessage = recipient.FailedMessage,
                    
                }).ToList();

                emailsInfoVm.Add(new ResponseVm
                {
                    Date = emailInfo.Date,
                    Subject = emailInfo.Subject,
                    Body = emailInfo.Body,
                    Recipients = recipients,
                });
            }
            
            return Json(emailsInfoVm);
        }
    }
}

