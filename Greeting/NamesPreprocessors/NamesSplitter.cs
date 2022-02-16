using System;
using System.Collections.Generic;
using System.Linq;

namespace Greeting.NamesPreprocessors
{
    public class NamesSplitter : AbstractNamesPreprocessor
    {
        public NamesSplitter() : base() { }
        public NamesSplitter(INamesPreprocessor inner) : base(inner) { }

        public override IEnumerable<string> Process(IEnumerable<string> names) => SplitNames(InnerProcess(names));

        private static List<string> SplitNames(IEnumerable<string> names) =>
            names.SelectMany(name => SplitName(name)).ToList();

        private static IEnumerable<string> SplitName(string name)
        {
            if (name.StartsWith('\"'))
            {
                if (!name.EndsWith('\"'))
                    throw new FormatException($"Invalid format for name: '{name}'");

                return new string[] { name.Trim('\"').Trim() };
            }
            return name.Split(',').Select(x => x.Trim());
        }
    }
}
