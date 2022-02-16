using System.Collections.Generic;
using System.Linq;

namespace Greeting.NamesPreprocessors
{
    public class EmptyNamesRemover : AbstractNamesPreprocessor
    {
        public EmptyNamesRemover() : base() { }
        public EmptyNamesRemover(INamesPreprocessor inner) : base(inner) { }

        public override IEnumerable<string> Process(IEnumerable<string> names) =>
            InnerProcess(names.Where(n => !string.IsNullOrWhiteSpace(n)));
    }
}
