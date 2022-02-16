using Greeting.NamesPreprocessors;
using NUnit.Framework;

namespace Greeting.Test
{
    public class EmptyNamesFilterTests
    {
        private INamesPreprocessor _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new EmptyNamesFilter();
        }

        [Test]
        public void Process_PassesAllValidInputs()
        {
            var input = new string[] { "Bob", "Charlie", "Dianne" };
            var expected = new string[] {"Bob", "Charlie", "Dianne"};

            var actual = _sut.Process(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Process_RemovesWhitespacesNames()
        {
            var input = new string[] { "Bob", "", " \n  ", "Dianne" };
            var expected = new string[] {"Bob", "Dianne"};

            var actual = _sut.Process(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
