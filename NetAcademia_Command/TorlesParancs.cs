namespace NetAcademia_Command
{
    public class TorlesParancs : IParancs
    {
        private string parameter;
        public string HasznalatiUtasitas => MagicValues.CommandTextDelete + " parameter";
        public string ParancsSzoveg => MagicValues.CommandTextDelete;

        public void ParameterBeallitas(string[] args)
        {
            parameter = args[1];
        }

        public string Vegrehajtas()
        {
            return string.Format(MagicValues.CommandResponseDelete, parameter);
        }
    }
}