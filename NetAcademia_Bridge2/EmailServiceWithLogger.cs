namespace NetAcademia_Bridge2
{
    internal class EmailServiceWithLogger : EmailService
    {
        private EmailService service;

        public EmailServiceWithLogger(EmailService service, AbstractSendWith sendWith)
            : base(sendWith)
        {
            this.service = service;
        }

        public new void Send(EmailMessage message)
        {
            System.Console.WriteLine("<<<<<<<<<<<<<<<<< Levelkuldes eleje >>>>>>>>>>>>>>>>>>>>");
            service.Send(message);
            System.Console.WriteLine("<<<<<<<<<<<<<<<<< Levelkuldes vega >>>>>>>>>>>>>>>>>>>>");
        }
    }
}