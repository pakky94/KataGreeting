using Greeting.NamesPreprocessors;
using NUnit.Framework;
using System;

namespace Greeting.Test
{
    public class EmptyInputDefaultTests
    {
        private INamesPreprocessor _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new EmptyInputDefault();
        }

        [Test]
        public void Process_ReturnsPlaceholder_WhenInputIsEmpty()
        {
            var input = Array.Empty<string>();
            var expected = new string[] { "my friend" };

            var actual = _sut.Process(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
