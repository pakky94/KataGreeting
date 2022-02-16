using System.Collections.Generic;
using System.Linq;

namespace Greeting.NamesPreprocessors
{
    public class EmptyInputDefault : AbstractNamesPreprocessor
    {
        public EmptyInputDefault() : base() { }
        public EmptyInputDefault(INamesPreprocessor inner) : base(inner) { }

        public override IEnumerable<string> Process(IEnumerable<string> names)
        {
            names = InnerProcess(names);
            return names.Any() ? names : new string[] { "my friend" };
        }
    }
}
