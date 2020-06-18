using System;

namespace NetAcademia_Bridge2
{
    public class WelcomeTemplating : AbstractTemplating
    {
        protected override string GetMessage(Person person)
        {
            return $"Kedves {person.Name}! A ceg neveben szeretnenk udvozolni a cegnel!";
        }

        protected override string GetSubject(Person person)
        {
            return "Udvozlet az uj kolleganak!";
        }
    }
}