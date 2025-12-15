using System.ComponentModel.DataAnnotations.Schema;

namespace WebApirestful.Models 
{
    [Table("CitiesWeather")]
    public class WeatherCast
    {
        public int id { get; set; }
        public string city_name { get; set; }
        public DateOnly update_date { get; set; }
        public int temperature { get; set; }
   
    }
}