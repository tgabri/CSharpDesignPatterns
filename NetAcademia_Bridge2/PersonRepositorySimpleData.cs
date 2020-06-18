using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Bridge2
{
    public class PersonRepositorySimpleData : IPersonRepository
    {
        public Person GetBirthdayPeople()
        {
            return new Person
            {
                Name = "Fosos Toni",
                EmailAddress = new EmailAddress { Address = "fostos@gmail.com", Display = "Ceges email" }
            };
        }

        public List<Person> GetPeopleToSendMessageTo()
        {
            return new List<Person>(new Person[] {
            new Person
            {
                Name = "Fosos Toni",
                EmailAddress = new EmailAddress { Address = "fostos@gmail.com", Display = "Ceges email" }
            }
            });
        }
    }
}
