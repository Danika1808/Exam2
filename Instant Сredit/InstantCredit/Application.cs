using Application;
using Application.Servises;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantCredit
{
    class Application
    {
        private static IConfiguration _configuration;

        public Application(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Startup(IServiceCollection service)
        {
            service.AddDbContext<AppDbContext>(
                options =>
                {
                    options.UseNpgsql(_configuration.GetConnectionString("dbConnectionString"));
                },
                ServiceLifetime.Transient
            );

            service.AddSingleton<Validator>();
            service.AddSingleton<ConvictedService>();
            service.AddSingleton(new OperatorService(_configuration));
            var provider = service.BuildServiceProvider();

            var creditAssessor = new CreditAssessor(provider.GetService<AppDbContext>(), provider.GetService<Validator>(), provider.GetService<OperatorService>(), provider.GetService<ConvictedService>());

            creditAssessor.Assess();
        }
    }
}
