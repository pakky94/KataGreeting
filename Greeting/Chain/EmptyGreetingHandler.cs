using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Chain
{
    public class EmptyGreetingHandler : AbstractGreetingHandler
    {
        public override string Handle(params string[] names)
        {
            if (names is null || !names.Any())
                return "Hello, my friend.";

            return base.Handle(names);
        }
    }
}
