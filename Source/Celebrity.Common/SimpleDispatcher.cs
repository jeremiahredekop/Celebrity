using System;

namespace Celebrity
{
    public class SimpleDispatcher : IDispatcher
    {
        private readonly IObserver<IMessage> _observer;

        public SimpleDispatcher(IObserver<IMessage> observer)
        {
            _observer = observer;
        }

        public void DispatchCommand(IMessage message)
        {
            _observer.OnNext(message);
        }
    }
}