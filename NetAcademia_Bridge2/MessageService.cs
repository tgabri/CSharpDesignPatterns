using System;

namespace NetAcademia_Bridge2
{
    public class MessageService
    {
        private EmailService service;
        private IPersonRepository repo;
        private AbstractTemplating template;
        private AbstractMessageFactory messageFactory;

        public MessageService(AbstractMessageFactory messageFactory)
        {
            this.service = messageFactory.EmailServiceFactory();
            this.repo = messageFactory.RepoFactory();
            this.template = messageFactory.TemplateFactory();
        }

        //public MessageService(EmailService service, IPersonRepository repo, Templating template)
        //{
        //    this.service = service;
        //    this.repo = repo;
        //    this.template = template;
        //}

        public void Run()
        {
            var people = repo.GetPeopleToSendMessageTo();
            foreach (var person in people)
            {
                var message = template.GetMessageFor(person);
                service.Send(message);
                Console.WriteLine();
            }
        }
    }
}