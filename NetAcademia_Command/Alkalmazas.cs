using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Command
{
    public class Alkalmazas
    {
        public List<IParancs> parancsLista = new List<IParancs>();

        public string Bevitel(string[] args)
        {

            parancsLista = new List<IParancs>(new IParancs[]
            {
                new UjParancs(),
                new ModositasParancs(),
                new TorlesParancs()
            });

            if (args.Length == 0)
            {
                return HasznalatiUtasitas();
            }

            var feldolgozo = new ParancsFeldolgozo(parancsLista);

            return feldolgozo.Vegrehajtas(args);
        }

        public string HasznalatiUtasitas()
        {
            var hu = string.Format("Hasznalat: NetAcademia_Command[.exe] parancs parameterek{0}", Environment.NewLine);
            foreach (var parancs in parancsLista)
            {
                hu += string.Format(parancs.HasznalatiUtasitas + Environment.NewLine);

            }
            return hu;
        }
    }
}
