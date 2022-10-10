namespace MailService.ViewModels
{
    /// <summary>
    /// View model of the user to send the message
    /// </summary>
    public class RecipientVm
    {
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

