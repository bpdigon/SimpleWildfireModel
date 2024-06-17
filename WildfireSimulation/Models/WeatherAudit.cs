namespace WildfireSimulation.Models
{
    public class WeatherAudit
    {
        public List<LightningEvent>? lightningEvents {  get; set; } = new List<LightningEvent>();
        public List<WindEvent>? WindEvents { get; set; } = new List<WindEvent>();
        public List<RainEvent>? RainEvents { get; set; } = new List<RainEvent>();
    }
}
