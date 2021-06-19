using leejgdh.Function.Options;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

[assembly: FunctionsStartup(typeof(leejgdh.Function.Startup))]

namespace leejgdh.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();


            builder.Services.Configure<ShopeeOption>(config.GetSection("Shopee"));

            //builder.Services.AddOptions<ShopeeOption>()
            //.Configure<IConfiguration>((settings, configuration) =>
            //{
            //    configuration.GetSection("Shopee").Bind(settings);
            //});

            //var apiConfig = new WeatherApiConfig();
            //config.Bind(nameof(WeatherApiConfig), apiConfig);

            //builder.Services.AddSingleton(apiConfig);
            //builder.Services.AddHttpClient();
        }
    }
}