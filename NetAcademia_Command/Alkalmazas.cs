using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Command
{
    public class Alkalmazas
    {
        public string Bevitel(string[] args)
        {
            if (args.Length == 0)
            {
                return HasznalatiUtasitas();
            }

            var feldolgozo = new ParancsFeldolgozo();

            return feldolgozo.Vegrehajtas(args);
        }

        public string HasznalatiUtasitas()
        {
            var hu = string.Format("Hasznalat: NetAcademia_Command[.exe] parancs parameterek{0}", Environment.NewLine);
            hu += string.Format(MagicValues.CommandTextNew + Environment.NewLine);
            hu += string.Format(MagicValues.CommandTextModify + " parameter" + Environment.NewLine);
            hu += string.Format(MagicValues.CommandTextDelete + " parameter");

            return hu;
        }
    }
}
