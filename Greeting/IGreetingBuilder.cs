using System.Collections.Generic;

namespace Greeting
{
    public interface IGreetingBuilder
    {
        public string Greet(IEnumerable<string> names);
    }
}
