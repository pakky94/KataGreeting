using NUnit.Framework;
using Moq;
using Greeting.Chain;

namespace Greeting.Test
{
    public class NullHandlerTests
    {
        private AbstractGreetingHandler _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new EmptyGreetingHandler();
        }

        [Test]
        public void Should_Handle_Null_Name()
        {
            var expected = "Hello, my friend.";
            var actual = _sut.Handle(null);

            Assert.AreEqual(expected, actual);
        }
    }
}
