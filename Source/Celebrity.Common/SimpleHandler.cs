using System;
using System.Collections.Generic;

namespace Celebrity
{
    public class SimpleHandler : IHandler
    {

        private readonly IDictionary<Guid, object> _state;

        public SimpleHandler(IDictionary<Guid, object> state)
        {
            _state = state;
        }

        public void HandleCommand(IMessage message)
        {
            var command = ((MethodInvocationMessage)message);

            var myState = _state[command.Key];
            command.MethodInfo.Invoke(myState, command.Args);
        }
    }
}