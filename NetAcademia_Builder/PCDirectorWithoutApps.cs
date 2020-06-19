using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Builder
{
    public class PCDirectorWithoutApps : AbstractPCDirector
    {
        public PCDirectorWithoutApps(AbstractPCBuilder pcBuilder)
            : base(pcBuilder)
        { }

        public override void BuildPC()
        {
            pcBuilder.BuildHardware();
            pcBuilder.InstallOS();
        }
    }
}
