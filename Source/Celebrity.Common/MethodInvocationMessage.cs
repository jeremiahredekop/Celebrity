using System;
using System.Reflection;

namespace Celebrity
{
    public class MethodInvocationMessage : IMessage
	{
		public MethodInfo MethodInfo {get;set;}
		public Guid Key { get; set; }
		public object[] Args { get; set; }
	    public Guid CorrelationId { get; set; }
	}	
}
