namespace Celebrity
{
    public interface IDispatcher
	{
	    void DispatchCommand(IMessage message);
	}
}
