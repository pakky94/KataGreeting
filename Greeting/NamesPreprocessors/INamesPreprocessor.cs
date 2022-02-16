using System.Collections.Generic;

namespace Greeting.NamesPreprocessors
{
    public interface INamesPreprocessor
    {
        public IEnumerable<string> Process(IEnumerable<string> names);
    }
}
