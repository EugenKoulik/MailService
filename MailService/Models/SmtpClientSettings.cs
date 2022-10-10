namespace MailService.Models
{
    /// <summary>
    /// Mail service settings
    /// </summary>
    public class SmtpClientSettings
    {
        /// <summary>
        /// Mail service host
        /// </summary>
        public string Host { get; set; }
        
        /// <summary>
        /// Mail service port
        /// </summary>
        public int Port { get; set; }
        
        /// <summary>
        /// Your mail address (format: example@mail.ru)
        /// </summary>
        public string CustomerMailId { get; set; }

        /// <summary>
        /// Password for external application mail.ru
        /// </summary>
        public string CustomerPassword { get; set; }
    }
}

