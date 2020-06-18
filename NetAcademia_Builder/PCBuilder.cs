using System;
using System.Collections.Generic;

namespace NetAcademia_Builder
{
    public class PCBuilder
    {
        private Computer computer;

        public PCBuilder()
        {
        }

        public void CreatePC()
        {
            computer = new Computer();
        }

        public void BuildPC()
        {
            BuildHardware();
            InstallOS();
            InstallApps();
        }

        private void InstallApps()
        {
            computer.Applications = new List<string>() { "MSSQL", "VisualStudio", "VLC Player" };
        }

        private void InstallOS()
        {
            computer.OS = OS.Windows10;
        }

        private void BuildHardware()
        {
            computer.Processor = Processor.x64;
            computer.HDD = 120;
            computer.HasDVD = true;
            computer.HasSoundCard = true;
            computer.HasUSB = true;
        }

        public Computer GetPC()
        {
            return computer;
        }
    }
}