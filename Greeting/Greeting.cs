using Greeting.NamesPreprocessors;
using System.Linq;

namespace Greeting
{
    public class Greeting : IGreeting
    {
        private readonly IGreetingBuilder _greetingBuilder;
        private readonly INamesPreprocessor _namesPreprocessor;
        public Greeting(INamesPreprocessor namesPreprocessor, IGreetingBuilder greetingBuilder)
        {
            _namesPreprocessor = namesPreprocessor;
            _greetingBuilder = greetingBuilder;
        }

        public string Greet(params string[] name) =>
            _greetingBuilder.Greet(_namesPreprocessor.Process(name ?? Enumerable.Empty<string>()));
    }
}
