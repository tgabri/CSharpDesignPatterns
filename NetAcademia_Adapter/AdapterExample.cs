using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace NetAcademia_Adapter
{
    public class AdapterExample
    {
        public void Start()
        {
            //Adatforras
            var repo = new AddressRepository();


            //Indirekcio: keszitunk egy koztes osztalyt
            var messageService = new MessageService();

            var addressList = repo.GetAddresses();

            foreach (var address in addressList)
            {
                messageService.AddMessage(to: address.Email, subject: "subject", text: "Uzenet szovege...");

            }

            messageService.SendMessages();
        }
    }
}