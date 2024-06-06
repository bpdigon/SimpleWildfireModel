﻿using WildfireSimulation.Enums;

namespace WildfireSimulation.Models
{
    public class TerrainAgent
    {
        public TerrainTypesEnum TerrainType { get; set; }
        public double AgentOnFirePercentage { get; set; }
        public FireStateEnum FireState { get; set; }
        public double WaterPercentage { get; set; }
        //public double FireSpreadRate { get; set; }
        public double PercentageOfFuel { get; set; }

        /// <summary>
        /// Returns the default values for the 
        /// </summary>
        public TerrainAgent(TerrainTypesEnum? terrain)
        {
            AgentOnFirePercentage = 0;
            FireState = FireStateEnum.NoFire;
            WaterPercentage = 0.0;
            
            switch (terrain){
                case TerrainTypesEnum.Sand:
                    TerrainType = TerrainTypesEnum.Sand;
                    PercentageOfFuel = 0.5;
                    break;
                case TerrainTypesEnum.Concrete:
                    TerrainType = TerrainTypesEnum.Concrete;
                    PercentageOfFuel = 0.0;
                    break;
                case TerrainTypesEnum.WetFlammableFuel:
                    TerrainType = TerrainTypesEnum.WetFlammableFuel;
                    PercentageOfFuel = 1.0;
                    WaterPercentage = 0.5;
                    break;
                case TerrainTypesEnum.DryFlammableFuel:
                    TerrainType = TerrainTypesEnum.DryFlammableFuel;
                    PercentageOfFuel = 1.0;
                    break;
                case TerrainTypesEnum.WetNonflammableFuel:
                    TerrainType = TerrainTypesEnum.WetNonflammableFuel;
                    PercentageOfFuel = 0.75;
                    WaterPercentage = 0.5;
                    break;
                case TerrainTypesEnum.DryNonflammableFuel:
                    TerrainType = TerrainTypesEnum.DryNonflammableFuel;
                    PercentageOfFuel = 0.75;
                    break;
                case TerrainTypesEnum.Water:
                    TerrainType = TerrainTypesEnum.Water;
                    PercentageOfFuel = 0.0;
                    WaterPercentage = 1.0;
                    break;
            }
        }

        /// <summary>
        /// Returns the percentage chance of catching fire to an adjacent agent;
        /// </summary>
        /// <returns></returns>
        public double SpreadFireToAdjacentAgent()
        {
            var perc = AgentOnFirePercentage * PercentageOfFuel;
            if (perc >= WaterPercentage)
            {
                perc -= WaterPercentage;
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

            if (PercentageOfFuel == 0)
            {
                FireState = FireStateEnum.NoFire;
            }
            else if (PercentageOfFuel <= 0.4 && FireState != FireStateEnum.NoFire)
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
            if (AgentOnFirePercentage * FireSpreadRateDictionary[FireState] > PercentageOfFuel)
            {
                PercentageOfFuel = 0;
            }
            else
            {
                PercentageOfFuel -=  AgentOnFirePercentage * Math.Abs(AgentOnFirePercentage);

            }
        }

        /// <summary>
        /// Updates the percentage amount of the agent on fire based on the fire state.
        /// </summary>
        public void AgentOnFireUpdate()
        {
            if(PercentageOfFuel + FireSpreadRateDictionary[FireState] > 1)
            {
                PercentageOfFuel = 1;
            }
            else if (PercentageOfFuel + FireSpreadRateDictionary[FireState] < 0)
            {
                PercentageOfFuel = 0;
            }
            else
            {
                PercentageOfFuel += FireSpreadRateDictionary[FireState];
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
