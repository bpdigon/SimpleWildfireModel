using WildfireSimulation.DTOs;
using WildfireSimulation.Enums;

namespace WildfireSimulation.Models
{
    public class SimEnvironment
    {
        public WeatherAudit WeatherHistory { get; set; }
        public List<TerrainList> Terrain { get; set; }
        //UPDATE THIS TO REPLACE THE TERRAIN LIST LIST BELOW
        //public List<List<Terrain>> Terrain { get; set; }
        public int TurnCount { get; set; }
        public SimEnvironment()
        {
            Terrain = new List<TerrainList>();  
            TurnCount = 0;
        }

        /// <summary>
        /// Updates the history of the weather events based on the user request.
        /// </summary>
        /// <param name="request"></param>
        public void WeatherEvents (UserWeatherRequest request)
        {
            Random rnd = new Random();

            if (request.RandomLighting)
            {
                var lightning = new LightningEvent()
                {
                    Turn = TurnCount,
                    xCoordiante = rnd.Next(0, Terrain.Count),
                    yCoordiante = rnd.Next(0, Terrain[0].Terrains.Count),
                    Radius = 1,
                    UserFlag = false
                };
                WeatherHistory.lightningEvents.Add(lightning);
            }
            else
            {
                WeatherHistory.lightningEvents.Add(request.LightningEvent);
            }

            if (request.RandomRain)
            {
                var rain = new RainEvent()
                {
                    Rainfall = rnd.Next(0, 100) / 1000,
                    Turn = TurnCount,
                    UserFlag = false
                };
                WeatherHistory.RainEvents.Add(rain);

            }
            else
            {
                WeatherHistory.RainEvents.Add(request.RainEvent);
            }

            if (request.RandomWind)
            {
                var direction = rnd.Next(0, 4);
                var windSpeed = rnd.Next(0, 25);
                var wind = new WindEvent()
                {
                    WindSpeed = windSpeed,
                    Turn = TurnCount,
                    UserFlag = false
                };
                switch (direction)
                {
                    case 0:
                        wind.Direction = DirectionEnum.None;
                        wind.WindSpeed = 0;
                        break;
                    case 1:
                        wind.Direction = DirectionEnum.North;
                        break;
                    case 2:
                        wind.Direction = DirectionEnum.West;
                        break;
                    case 3:
                        wind.Direction = DirectionEnum.South;
                        break;
                    case 4:
                        wind.Direction = DirectionEnum.East;
                        break;
                }
                WeatherHistory.WindEvents.Add(wind);
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
            if (!WeatherHistory.lightningEvents[TurnCount].EmptyEventFlag)
            {
                Terrain[WeatherHistory.lightningEvents[TurnCount].xCoordiante].Terrains[WeatherHistory.lightningEvents[TurnCount].yCoordiante].FireIgnition();
            }

            for (int x = 0; x < Terrain.Count; x++)
            {
                for (int y = 0; y < Terrain[x].Terrains.Count; y++)
                {
                    var fireSpreadProbability = Terrain[x].Terrains[y].SpreadFireToAdjacentAgent();
                    switch (WeatherHistory.WindEvents[TurnCount].Direction)
                    {
                        case DirectionEnum.None:
                            //above
                            if (rnd.NextDouble() > fireSpreadProbability)
                            {
                                Terrain[x].Terrains[y + 1].FireIgnition();
                            }
                            //right
                            if (rnd.NextDouble() > fireSpreadProbability)
                            {
                                Terrain[x + 1].Terrains[y].FireIgnition();
                            }
                            //down
                            if (rnd.NextDouble() > fireSpreadProbability)
                            {
                                Terrain[x].Terrains[y - 1].FireIgnition();
                            }
                            //left
                            if (rnd.NextDouble() > fireSpreadProbability)
                            {
                                Terrain[x - 1].Terrains[y].FireIgnition();
                            }
                            break;

                        case DirectionEnum.North:
                            if (rnd.NextDouble() > fireSpreadProbability)
                            {
                                int windDistance = (int)Math.Round((double)WeatherHistory.WindEvents[TurnCount].WindSpeed / 5.0) * 5;
                                Terrain[x].Terrains[y + windDistance].FireIgnition();
                            }
                            break;
                        case DirectionEnum.West:
                            if (rnd.NextDouble() > fireSpreadProbability)
                            {
                                int windDistance = (int)Math.Round((double)WeatherHistory.WindEvents[TurnCount].WindSpeed / 5.0) * 5;
                                Terrain[x + windDistance].Terrains[y].FireIgnition();
                            }
                            break;
                        case DirectionEnum.South:
                            if (rnd.NextDouble() > fireSpreadProbability)
                            {
                                int windDistance = (int)Math.Round((double)WeatherHistory.WindEvents[TurnCount].WindSpeed / 5.0) * 5;
                                Terrain[x].Terrains[y - windDistance].FireIgnition();
                            }
                            break;
                        case DirectionEnum.East:
                            if (rnd.NextDouble() > fireSpreadProbability)
                            {
                                int windDistance = (int)Math.Round((double)WeatherHistory.WindEvents[TurnCount].WindSpeed / 5.0) * 5;
                                Terrain[x - windDistance].Terrains[y].FireIgnition();
                            }
                            break;
                    }

                    

                    Terrain[x].Terrains[y].FuelAmountUpdate();
                    Terrain[x].Terrains[y].AgentOnFireUpdate();
                    Terrain[x].Terrains[y].FireStateUpdate();

                    Terrain[x].Terrains[y].Rainfall(WeatherHistory.RainEvents[TurnCount].Rainfall);
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
