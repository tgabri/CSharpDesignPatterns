namespace NetAcademia_Command
{
    public class NincsIlyenParancs : IParancs
    {
        private string parameter;

        public string ParancsSzoveg => throw new System.NotImplementedException();

        public string HasznalatiUtasitas => throw new System.NotImplementedException();

        public void ParameterBeallitas(string[] args)
        {
            parameter = args[0];
        }

        public string Vegrehajtas()
        {
            return string.Format(MagicValues.CommandResponseInvalid, parameter);
        }
    }
}