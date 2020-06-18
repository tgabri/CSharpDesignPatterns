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
            var computer = new Computer();
            computer.Processor = Processor.x64;
            computer.OS = OS.Windows10;
            computer.HDD = 120;
            computer.HasDVD = true;
            computer.HasSoundCard = true;
            computer.HasUSB = true;
            computer.Applications = new List<string>() { "MSSQL", "VisualStudio", "VLC Player" };
            computer.Display();

            Console.ReadLine();
        }
    }
}
