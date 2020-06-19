namespace NetAcademia_Command
{
    public class UjParancs : IParancs
    {
        public string ParancsSzoveg => MagicValues.CommandTextNew;

        public void ParameterBeallitas(string[] args)
        {
            //nem kap parametert ezeert nincs szukseg implementaciora

        }

        public string Vegrehajtas()
        {
            return MagicValues.CommandResponseNew;
        }
    }
}