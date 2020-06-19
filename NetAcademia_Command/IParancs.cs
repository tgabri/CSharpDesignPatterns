namespace NetAcademia_Command
{
    public interface IParancs
    {
        string ParancsSzoveg { get; }

        void ParameterBeallitas(string[] args);
        string Vegrehajtas();
    }
}