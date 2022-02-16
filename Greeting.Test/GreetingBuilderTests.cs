using NUnit.Framework;

namespace Greeting.Test
{
    public class GreetingBuilderTests

    {
        private IGreetingBuilder _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new GreetingBuilder();
        }

        [Test]
        public void Should_Add_Greeting_To_Name()
        {
            var expected = "Hello, Andrea.";
            var actual = _sut.Greet(new string[] { "Andrea" });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Empty_Array()
        {
            var expected = "";
            var actual = _sut.Greet(System.Array.Empty<string>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Uppercase_Name()
        {
            var expected = "HELLO ANDREA!";
            var input = new string[] { "ANDREA" };
            var actual = _sut.Greet(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Two_Name()
        {
            var expected = "Hello, Andrea and Franco.";
            var input = new string[] { "Andrea", "Franco" };
            var actual = _sut.Greet(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Multiple_Name()
        {
            var expected = "Hello, Andrea, Franco and Giuseppe.";
            var input = new string[] { "Andrea", "Franco", "Giuseppe" };
            var actual = _sut.Greet(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Multiple_Name_With_Upper()
        {
            var expected = "Hello, Andrea and Franco. AND HELLO GIUSEPPE!";
            var input = new string[] { "Andrea", "Franco", "GIUSEPPE" };
            var actual = _sut.Greet(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Multiple_Name_With_Mulitple_Upper()
        {
            var expected = "Hello, Andrea, Giovanni and Franco. AND HELLO GIUSEPPE, MARIO AND FRANCESCO!";
            var input = new string[] { "Andrea", "Giovanni", "Franco", "GIUSEPPE", "MARIO", "FRANCESCO" };
            var actual = _sut.Greet(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
