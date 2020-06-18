using System;

namespace NetAcademia_Bridge2
{
    public class MessageService
    {
        private EmailService service;
        private IPersonRepository repo;
        private Templating template;

        public MessageService(EmailService service, IPersonRepository repo, Templating template)
        {
            this.service = service;
            this.repo = repo;
            this.template = template;
        }

        public void Run()
        {
            var person = repo.GetBirthdayPeople();
            var message = template.GetMessageFor(person);
            service.Send(message);
        }
    }
}