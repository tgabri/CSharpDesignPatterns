using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace NetAcademia_Adapter
{
    public class AdapterExample
    {
        private readonly IAddressRepository repo;
        private readonly IMessageService messageService;

        public AdapterExample(IAddressRepository repo, IMessageService messageService)
        {
            if (repo == null)
                throw new ArgumentNullException(nameof(repo));
            this.repo = repo;

            if (messageService == null)
                throw new ArgumentNullException(nameof(messageService));
            this.messageService = messageService;
        }

        public void Start()
        {
            var addressList = repo.GetAddresses();

            foreach (var address in addressList)
            {
                messageService.AddMessage(to: address.Email, subject: "subject", text: "Uzenet szovege...");

            }

            messageService.SendMessages();
        }
    }
}