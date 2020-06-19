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
            var builder = new PCBuilderForWindows();
            builder.CreatePC();
            builder.BuildPC();
            var computer = builder.GetPC();

            computer.Display();

            Console.ReadLine();
        }

    }
}
