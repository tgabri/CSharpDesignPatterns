using System;

namespace NetAcademia_Bridge2
{
    public class EmailService
    {
        private ISendWith strategy;

        public EmailService(ISendWith strategy)
        {
            this.strategy = strategy;
        }

        public void Send(EmailMessage message)
        {
            strategy.Send(message);
        }
    }
}