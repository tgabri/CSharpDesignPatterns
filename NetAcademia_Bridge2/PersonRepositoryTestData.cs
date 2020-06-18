using System;
using System.Collections.Generic;

namespace NetAcademia_Bridge2
{
    public class PersonRepositoryTestData : IPersonRepository
    {
        List<Person> data = new List<Person>();
        public PersonRepositoryTestData()
        {
            data.Add(
                new Person
                {
                    Name = "Barmi Aron",
                    EmailAddress = new EmailAddress { Address = "test@gmail.com", Display = "Ceges email" }
                });
            data.Add(
                 new Person
                 {
                     Name = "Mekk Elek",
                     EmailAddress = new EmailAddress { Address = "elek@gmail.com", Display = "Ceges email" }
                 });
            data.Add(
                 new Person
                 {
                     Name = "Joska Pista",
                     EmailAddress = new EmailAddress { Address = "joskapista@gmail.com", Display = "Ceges email" }
                 });
        }

        public Person GetBirthdayPeople()
        {
            return data[0];
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPeopleToSendMessageTo()
        {
            return data;
        }
    }
}