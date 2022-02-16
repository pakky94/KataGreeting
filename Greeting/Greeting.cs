using Greeting.NamesPreprocessors;
using System.Collections.Generic;
using System.Linq;

namespace Greeting
{
    public class Greeting : IGreeting
    {
        private readonly INamesPreprocessor _namesPreprocessor;
        public Greeting(INamesPreprocessor namesPreprocessor)
        {
            _namesPreprocessor = namesPreprocessor;
        }

        public string Greet(params string[] name)
        {
            if (name is null || name.Length == 0)
                return "Hello, my friend.";

            var names = _namesPreprocessor.Process(name);

            var lowerGreeting = BuildGreeting(names.Where(n => !IsUppercase(n)), "Hello, ", ".", " and ");
            var upperGreeting = BuildGreeting(names.Where(n => IsUppercase(n)), "HELLO ", "!", " AND ");

            return JoinGreetings(lowerGreeting, upperGreeting);
        }

        private static string BuildGreeting(IEnumerable<string> names, string start, string end, string lastSeparator) =>
            names.Any()
                ? $"{start}{names.JoinWithDifferentLastSeparator(", ", lastSeparator)}{end}"
                : string.Empty;

        private static string JoinGreetings(string lowerCaseGreeting, string upperCaseGreeting)
        {
            var bothGreetingsNotEmpty = !string.IsNullOrEmpty(lowerCaseGreeting) &&
                                        !string.IsNullOrEmpty(upperCaseGreeting);

            if (bothGreetingsNotEmpty)
                return $"{lowerCaseGreeting} AND {upperCaseGreeting}";
            else
                return $"{lowerCaseGreeting}{upperCaseGreeting}";
        }

        private static bool IsUppercase(string str) => str.All(char.IsUpper);
    }
}
