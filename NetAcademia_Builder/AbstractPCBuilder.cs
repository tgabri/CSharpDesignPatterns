using System.Collections.Generic;

namespace NetAcademia_Builder
{
    public abstract class AbstractPCBuilder
    {
        protected Computer computer;

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

        public abstract void InstallApps();
        public abstract void InstallOS();
        public abstract void BuildHardware();

        public Computer GetPC()
        {
            return computer;
        }
    }
}