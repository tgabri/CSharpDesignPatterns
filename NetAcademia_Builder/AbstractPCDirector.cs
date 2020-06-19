namespace NetAcademia_Builder
{
    public abstract class AbstractPCDirector
    {
        protected AbstractPCBuilder pcBuilder;

        public AbstractPCDirector(AbstractPCBuilder pcBuilder)
        {
            this.pcBuilder = pcBuilder;
            pcBuilder.CreatePC();
        }

        public abstract void BuildPC();

        public Computer GetPC()
        {
            return pcBuilder.GetPC();
        }
    }
}