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
            //var builder1 = new PCBuilderForWindows();
            //builder1.CreatePC();
            //builder1.BuildPC();
            //var computer1 = builder1.GetPC();

            //computer1.Display();

            //var builder2 = new PCBuilderForLinux();
            //builder2.CreatePC();
            //builder2.BuildPC();
            //var computer2 = builder2.GetPC();

            var director = new NormalPCDirector(new PCBuilderForWindows());

            director.BuildPC();
            var computer = director.GetPC();

            computer.Display();

            Console.ReadLine();
        }

    }
}
