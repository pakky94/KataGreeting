using NUnit.Framework;
using Greeting.IOC;
using Greeting.NamesPreprocessors;

namespace Greeting.Test
{
    public class IOCTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void TestGetCalculator()
        {
            var greeter = Container.GetService<IGreeting>();
            Assert.IsNotNull(greeter);
        }

        [Test]
        public void TestGetValidator()
        {
            var preprocessor = Container.GetService<INamesPreprocessor>();
            Assert.IsNotNull(preprocessor);
        }

        [Test]
        public void TestGetValidCalculator()
        {
            var greeter = Container.GetService<IGreeting>();
            Assert.IsInstanceOf<Greeting>(greeter);
        }

    }
}
