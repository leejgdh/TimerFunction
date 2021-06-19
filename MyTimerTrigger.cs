using System;
using leejgdh.Function.Options;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace leejgdh.Function
{
    public class MyTimerTrigger
    {

        private readonly ShopeeOption _shopeeOption;

        public MyTimerTrigger(
            IOptionsSnapshot<ShopeeOption> shopeeOption
        )
        {
            _shopeeOption = shopeeOption.Value;
        }

        [FunctionName("MyTimerTrigger")]
        public void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            log.LogInformation($"Shopee Options {_shopeeOption.PartnerId} / {_shopeeOption.SecretKey}");

        }
    }
}
