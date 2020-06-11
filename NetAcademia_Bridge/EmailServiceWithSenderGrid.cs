using System;

namespace NetAcademia_Bridge
{
    public class EmailServiceWithSenderGrid : EmailService
    {
        public string ApiKey { get; set; }
        public string HostUrl { get; internal set; }

        public override void Send(EmailMessage message)
        {
            Console.WriteLine("ApiKey: {0}", ApiKey);
            Console.WriteLine("HostUrl: {0}", HostUrl);
            Console.WriteLine("Kuldo: {0}", message.From.Address);
            Console.WriteLine("Cimzett: {0}", message.To.Address);
            Console.WriteLine("Subject: {0}", message.Subject);
            Console.WriteLine("Uzenet: {0}", message.Message);
            Console.WriteLine("Uzenet elkuldve az SendGrid service-bol API-val!");
        }
    }
}