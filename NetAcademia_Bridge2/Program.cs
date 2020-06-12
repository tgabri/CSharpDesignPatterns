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
            //TestBridge();

            var officeAddress = new EmailAddress { Address = "iroda@gmail.com", Display = "Irodai email" };

            //Elore tudom h hidat akarok hasznalni
            //Levalasztom a konkret megvalositast a hasznalattol, ez az adatok tarolasanal a repository minta
            var repo = new PersonRepository();

            var person = repo.GetBirthdayPeople();

            var sendWith = new SendWith();
            var service = new EmailService(sendWith);
            var serviceWithLogger = new EmailServiceWithLogger(service, sendWith);

            var message = new EmailMessage
            {
                From = officeAddress,
                To = person.EmailAddress,
                Subject = "Udvozlet",
                Message = "Boldog Szuletesnapot..."
            };

            serviceWithLogger.Send(message);

            Console.ReadLine();
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
            var strategy = new SendWith();

            //Abstraction
            var service = new EmailService(strategy);
            service.Send(message);
            Console.WriteLine();

            var strategyExch = new SendWithExchange();
            strategyExch.Host = "1.1.1.1";
            strategyExch.Username = "TestUser";
            strategyExch.Password = "pswrd123";
            service = new EmailService(strategyExch);
            strategyExch.Send(message);
            Console.WriteLine();

            var strategySG = new SendWithSenderGrid();
            strategySG.HostUrl = "https://sendgrid.service.com";
            strategySG.ApiKey = "SG_APIKEY";
            service = new EmailService(strategySG);
            strategySG.Send(message);
            Console.WriteLine();

            var strategyMandrill = new SendWithMandrill();
            strategyMandrill.HostUrl = "https://mandrill.service.com";
            strategyMandrill.ClientSecret = "MANDRILL-SECRET";
            strategyMandrill.ClientKey = "MANDRILL-KEY";
            service = new EmailService(strategyMandrill);
            strategyMandrill.Send(message);
            Console.WriteLine();
        }
    }
}
