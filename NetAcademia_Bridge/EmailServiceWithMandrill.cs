using System;

namespace NetAcademia_Bridge
{
    public class EmailServiceWithMandrill : EmailService
    {
        public EmailServiceWithMandrill()
        {
        }

        public string HostUrl { get; set; }
        public string ClientSecret { get; set; }
        public string ClientKey { get; set; }

        public override void Send(EmailMessage message)
        {
            Console.WriteLine("HostUrl: {0}", HostUrl);
            Console.WriteLine("ClientSecret: {0}", ClientSecret);
            Console.WriteLine("ClientKey: {0}", ClientKey);
            Console.WriteLine("Kuldo: {0}", message.From.Address);
            Console.WriteLine("Cimzett: {0}", message.To.Address);
            Console.WriteLine("Subject: {0}", message.Subject);
            Console.WriteLine("Uzenet: {0}", message.Message);
            Console.WriteLine("Uzenet elkuldve az Mandrill service-bol API-val!");
        }
    }
}