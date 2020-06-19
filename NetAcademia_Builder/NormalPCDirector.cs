using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Builder
{
    /// <summary>
    /// A letrehozas magasabb szintu vezerloje,
    /// a builder lepeseit iranyitja
    /// </summary>
    public class NormalPCDirector
    {
        private AbstractPCBuilder pcBuilder;

        public NormalPCDirector(AbstractPCBuilder pcBuilder)
        {
            this.pcBuilder = pcBuilder;
        }

        public void BuildPC()
        {
            pcBuilder.CreatePC();
            pcBuilder.BuildHardware();
            pcBuilder.InstallOS();
            pcBuilder.InstallApps();
        }

        public Computer GetPC()
        {
            return pcBuilder.GetPC();
        }
    }
}
