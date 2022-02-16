using Greeting.NamesPreprocessors;
using System;

namespace Greeting
{
    class Program
    {
        static void Main(string[] names)
        {
            var greeter = new Greeting(new EmptyNamesFilter(new NamesSplitter()));
            var result = greeter.Greet(names);
            Console.WriteLine(result);
        }
    }
}
