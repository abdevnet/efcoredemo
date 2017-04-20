using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace myapi.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private WeatherContext _context;
        WeatherDataRepository _repo;

        public WeatherController(WeatherContext context, WeatherDataRepository services)
        {
            _context = context;
            _repo = services;
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<WeatherEvent> Get()
        {
            return _context.WeatherEvents.
                Include(w => w.Reactions).ToList();
        }

        //  api/weather/2016-07-23
        [HttpGet("{date}")]
        public IEnumerable<WeatherEvent> Get(DateTime date)
        {
            return _context.WeatherEvents.Where(w => w.Date.Date == date.Date).ToList();
        }
    }
}
