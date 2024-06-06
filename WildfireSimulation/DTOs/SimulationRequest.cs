using WildfireSimulation.Models;

namespace WildfireSimulation.DTOs
{
    public class SimulationRequest
    {
        public SimEnvironment Environment { get; set; }
        public UserWeatherRequest UserWeather { get; set; }
        public int? Turns { get; set; }
    }
}
