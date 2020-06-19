using System.Collections.Generic;

namespace NetAcademia_Builder
{
    /// <summary>
    /// Az osszeszereles alacsonyszintu lepeseinek az osztalya
    /// </summary>
    public abstract class AbstractPCBuilder
    {
        protected Computer computer;

        public void CreatePC()
        {
            computer = new Computer();
        }

        public abstract void InstallApps();
        public abstract void InstallOS();
        public abstract void BuildHardware();

        public Computer GetPC()
        {
            return computer;
        }
    }
}