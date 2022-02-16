﻿using NUnit.Framework;
using Moq;
using Greeting.Chain;

namespace Greeting.Test
{
    public class TwoNamesHandlerTests
    {
        private AbstractGreetingHandler _sut;

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<AbstractGreetingHandler>();
            mock.Setup(x => x.Handle(new string[] { "Andrea", "Franco" })).Returns("Hello, Andrea and Franco.");
            _sut = mock.Object;
        }

        [Test]
        public void Should_Handle_Two_Name()
        {
            var expected = "Hello, Andrea and Franco.";
            var actual = _sut.Handle("Andrea", "Franco");

            Assert.AreEqual(expected, actual);
        }
    }
}