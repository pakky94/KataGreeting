using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Greeting.NamesPreprocessors;

namespace Greeting.IOC
{
    public class Container
    {
        public static T GetService<T>() =>
            CreateHostBuilder().Services.GetService<T>();

        private static IHost CreateHostBuilder() =>
            Host
            .CreateDefaultBuilder()
            .ConfigureServices((_, services) =>
                services
                    .AddSingleton<IGreeting, Greeting>()
                    .AddSingleton<IGreetingBuilder, GreetingBuilder>()
                    .AddSingleton<INamesPreprocessor>(_ => new EmptyInputDefault(new EmptyNamesRemover(new NamesSplitter())))
            ).Build();
    }

}
