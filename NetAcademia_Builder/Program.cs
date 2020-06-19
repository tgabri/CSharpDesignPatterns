using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Builder
{
    /// <summary>
    /// EPITO minta
    /// 
    /// Ennek a peldanak a lenyege, h egy szamitogep osszeszerelo uzem alkalmazasat irjuk meg
    /// vagyis kulonbozo konfiguracioink vannak es ezek letrehozasahoz keszitunk kodot
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var director1 = new PCDirectorWithApps(new PCBuilderForWindows());
            director1.BuildPC();
            var computer1 = director1.GetPC();

            computer1.Display();

            var director2 = new PCDirectorWithoutApps(new PCBuilderForLinux());
            director2.BuildPC();
            var computer2 = director2.GetPC();

            computer2.Display();

            Console.ReadLine();
        }

    }
}
