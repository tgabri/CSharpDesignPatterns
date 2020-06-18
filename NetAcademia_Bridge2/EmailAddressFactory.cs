using System;

namespace NetAcademia_Bridge2
{
    public class EmailAddressFactory
    {
        public static EmailAddress GetNewAddress(string address, string display)
        {
            return new EmailAddress { Address = address, Display = display };
        }
    }
}