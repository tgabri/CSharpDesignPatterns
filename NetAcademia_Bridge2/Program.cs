using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Bridge2
{
    class Program
    {
        static void Main(string[] args)
        {
            //A hid minta bevezetesehez es tesztjehez
            TestBridge();

            //TestBridgeDecoratorAndProxy();

            Console.ReadLine();
        }

        private static void TestBridgeDecoratorAndProxy()
        {
            var officeAddress = new EmailAddress { Address = "iroda@gmail.com", Display = "Irodai email" };

            //Elore tudom h hidat akarok hasznalni
            //Levalasztom a konkret megvalositast a hasznalattol, ez az adatok tarolasanal a repository minta
            var repo = new PersonRepository();

            var person = repo.GetBirthdayPeople();
            var sendWith = AbstractSendWith.Factory<SendWith>();
            var service = new EmailService(sendWith);

            //Decorator minta
            var serviceWithLogger = new EmailServiceWithLogger(service, sendWith);
            //EmailService serviceWithLogger = new EmailServiceWithLogger(service, sendWith);


            //PROXY minta: ha a proxy osztaly feluletenek a hasznalatat ki lehet kenyszeriteni
            var serviceProxy = new EmailServiceProxy(service, sendWith);

            var message = new EmailMessage
            {
                From = officeAddress,
                To = person.EmailAddress,
                Subject = "Udvozlet",
                Message = "Boldog Szuletesnapot..."
            };

            serviceWithLogger.Send(message);
        }

        private static void TestBridge()
        {
            var message = new EmailMessage
            {
                From = new EmailAddress { Address = "sender@email.com", Display = "Az elso cim" },
                To = new EmailAddress { Address = "test@email.com", Display = "A masodik cim" },
                Subject = "Test Subject",
                Message = "Ez egy teszt uzenet..."
            };

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
