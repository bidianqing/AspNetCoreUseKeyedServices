using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreUseKeyedServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(
        INotifierFactory notifierFactory
        //[FromKeyedServices("sms")] INotifier smsNotifier
        ) : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            /*
            var keyedProvider = HttpContext.RequestServices as IKeyedServiceProvider;
            var notifier = keyedProvider!.GetRequiredKeyedService<INotifier>("sms");
            await notifier.SendAsync("测试消息");
            //*/

            var notifier = notifierFactory.Get("email");

            await notifier.SendAsync("测试消息");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
