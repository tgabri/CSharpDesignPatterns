using System;
using System.Collections.Generic;
using System.Linq;

namespace NetAcademia_Command
{
    public class ParancsFeldolgozo
    {
        private List<IParancs> parancsLista;

        public ParancsFeldolgozo(List<IParancs> parancsLista)
        {
            this.parancsLista = parancsLista;
        }
        public string Vegrehajtas(string[] args)
        {
            var parancsSzoveg = args[0];

            var parancs = parancsLista.SingleOrDefault(p => p.ParancsSzoveg == parancsSzoveg);
            if (parancs == null)
            {
                return MagicValues.CommandResponseInvalid;
            }
            parancs.ParameterBeallitas(args);
            return parancs.Vegrehajtas();
        }
    }
}