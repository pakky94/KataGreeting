using System.Collections.Generic;
using System.Linq;

namespace Greeting.NamesPreprocessors
{
    public class EmptyNamesFilter : AbstractNamesPreprocessor
    {
        public EmptyNamesFilter() : base() { }
        public EmptyNamesFilter(INamesPreprocessor inner) : base(inner) { }

        public override IEnumerable<string> Process(IEnumerable<string> names) =>
            InnerProcess(names).Where(n => !string.IsNullOrWhiteSpace(n));
    }
}
