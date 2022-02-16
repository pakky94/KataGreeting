using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Chain
{
    public abstract class AbstractGreetingHandler : IGreetingHandler
    {
        protected IGreetingHandler _next;

        public virtual string Handle(params string[] names) => _next is null ? string.Empty : _next.Handle(names);

        public IGreetingHandler SetNext(IGreetingHandler greetingHandler)
        {
            _next = greetingHandler;
            return greetingHandler;
        }
    }
}
