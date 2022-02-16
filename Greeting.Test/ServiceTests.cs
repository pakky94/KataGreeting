using Greeting.IOC;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Test
{
    public class ServiceTests
    {
        private IGreeting _sut;

        [SetUp]
        public void Setup()
        {
            _sut = Container.GetService<IGreeting>();
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
            var input = new string[] { "Andrea", "Giovanni", "Franco", "GIUSEPPE", "MARIO", "FRANCESCO" };
            var actual = _sut.Greet(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Multiple_Name_With_Mulitple_Upper_With_Splits()
        {
            var expected = "Hello, Andrea, Giovanni and Franco. AND HELLO GIUSEPPE, MARIO AND FRANCESCO!";
            var input = new string[] { "Andrea, Giovanni", "Franco, GIUSEPPE", "MARIO, FRANCESCO" };
            var actual = _sut.Greet(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
