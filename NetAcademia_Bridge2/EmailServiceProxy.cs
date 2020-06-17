namespace NetAcademia_Bridge2
{
    internal class EmailServiceProxy : EmailService
    {
        private EmailService service;

        public EmailServiceProxy(EmailService service, AbstractSendWith sendWith) : base(sendWith)
        {
            this.service = service;
        }

        public new void Send(EmailMessage message)
        {
            service.Send(message);
        }
    }
}