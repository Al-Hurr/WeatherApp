using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class City
    {
        public string Name { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }
    }
}
