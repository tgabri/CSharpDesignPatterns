﻿namespace NetAcademia_Command
{
    public class ModositasParancs : IParancs
    {
        private string parameter;

        public string ParancsSzoveg => MagicValues.CommandTextModify;

        public string HasznalatiUtasitas => MagicValues.CommandTextModify + " parameter";

        public void ParameterBeallitas(string[] args)
        {
            parameter = args[1];
        }

        public string Vegrehajtas()
        {
            return string.Format(MagicValues.CommandResponseModify, parameter);

        }
    }
}