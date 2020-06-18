using System;

namespace NetAcademia_Bridge2
{
    public class EmailMessage
    {
        public EmailAddress From { get; set; }
        public EmailAddress To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public static EmailMessage Factory(EmailAddress from, EmailAddress to, string subject, string message)
        {
            return new EmailMessage
            {
                From = from,
                To = to,
                Subject = subject,
                Message = message
            };

        }
    }
}