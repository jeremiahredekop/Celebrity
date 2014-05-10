namespace Celebrity
{
    public interface IHandler
    {
        void HandleCommand(IMessage message);
    }
}