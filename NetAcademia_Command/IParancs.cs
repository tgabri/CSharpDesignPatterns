namespace NetAcademia_Command
{
    public interface IParancs
    {
        string ParancsSzoveg { get; }
        string HasznalatiUtasitas { get; }

        void ParameterBeallitas(string[] args);
        string Vegrehajtas();
    }
}