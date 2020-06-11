using System;

namespace NetAcademia_Bridge2
{
    public class SendWithSenderGrid : ISendWith
    {
        public string HostUrl { get; internal set; }
        public string ApiKey { get; internal set; }

        public void Send(EmailMessage message)
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