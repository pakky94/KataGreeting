using Greeting.NamesPreprocessors;
using NUnit.Framework;

namespace Greeting.Test
{
    public class NamesSplitterTests
    {
        private INamesPreprocessor _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new NamesSplitter();
        }

        [Test]
        public void Split_SplitsNamesCorrectly()
        {
            var input = new string[] { "Bob", "Charlie, Dianne" };
            var expected = new string[] {"Bob", "Charlie", "Dianne"};

            var actual = _sut.Process(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Split_IgnoresQuotedNames()
        {
            var input = new string[] { "Bob", "\"Charlie, Dianne\"" };
            var expected = new string[] {"Bob", "Charlie, Dianne"};

            var actual = _sut.Process(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
