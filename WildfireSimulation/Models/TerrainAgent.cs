using WildfireSimulation.Enums;

namespace WildfireSimulation.Models
{
    public class TerrainAgent
    {
        public TerrainTypesEnum TerrainType { get; set; }
        public double AgentOnFirePercentage { get; set; }
        public FireStateEnum FireState { get; set; }
        public double WaterPercentage { get; set; }
        public double FireSpreadRate { get; set; }
        public double PercentageOfFuel { get; set; }
        public double FuelAmount { get; set; }

        /// <summary>
        /// Returns the percentage chance of catching fire to an adjacent agent;
        /// </summary>
        /// <returns></returns>
        public double SpreadFireToAdjacentAgent()
        {
            var perc = AgentOnFirePercentage * FuelAmount;
            if (perc >= WaterPercentage)
            {
                perc = perc - WaterPercentage;
            }
            else 
            {
                perc = 0;
            }
            return perc;
        }

        /// <summary>
        /// A dictionary to map the firestate to the spread rate value
        /// </summary>
        public static Dictionary<FireStateEnum, double> FireSpreadRateDictionary = new Dictionary<FireStateEnum, double>
        {
            {FireStateEnum.NoFire, 0},
            {FireStateEnum.Ignition, 0.05 },
            {FireStateEnum.Growth, 0.015 },
            {FireStateEnum.FullyDeveloped, 0.25 },
            {FireStateEnum.Decay, -0.2 }
        };

        /// <summary>
        /// Checks the conditions required to update the fire state based on fuel and percentage on fire
        /// </summary>
        public void FireStateUpdate()
        {
            if (AgentOnFirePercentage >= 0.25)
            {
                FireState = FireStateEnum.Growth;
            }
            else if (AgentOnFirePercentage >= 0.6)
            {
                FireState = FireStateEnum.FullyDeveloped;
            }

            if (FuelAmount == 0)
            {
                FireState = FireStateEnum.NoFire;
            }
            else if (FuelAmount <= 0.4)
            {
                FireState = FireStateEnum.Decay;
            }

        }

        /// <summary>
        /// This method will check the conditions of the fire state and modify the amount of fuel.
        /// Will always reduce the FuelAmount
        /// </summary>
        public void FuelAmountUpdate()
        {
            if (AgentOnFirePercentage * FireSpreadRate > FuelAmount)
            {
                FuelAmount = 0;
            }
            else
            {
                FuelAmount -=  AgentOnFirePercentage * Math.Abs(AgentOnFirePercentage);

            }
        }

        /// <summary>
        /// Updates the percentage amount of the agent on fire based on the fire state.
        /// </summary>
        public void AgentOnFireUpdate()
        {
            if(FuelAmount + FireSpreadRateDictionary[FireState] > 1)
            {
                FuelAmount = 1;
            }
            else if (FuelAmount + FireSpreadRateDictionary[FireState] < 0)
            {
                FuelAmount = 0;
            }
            else
            {
                FuelAmount += FireSpreadRateDictionary[FireState];
            }
        }

        /// <summary>
        /// A method to set the ignition of a fire.
        /// </summary>
        public void FireIgnition()
        {
            FireState = FireStateEnum.Ignition;
        }

        /// <summary>
        /// A method to update the total amount of water within the agent.
        /// </summary>
        public void Rainfall(double rainfall)
        {
            if (rainfall + WaterPercentage > 1)
            {
                WaterPercentage = 1;
            }
            else
            {
                WaterPercentage += rainfall;
            }
        }

    }
}
