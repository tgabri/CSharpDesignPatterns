﻿using System;

namespace NetAcademia_Bridge2
{
    public class SendWithExchangeTest : SendWithExchange
    {
        public override void Send(EmailMessage message)
        {
            Console.WriteLine("Host: {0}, Username: {1}", Host, Username);
            Console.WriteLine("Kuldo: {0}", message.From.Address);
            Console.WriteLine("Cimzett: {0}", message.To.Address);
            Console.WriteLine("Subject: {0}", message.Subject);
            Console.WriteLine("Uzenet: {0}", message.Message);
            Console.WriteLine("Uzenet elkuldve az Exchange service-bol!");
        }

        protected override void Setup()
        {
            Host = "1.1.1.1";
            Username = "TestUser";
            Password = "pswrd123";
        }
    }
}