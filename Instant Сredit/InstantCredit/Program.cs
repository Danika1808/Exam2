using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstantCredit
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();
            var application = new Application(builder);
            var services = new ServiceCollection();

            application.Startup(services);
        }
    }
}
