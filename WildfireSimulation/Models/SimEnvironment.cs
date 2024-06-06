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
            Random rnd = new Random();

            if (request.RandomLighting)
            {
                var lightning = new LightningEvent()
                {
                    Turn = TurnCount,
                    xCoordiante = rnd.Next(0, Terrain.Count),
                    yCoordiante = rnd.Next(0, Terrain[0].Count),
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
                Terrain[WeatherHistory.lightningEvents[TurnCount].xCoordiante][WeatherHistory.lightningEvents[TurnCount].yCoordiante].FireIgnition();
            }

            for (int x = 0; x < Terrain.Count; x++)
            {
                for (int y = 0; y < Terrain[x].Count; y++)
                {
                    var fireSpreadProbability = Terrain[x][y].SpreadFireToAdjacentAgent();
                    switch (WeatherHistory.WindEvents[TurnCount].Direction)
                    {
                        case DirectionEnum.None:
                            //above
                            if (rnd.NextDouble() > fireSpreadProbability)
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
                            break;

                        case DirectionEnum.North:
                            if (rnd.NextDouble() > fireSpreadProbability)
                            {
                                int windDistance = (int)Math.Round((double)WeatherHistory.WindEvents[TurnCount].WindSpeed / 5.0) * 5;
                                Terrain[x][y + windDistance].FireIgnition();
                            }
                            break;
                        case DirectionEnum.West:
                            if (rnd.NextDouble() > fireSpreadProbability)
                            {
                                int windDistance = (int)Math.Round((double)WeatherHistory.WindEvents[TurnCount].WindSpeed / 5.0) * 5;
                                Terrain[x + windDistance][y].FireIgnition();
                            }
                            break;
                        case DirectionEnum.South:
                            if (rnd.NextDouble() > fireSpreadProbability)
                            {
                                int windDistance = (int)Math.Round((double)WeatherHistory.WindEvents[TurnCount].WindSpeed / 5.0) * 5;
                                Terrain[x][y - windDistance].FireIgnition();
                            }
                            break;
                        case DirectionEnum.East:
                            if (rnd.NextDouble() > fireSpreadProbability)
                            {
                                int windDistance = (int)Math.Round((double)WeatherHistory.WindEvents[TurnCount].WindSpeed / 5.0) * 5;
                                Terrain[x - windDistance][y].FireIgnition();
                            }
                            break;
                    }

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
