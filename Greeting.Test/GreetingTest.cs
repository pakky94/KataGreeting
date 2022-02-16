using Greeting.NamesPreprocessors;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Greeting.Test
{
    public class GreetingTests
    {
        private IGreeting _sut;
        private Mock<IGreetingBuilder> _greetingBuilder;

        [SetUp]
        public void Setup()
        {
            var preprocessor = new Mock<INamesPreprocessor>();
            preprocessor.Setup(x => x.Process(It.IsAny<IEnumerable<string>>()))
                .Returns<IEnumerable<string>>(names => names);

            _greetingBuilder = new Mock<IGreetingBuilder>();

            _sut = new Greeting(preprocessor.Object, _greetingBuilder.Object);
        }

        [Test]
        public void Should_Handle_Null_Name()
        {
            _sut.Greet(null);
            _greetingBuilder.Verify(gb => gb.Greet(new string[0]));
        }

        [Test]
        public void Should_Handle_Empty_Array()
        {
            _sut.Greet(System.Array.Empty<string>());
            _greetingBuilder.Verify(gb => gb.Greet(new string[0]));
        }

        [Test]
        public void Should_Pass_Single_Name()
        {
            _sut.Greet("Andrea");
            _greetingBuilder.Verify(gb => gb.Greet(new string[] { "Andrea" }));
        }

        [Test]
        public void Should_Pass_Multiple_Names()
        {
            _sut.Greet("Andrea", "Giovanni", "Franco", "GIUSEPPE", "MARIO", "FRANCESCO");
            _greetingBuilder.Verify(gb => gb.Greet(new string[] { 
                "Andrea", "Giovanni", "Franco", "GIUSEPPE", "MARIO", "FRANCESCO" 
            }));
        }
    }
}