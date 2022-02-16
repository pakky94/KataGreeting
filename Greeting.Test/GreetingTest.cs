using Greeting.NamesPreprocessors;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Greeting.Test
{
    public class GreetingTests
    {
        private IGreeting _sut;

        [SetUp]
        public void Setup()
        {
            var preprocessor = new Mock<INamesPreprocessor>();
            preprocessor.Setup(x => x.Process(It.IsAny<IEnumerable<string>>()))
                .Returns<IEnumerable<string>>(names => names);

            _sut = new Greeting(preprocessor.Object);
        }

        [Test]
        public void Should_Add_Greeting_To_Name()
        {
            var expected = "Hello, Andrea.";
            var actual = _sut.Greet("Andrea");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Null_Name()
        {
            var expected = "Hello, my friend.";
            var actual = _sut.Greet(null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Empty_Array()
        {
            var expected = "Hello, my friend.";
            var actual = _sut.Greet(System.Array.Empty<string>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Uppercase_Name()
        {
            var expected = "HELLO ANDREA!";
            var actual = _sut.Greet("ANDREA");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Two_Name()
        {
            var expected = "Hello, Andrea and Franco.";
            var actual = _sut.Greet("Andrea", "Franco");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Multiple_Name()
        {
            var expected = "Hello, Andrea, Franco and Giuseppe.";
            var actual = _sut.Greet("Andrea", "Franco", "Giuseppe");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Multiple_Name_With_Upper()
        {
            var expected = "Hello, Andrea and Franco. AND HELLO GIUSEPPE!";
            var actual = _sut.Greet("Andrea", "Franco", "GIUSEPPE");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Multiple_Name_With_Mulitple_Upper()
        {
            var expected = "Hello, Andrea, Giovanni and Franco. AND HELLO GIUSEPPE, MARIO AND FRANCESCO!";
            var actual = _sut.Greet("Andrea", "Giovanni", "Franco", "GIUSEPPE", "MARIO", "FRANCESCO");

            Assert.AreEqual(expected, actual);
        }
    }
}