using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Bridge2
{
    class Program
    {
        private static StandardKernel kernel;

        static void Main(string[] args)
        {
            //A hid minta bevezetesehez es tesztjehez
            // TestBridge();

            //Ninject felparameterezese
            kernel = new StandardKernel();
            kernel.Bind<IPersonRepository>()
                //.To<PersonRepositoryTestData>()
                .To<PersonRepositorySimpleData>()
                .InSingletonScope();

            //Console.WriteLine("TestBridgeDecoratorAndProxy");
            //Console.WriteLine();
            //TestBridgeDecoratorAndProxy();



            //var send = AbstractSendWith.Factory<SendWithExchange>();
            //var service = new EmailService(send);
            //var repo = kernel.Get<IPersonRepository>();
            //var template = new Templating();

            //var msgService = new MessageService(service, repo, template);
            //msgService.Run();


            //Letrehozasok becsomagaolasa  egy specialis strategiaba
            var birthdayMessageFactoryWithExchange = new BirthdayMessageFactoryWithExchange();
            var msgService = new MessageService(birthdayMessageFactoryWithExchange);

            msgService.Run();

            Console.WriteLine();

            var welcomeMessageFactoryWithSendGrid = new WelcomeMessageFactoryWithSendGrid();
            msgService = new MessageService(welcomeMessageFactoryWithSendGrid);

            msgService.Run();

            Console.ReadLine();
        }

        private static void TestBridgeDecoratorAndProxy()
        {
            var officeAddress = EmailAddressFactory.GetOfficeAddress();

            //Elore tudom h hidat akarok hasznalni
            //Levalasztom a konkret megvalositast a hasznalattol, ez az adatok tarolasanal a repository minta
            //E helyett hasznalhatunk ninject dependency injection-t
            // var repo = new PersonRepository();
            //Ninject megoldas:
            var repo = kernel.Get<IPersonRepository>();

            var person = repo.GetBirthdayPeople();
            var sendWith = AbstractSendWith.Factory<SendWith>();
            var service = new EmailService(sendWith);

            //Decorator minta
            var serviceWithLogger = new EmailServiceWithLogger(service, sendWith);
            //EmailService serviceWithLogger = new EmailServiceWithLogger(service, sendWith);


            //PROXY minta: ha a proxy osztaly feluletenek a hasznalatat ki lehet kenyszeriteni
            var serviceProxy = new EmailServiceProxy(service, sendWith);

            var message = EmailMessage.Factory(officeAddress, person.EmailAddress, "Udvozlet", "Boldog Szuletesnapot...");

            serviceWithLogger.Send(message);
        }

        private static void TestBridge()
        {
            EmailMessage message = EmailMessage.Factory(
                from: EmailAddressFactory.GetNewAddress(address: "sender@email.com", display: "Az elso cim"),
                to: EmailAddressFactory.GetNewAddress("test@email.com", "A masodik cim"),
                subject: "Test Subject",
                message: "Ez egy teszt uzenet...");


            //Implementor
            var strategy = AbstractSendWith.Factory<SendWith>();

            //Abstraction
            var service = new EmailService(strategy);
            service.Send(message);
            Console.WriteLine();

            var strategyExch = AbstractSendWith.Factory<SendWithExchange>();
            service = new EmailService(strategyExch);
            strategyExch.Send(message);
            Console.WriteLine();

            var strategySG = AbstractSendWith.Factory<SendWithSendGrid>();
            service = new EmailService(strategySG);
            strategySG.Send(message);
            Console.WriteLine();

            var strategyMandrill = AbstractSendWith.Factory<SendWithMandrill>();
            service = new EmailService(strategyMandrill);
            strategyMandrill.Send(message);
            Console.WriteLine();
        }


    }
}
