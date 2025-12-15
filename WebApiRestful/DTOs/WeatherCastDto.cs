namespace WebApirestful.DTOs 
{
    public class WeatherCastDto
    {
        public int id { get; set; }
        public string city_name { get; set; }
        public DateOnly update_date { get; set; }
        public int temperature { get; set; }
   
    }
}