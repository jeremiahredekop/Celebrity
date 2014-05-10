using System;

namespace Celebrity
{
    public static class DispatcherExtensions
    {
        public static ActorWrapper<T> ForActor<T>(this IDispatcher dispatcher, Guid key) where T : class
        {
            return new ActorWrapper<T>(dispatcher,key);
        }
    }
}