namespace WildfireSimulation.Models
{
    public class Environment
    {
        public List<WeatherAudit> WeatherHistory { get; set; }
        public List<List<TerrainAgent>> Terrain { get; set; }
        public int TurnCount { get; set; }

        public Environment() 
        { 
            TurnCount = 0;
            WeatherHistory = new List<WeatherAudit>();
            Terrain = new List<List<TerrainAgent>>();
        }

        public void WeatherEvents (WeatherAudit weatherAudit)
        {

        }

        public void ExecuteTurn()
        {
            for (int x = 0; x < Terrain.Count; x++)
            {
                for (int y = 0; y < Terrain.Count; y++)
                {
                    //Terrain[x][y]
                }
            }
        }

    }
}
