namespace MailService.ViewModels
{
    /// <summary>
    /// User request view model
    /// </summary>
    public class RequestVm
    {
        /// <summary>
        /// Message subject
        /// </summary>
        public string Subject { get; set; }
        
        /// <summary>
        /// Message body
        /// </summary>
        public string Body { get; set; }
        
        /// <summary>
        /// Message recipients
        /// </summary>
        public List<string> Recipients { get; set; }
    }
}

