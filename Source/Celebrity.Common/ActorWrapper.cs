using System;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Celebrity
{
    public class ActorWrapper<T> where T : class
    {
        private readonly T _proxy;

        public ActorWrapper(IDispatcher dispatcher, Guid key)
        {
            _proxy = new ProxyGenerator()
                .CreateInterfaceProxyWithoutTarget<T>(new Interceptor(dispatcher, key));
        }

        public Task InvokeAsync(Action<T> invoker)
        {
            //hack for now - need to listen for a response
            return new TaskFactory().StartNew(() =>
            {
                Thread.Sleep(5000);
                invoker(_proxy);
            });
        }
    }
}