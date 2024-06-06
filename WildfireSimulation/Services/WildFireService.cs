using WildfireSimulation.DTOs;
using WildfireSimulation.Models;

namespace WildfireSimulation.Services
{
    public class WildFireService
    {
        public SimEnvironment ExecuteTurn(SimEnvironment env, UserWeatherRequest request)
        {
            env.Turn();
            env.WeatherEvents(request);
            env.ExecuteTurn();

            return env;
        }

        public SimEnvironment ExecuteXTurns(SimEnvironment env, UserWeatherRequest request, int turns)
        {
            for (int i = 0; i < turns; i++)
            {
                env.Turn();
                env.WeatherEvents(request);
                env.ExecuteTurn();
            }
            return env;
        }
    }
}
