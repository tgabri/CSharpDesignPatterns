namespace NetAcademia_Adapter
{
    public interface IMessageService
    {
        void AddMessage(string to, string subject, string text);
        void SendMessages();
    }
}