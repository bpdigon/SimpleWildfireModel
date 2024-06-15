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

        public SimEnvironment GenerateRandomTerrain(int simSize)
        {
            Random rnd = new Random();
            var env = new SimEnvironment();
            for (int x = 0; x < simSize; x++)
            {
                env.Terrain.Add(new TerrainList());
                for (int y = 0; y < simSize; y++)
                {
                    env.Terrain[x].Terrains.Add(new Terrain(rnd.Next(1, 7)));
                }
            }

            return env;
        }
    }
}
