﻿using System;

namespace NetAcademia_Bridge2
{
    public class SendWithMandrill : AbstractSendWith
    {
        public string HostUrl { get; internal set; }
        public string ClientSecret { get; internal set; }
        public string ClientKey { get; internal set; }



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
        protected override void Setup()
        {
            HostUrl = "https://mandrill.service.com";
            ClientSecret = "MANDRILL-SECRET";
            ClientKey = "MANDRILL-KEY";
        }


    }
}