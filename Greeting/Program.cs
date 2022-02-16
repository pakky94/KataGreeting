using Greeting.IOC;
using System;

namespace Greeting
{
    class Program
    {
        static void Main(string[] names)
        {
            var greeter = Container.GetService<IGreeting>();
            var result = greeter.Greet(names);
            Console.WriteLine(result);
        }
    }
}
