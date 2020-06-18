using Ninject;

namespace NetAcademia_Bridge2
{
    public class BirthdayMessageFactoryWithExchange : AbstractMessageFactory
    {
        private readonly StandardKernel kernel;

        public BirthdayMessageFactoryWithExchange()
        {
            kernel = new StandardKernel();
            kernel.Bind<IPersonRepository>()
               //.To<PersonRepositoryTestData>()
               .To<PersonRepositorySimpleData>()
               .InSingletonScope();
        }

        public override AbstractTemplating TemplateFactory()
        {
            return new BirthdayTemplating();
        }

        public override EmailService EmailServiceFactory()
        {
            var send = AbstractSendWith.Factory<SendWithExchange>();
            return new EmailService(send);
        }

        public override IPersonRepository RepoFactory()
        {
            return kernel.Get<IPersonRepository>();
        }
    }
}