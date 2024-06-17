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

        public SimEnvironment TerrainUpdate(SimEnvironment env)
        {
            var newEnv = new SimEnvironment();
            for(int x = 0; x < env.Terrain.Count(); x++)
            {
                newEnv.Terrain.Add(new TerrainList());
                for (int y = 0; y < env.Terrain[x].Terrains.Count(); y++)
                {
                    newEnv.Terrain[x].Terrains.Add(new Terrain(env.Terrain[x].Terrains[y].TerrainType));
                    newEnv.Terrain[x].Terrains[y].FireState = env.Terrain[x].Terrains[y].FireState;
                }
            }

            return newEnv;
        }
    }
}
