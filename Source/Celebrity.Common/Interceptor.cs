using System;
using Castle.DynamicProxy;

namespace Celebrity
{
    [Serializable]
    public class Interceptor : StandardInterceptor
    {
        private readonly IDispatcher _dispatcher;
        private readonly Guid _key;

        public Interceptor(IDispatcher dispatcher, Guid key)
        {
            _dispatcher = dispatcher;
            _key = key;
        }

        protected override void PerformProceed(IInvocation invocation)
        {
            _dispatcher.DispatchCommand(new MethodInvocationMessage
            {
                CorrelationId = Guid.NewGuid(),
                Key = _key,
                Args = invocation.Arguments,
                MethodInfo = invocation.Method
            });
        }
    }
}

