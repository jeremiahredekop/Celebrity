using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using FluentAssertions;
using NUnit.Framework;

namespace Celebrity.Tests
{
    [TestFixture]
    internal class BasicTest
    {

        [Test]
        public void Test1()
        {
            var customerId = Guid.NewGuid();

            var customers = new Dictionary<Guid, object>()
            {
                {customerId, new Customer()}
            };

            var subject = new Subject<IMessage>();

            IDispatcher dispatcher = new SimpleDispatcher(subject);

            IHandler handler = new SimpleHandler(customers);
            handler.Wireup(subject);

            var task = dispatcher.ForActor<ICustomer>(customerId)
                .InvokeAsync(c => c.SetName("George"));

            task.Wait();

            ((Customer) customers[customerId]).Name.Should().Be("George");
        }


        public interface ICustomer
        {
            void SetName(string george);
        }

        public class Customer : ICustomer
        {
            public void SetName(string george)
            {
                Name = george;
            }

            public string Name { get; private set; }
        }
    }
}
