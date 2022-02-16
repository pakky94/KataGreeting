using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Chain
{
    public class OneNameGreetingHandler : AbstractGreetingHandler
    {
        private readonly string _greetingStart;
        private readonly string _greetingEnd;

        public OneNameGreetingHandler(string greetingStart, string greetingEnd)
        {
            _greetingStart = greetingStart;
            _greetingEnd = greetingEnd;
        }

        public override string Handle(params string[] names)
        {
            if (names.Length == 1)
                return $"{_greetingStart}{names[0]}{_greetingEnd}";

            return base.Handle(names);
        }
    }
}
