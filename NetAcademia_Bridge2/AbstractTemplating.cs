namespace NetAcademia_Bridge2
{
    public abstract class AbstractTemplating
    {
        public EmailMessage GetMessageFor(Person person)
        {
            var from = EmailAddressFactory.GetOfficeAddress();
            var to = EmailAddressFactory.GetNewAddress(person.EmailAddress.Address, person.EmailAddress.Display);
            var subject = GetSubject(person);
            var message = GetMessage(person);


            return EmailMessage.Factory(from, to, subject, message);
        }

        protected abstract string GetMessage(Person person);

        protected abstract string GetSubject(Person person);
    }
}