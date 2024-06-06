using WildfireSimulation.Enums;

namespace WildfireSimulation.Models
{
    public class WindEvent : Event
    {
        public DirectionEnum Direction { get; set; }
        public int WindSpeed { get; set; }
    }
}
