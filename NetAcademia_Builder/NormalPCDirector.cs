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
    public class NormalPCDirector : AbstractPCDirector
    {
        public NormalPCDirector(AbstractPCBuilder pcBuilder)
            : base(pcBuilder)
        { }

        public override void BuildPC()
        {
            pcBuilder.CreatePC();
            pcBuilder.BuildHardware();
            pcBuilder.InstallOS();
            pcBuilder.InstallApps();
        }
    }
}
