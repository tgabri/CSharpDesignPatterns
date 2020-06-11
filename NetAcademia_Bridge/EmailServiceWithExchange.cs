using System;

namespace NetAcademia_Bridge
{
    public class EmailServiceWithExchange : EmailService
    {

        ///Exchange szerver cime
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public override void Send(EmailMessage message)
        {
            Console.WriteLine("Host: {0}, Username: {1}", Host, Username);
            Console.WriteLine("Kuldo: {0}", message.From.Address);
            Console.WriteLine("Cimzett: {0}", message.To.Address);
            Console.WriteLine("Subject: {0}", message.Subject);
            Console.WriteLine("Uzenet: {0}", message.Message);
            Console.WriteLine("Uzenet elkuldve az Exchange service-bol SMTP-vel!");
        }
    }
}