using Ninject;

namespace NetAcademia_Bridge2
{
    public class WelcomeMessageFactoryWithSendGrid : AbstractMessageFactory
    {
        private readonly StandardKernel kernel;

        public WelcomeMessageFactoryWithSendGrid()
        {
            kernel = new StandardKernel();
            kernel.Bind<IPersonRepository>()
               .To<PersonRepositoryTestData>()
               //.To<PersonRepositorySimpleData>()
               .InSingletonScope();
        }

        public override AbstractTemplating TemplateFactory()
        {
            return new WelcomeTemplating();
        }

        public override EmailService EmailServiceFactory()
        {
            var send = AbstractSendWith.Factory<SendWithSendGrid>();
            return new EmailService(send);
        }

        public override IPersonRepository RepoFactory()
        {
            return kernel.Get<IPersonRepository>();
        }
    }
}