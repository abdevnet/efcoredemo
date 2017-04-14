using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myapi.data
{
    public class WeatherDataRepository
    {
        WeatherContext _context;
        public WeatherDataRepository(WeatherContext context)
        {
            _context = context;
        }
    }
}
