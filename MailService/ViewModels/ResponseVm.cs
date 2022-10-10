namespace MailService.ViewModels
{
    /// <summary>
    /// Response view model
    /// </summary>
    public class ResponseVm
    {
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
        public List<RecipientVm> Recipients { get; set; }
    }
}

