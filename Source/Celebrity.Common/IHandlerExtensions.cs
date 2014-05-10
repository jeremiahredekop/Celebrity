using System;
using System.Reactive;

namespace Celebrity
{
    public static class IHandlerExtensions
    {
        public static void Wireup(this IHandler handler, IObservable<IMessage> observable)
        {
            observable.Subscribe(Observer.Create<IMessage>(handler.HandleCommand));
        }
    }
}