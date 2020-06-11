using System;

namespace NetAcademia_Bridge
{
    /// <summary>
    /// Feladat: egy olyan rendszer, ami kulonbozo fajtaju uzeneteket kepes kezelni:
    /// letrehozni, menteni, kuldeni, megjeleniteni
    /// az ehhez szukseges infrastruktura (cimek, szemelyek) kezelese
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var message = new EmailMessage
            {
                From = new EmailAddress { Address = "sender@email.com", Display = "Az elso cim" },
                To = new EmailAddress { Address = "test@email.com", Display = "A masodik cim" },
                Subject = "Test Subject",
                Message = "Ez egy teszt uzenet..."
            };

            var service = new EmailService();
            service.Send(message);
            Console.WriteLine();

            var serviceExch = new EmailServiceWithExchange();
            serviceExch.Host = "1.1.1.1";
            serviceExch.Username = "TestUser";
            serviceExch.Password = "pswrd123";
            serviceExch.Send(message);
            Console.WriteLine();

            var serviceSG = new EmailServiceWithSenderGrid();
            serviceSG.HostUrl = "https://sendgrid.service.com";
            serviceSG.ApiKey = "SG_APIKEY";
            serviceSG.Send(message);
            Console.WriteLine();

            var serviceMandrill = new EmailServiceWithMandrill();
            serviceMandrill.HostUrl = "https://mandrill.service.com";
            serviceMandrill.ClientSecret = "MANDRILL-SECRET";
            serviceMandrill.ClientKey = "MANDRILL-KEY";
            serviceMandrill.Send(message);

            Console.ReadLine();
        }
    }
}
