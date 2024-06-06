namespace WildfireSimulation.Models
{
    public class UserWeatherRequest
    {
        public List<LightningEvent> LightningEvents { get; set; }
        public bool RandomLighting { get; set; }
        public WindEvent WindEvent { get; set; }
        public bool RandomWind { get; set; }
        public RainEvent RainEvent { get; set; }
        public bool RandomRain { get; set; }

    }
}
