using WildfireSimulation.Models;

namespace WildfireSimulation.DTOs
{
    public class UserWeatherRequest
    {
        public LightningEvent? LightningEvent { get; set; }
        public bool? RandomLighting { get; set; }
        public WindEvent? WindEvent { get; set; }
        public bool? RandomWind { get; set; }
        public RainEvent? RainEvent { get; set; }
        public bool? RandomRain { get; set; }

    }
}
