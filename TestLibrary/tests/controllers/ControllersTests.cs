using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.Controllers;
using myapi.data;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;


namespace myapi.tests.Controllers
{ 
    public class ControllerTests
    {
        private WeatherContext _context;

        [Fact]
        public void CanGetWeatherEvents()
        {
            _context = CreateAndSeedContext();
            using (var controller = new WeatherController(_context, null))
            {
                var results = controller.Get();
                Assert.Equal(7, results.Count());
            }
        }
        [Fact]
        public void CanGetWeatherEventsFail()
        {
            _context = CreateAndSeedContext();
            using (var controller = new WeatherController(_context, null))
            {
                var results = controller.Get();
                Assert.Equal(70, results.Count());
            }
        }
        [Fact]
        public void CanGetWeatherEventsFilteredByDate()
        {
            _context = CreateAndSeedContext();
            using (var controller = new WeatherController(_context, null))
            {
                var results = controller.Get(DateTime.Now.Date);
                Assert.Equal(2, results.Count());
            }
        }

        private WeatherContext CreateAndSeedContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherContext>();
            optionsBuilder.UseInMemoryDatabase();

            var context = new WeatherContext(optionsBuilder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.WeatherEvents.AddRange(BuildWeatherEvents());
            context.SaveChanges();
            return context;

        }
        private List<WeatherEvent> BuildWeatherEvents()
        {
            Console.WriteLine("seeding the inmemory database");
            var events = new List<WeatherEvent>
            {
                WeatherEvent.Create(DateTime.Now,WeatherType.Sun,true),
                WeatherEvent.Create(DateTime.Now.AddDays(-1),WeatherType.Snow,true),
                WeatherEvent.Create(DateTime.Now.AddDays(-2),WeatherType.Rain,false),
                WeatherEvent.Create(DateTime.Now.AddDays(-3),WeatherType.Sleet,false),
                WeatherEvent.Create(DateTime.Now.AddDays(-4),WeatherType.Hail,false),
                WeatherEvent.Create(DateTime.Now.AddDays(-5),WeatherType.Snow,false),
                WeatherEvent.Create(DateTime.Now,WeatherType.Rain,false) 
            };
            return events;
        }
    } 
}
