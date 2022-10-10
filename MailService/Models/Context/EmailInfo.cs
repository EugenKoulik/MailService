using System.ComponentModel.DataAnnotations;

namespace MailService.Models.Context
{
    /// <summary>
    /// Message sending information dto
    /// </summary>
    public class EmailInfo
    {
        /// <summary>
        /// Unique identificator (PK)
        /// </summary>
        [Key]
        public Guid Id = Guid.NewGuid();
        
        /// <summary>
        /// Date the message was sent
        /// </summary>
        public string Date { get; set; }
        
        /// <summary>
        /// Subject of sent message
        /// </summary>
        public string Subject { get; set; }
        
        /// <summary>
        /// Body of sent message
        /// </summary>
        public string Body { get; set; }
        
        /// <summary>
        /// Recipients of sent message
        /// </summary>
        public List<Recipient> Recipients { get; set; }
    }
}

