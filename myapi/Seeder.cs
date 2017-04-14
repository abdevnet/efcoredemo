using System;
using System.Collections.Generic;
using System.Linq;
using myapi.data;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace myapi
{
    public static class Seeder
    {
        public static void Seedit(string jsonData,
            IServiceProvider serviceProvider)
        {
            List<WeatherEvent> events = JsonConvert.DeserializeObject<List<WeatherEvent>>(jsonData);

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<WeatherContext>();
                if (!context.WeatherEvents.Any())
                {
                    context.AddRange(events);
                    context.SaveChanges();
                }
            }
        }
    }
}