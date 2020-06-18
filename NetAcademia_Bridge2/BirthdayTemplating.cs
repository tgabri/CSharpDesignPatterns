using System;

namespace NetAcademia_Bridge2
{
    public class BirthdayTemplating : AbstractTemplating
    {
        protected override string GetMessage(Person person)
        {
            return $"Kedves {person.Name}! A ceg neveben szeretnenk Boldog Szuletesnapot kivanni!";
        }

        protected override string GetSubject(Person person)
        {
            return "Szuletesnapi udvozlet";
        }
    }
}