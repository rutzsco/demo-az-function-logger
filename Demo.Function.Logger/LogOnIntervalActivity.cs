using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Demo.Function.Logger
{
    public static class LogOnIntervalActivity
    {
        [FunctionName("LogOnIntervalActivity")]
        public static void Run([TimerTrigger("*/10 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            log.LogInformation($"Executing Logic");

            var rand = new Random();
            var value =  rand.Next(0, 10);
            if (value == 3 || value == 6)
            {
                log.LogError($"An error occured!");
            }
            else 
            {
                log.LogInformation($"Executing Succeded");
            }
        }
    }
}
