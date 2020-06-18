using System;

namespace NetAcademia_Bridge2
{
    public abstract class AbstractSendWith
    {
        public AbstractSendWith()
        {
            Setup();
        }
        public abstract void Send(EmailMessage message);
        protected abstract void Setup();

        //Generikus megoldas
        public static T Factory<T>()
            where T : AbstractSendWith, new()
        {
            //var tmp = new T();
            //tmp.Setup();
#if DEBUG
            if (typeof(T) == typeof(SendWithExchange))
            {
                return new SendWithExchangeTest() as T;
            }
#endif
            return new T();
        }

        //Nem generikus megoldas
        //public static AbstractSendWith Factory(SendWithTypes type)
        //{
        //    switch (type)
        //    {
        //        case SendWithTypes.SendWith:
        //            return new SendWith();
        //        case SendWithTypes.SendWithExchange:
        //            return new SendWithExchange();
        //        case SendWithTypes.SendWithSenderGrid:
        //            return new SendWithSenderGrid();
        //        case SendWithTypes.SendWithMandrill:
        //            return new SendWithMandrill();
        //        default:
        //            throw new ArgumentOutOfRangeException(nameof(type));
        //    }
        //}

    }

    //public enum SendWithTypes
    //{
    //    SendWith,
    //    SendWithExchange,
    //    SendWithSenderGrid,
    //    SendWithMandrill

    //}
}