namespace WildfireSimulation.Models
{
    public class WeatherAudit
    {
        public List<LightningEvent> lightningEvents {  get; set; }
        public List<WindEvent> WindEvents { get; set; }
        public List<RainEvent> RainEvents { get; set; }
    }
}
