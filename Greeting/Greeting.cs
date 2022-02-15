using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting
{
    public class Greeting : IGreeting
    {
        public string Greet(params string[] name)
        {
            if (name is null)
                return "Hello, my friend.";

            var lowerNamesString = ChainNamesLower(name.Where(n => !IsUppercase(n)));
            var upperNamesString = ChainNamesUpper(name.Where(n => IsUppercase(n)));

            var greeting = "";

            if (!string.IsNullOrEmpty(lowerNamesString))
                greeting = $"Hello, {lowerNamesString}.";

            if (!string.IsNullOrEmpty(upperNamesString))
            {
                if (!string.IsNullOrEmpty(lowerNamesString))
                    greeting += " AND ";

                greeting += $"HELLO {upperNamesString}!";
            }

            return greeting;
        }

        private string ChainNamesLower(IEnumerable<string> names) => ChainNames(names, "and");
        private string ChainNamesUpper(IEnumerable<string> names) => ChainNames(names, "AND");

        private string ChainNames(IEnumerable<string> names, string lastSeparator)
        {
            if (!names.Any())
                return "";

            if (names.Count() == 1)
                return names.First();

            var allNamesMinusLast = names.Take(names.Count() - 1);
            return $"{string.Join(", ", allNamesMinusLast)} {lastSeparator} {names.Last()}";
        }

        private bool IsUppercase(string str) => str.Equals(str.ToUpper());
    }
}
