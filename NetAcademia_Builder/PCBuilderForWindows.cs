using System;
using System.Collections.Generic;

namespace NetAcademia_Builder
{
    public class PCBuilderForWindows : AbstractPCBuilder
    {

        public override void InstallApps()
        {
            computer.Applications = new List<string>() { "MSSQL", "VisualStudio", "VLC Player" };
        }

        public override void InstallOS()
        {
            computer.OS = OS.Windows10;
        }

        public override void BuildHardware()
        {
            computer.Processor = Processor.x64;
            computer.HDD = 120;
            computer.HasDVD = true;
            computer.HasSoundCard = true;
            computer.HasUSB = true;
        }
    }
}