using System.Collections.Generic;

namespace Greeting.NamesPreprocessors
{
    public abstract class AbstractNamesPreprocessor : INamesPreprocessor
    {
        private readonly INamesPreprocessor _inner;
        public AbstractNamesPreprocessor() { }
        public AbstractNamesPreprocessor(INamesPreprocessor inner) 
        {
            _inner = inner;
        }

        public abstract IEnumerable<string> Process(IEnumerable<string> names);

        protected IEnumerable<string> InnerProcess(IEnumerable<string> names) =>
            _inner?.Process(names) ?? names;
    }
}
