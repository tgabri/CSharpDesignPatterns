using System;

namespace NetAcademia_Bridge2
{
    public class Templating
    {
        public EmailMessage GetMessageFor(Person person)
        {
            var from = EmailAddressFactory.GetOfficeAddress();
            var to = EmailAddressFactory.GetNewAddress(person.EmailAddress.Address, person.EmailAddress.Display);
            var subject = GetSubject(person);
            var message = GetMessage(person);


            return EmailMessage.Factory(from, to, subject, message);
        }

        private string GetMessage(Person person)
        {
            return $"Kedves {person.Name}! A ceg neveben szeretnenk Boldog Szuletesnapot kivanni!";
        }

        private string GetSubject(Person person)
        {
            return "Szuletesnapi udvozlet";
        }
    }
}