using System.Collections.Generic;

namespace NetAcademia_Bridge2
{
    public interface IPersonRepository
    {
        Person GetBirthdayPeople();
        List<Person> GetPeopleToSendMessageTo();
    }
}