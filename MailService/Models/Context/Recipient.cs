using System.ComponentModel.DataAnnotations;

namespace MailService.Models.Context
{
    /// <summary>
    /// Dto of the user to send the message
    /// </summary>
    public class Recipient
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid Id = new Guid();
        
        /// <summary>
        /// Message sending information dto
        /// </summary>
        public EmailInfo EmailInfo { get; set; }
        
        /// <summary>
        /// E-mail address
        /// </summary>
        public string? Email { get; set; }
        
        /// <summary>
        /// Message send result (ok or failed)
        /// </summary>
        public string Result { get; set; }
        
        /// <summary>
        /// Error text message
        /// </summary>
        public string? FailedMessage { get; set; }
    }
}

