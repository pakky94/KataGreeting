﻿using NUnit.Framework;
using Moq;
using Greeting.Chain;

namespace Greeting.Test
{
    public class ManyNamesWithSomeUpperHandlerTests
    {
        private AbstractGreetingHandler _sut;

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<AbstractGreetingHandler>();
            mock.Setup(x => x.Handle(new string[] { "Andrea", "Franco", "GIUSEPPE" })).Returns("Hello, Andrea and Franco. AND HELLO GIUSEPPE!");
            _sut = mock.Object;
        }

        [Test]
        public void Should_Handle_Multiple_Name_With_Upper()
        {
            var expected = "Hello, Andrea and Franco. AND HELLO GIUSEPPE!";
            var actual = _sut.Handle("Andrea", "Franco", "GIUSEPPE");

            Assert.AreEqual(expected, actual);
        }
    }
}