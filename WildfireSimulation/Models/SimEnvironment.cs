using WildfireSimulation.DTOs;
using WildfireSimulation.Enums;

namespace WildfireSimulation.Models
{
    public class SimEnvironment
    {
        public WeatherAudit WeatherHistory { get; set; }
        public List<List<TerrainAgent>> Terrain { get; set; }
        public int TurnCount { get; set; }

        /// <summary>
        /// Updates the history of the weather events based on the user request.
        /// </summary>
        /// <param name="request"></param>
        public void WeatherEvents (UserWeatherRequest request)
        {
            if (request.RandomLighting)
            {
                var lightning = new LightningEvent();
                //lightning.Turn 
            }
            else
            {
                WeatherHistory.lightningEvents.Add(request.LightningEvent);
            }

            if (request.RandomRain)
            {

            }
            else
            {
                WeatherHistory.RainEvents.Add(request.RainEvent);
            }

            if (request.RandomWind)
            {

            }
            else
            {
                WeatherHistory.WindEvents.Add(request.WindEvent);
            }
        }

        /// <summary>
        /// Executes the updates to the agents attributes and spreads fire to adjacent spaces.
        /// </summary>
        public void ExecuteTurn()
        {
            Random rnd = new Random();

            //check for lightning
            //update weather audit so that the latest entry is valid
            

            for (int x = 0; x < Terrain.Count; x++)
            {
                for (int y = 0; y < Terrain[x].Count; y++)
                {
                    var fireSpreadProbability = Terrain[x][y].SpreadFireToAdjacentAgent();
                    if (WeatherHistory.WindEvents[TurnCount].Direction == DirectionEnum.None)
                    {
                        //above
                        if(rnd.NextDouble() > fireSpreadProbability)
                        {
                            Terrain[x][y + 1].FireIgnition();
                        }
                        //right
                        if (rnd.NextDouble() > fireSpreadProbability)
                        {
                            Terrain[x + 1][y].FireIgnition();
                        }
                        //down
                        if (rnd.NextDouble() > fireSpreadProbability)
                        {
                            Terrain[x][y - 1].FireIgnition();
                        }
                        //left
                        if (rnd.NextDouble() > fireSpreadProbability)
                        {
                            Terrain[x - 1][y].FireIgnition();
                        }
                    }
                    //add checks for wind, make a switch statement

                    Terrain[x][y].FuelAmountUpdate();
                    Terrain[x][y].AgentOnFireUpdate();
                    Terrain[x][y].FireStateUpdate();

                    Terrain[x][y].Rainfall(WeatherHistory.RainEvents[TurnCount].Rainfall);
                }
            }

            
        }

        /// <summary>
        /// Increments the turncount
        /// </summary>
        public void Turn()
        {
            TurnCount++;
        }

    }
}
