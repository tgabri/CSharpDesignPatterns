using System;

namespace NetAcademia_Bridge
{
    public class EmailService
    {
        public void Send(EmailMessage message)
        {
            Console.WriteLine("Kuldo: {0}", message.From.Address);
            Console.WriteLine("Cimzett: {0}", message.To.Address);
            Console.WriteLine("Subject: {0}", message.Subject);
            Console.WriteLine("Uzenet: {0}", message.Message);
            Console.WriteLine("Uzenet elkuldve!");
        }
    }
}