using WildfireSimulation.Enums;
using WildfireSimulation.Models;

namespace WildfireSimulation.Services
{
    public class ValidationService
    {
        //Tests the probability for the fire to spread to adjacent agents
        public double SpreadFireChanceTest(Terrain terrain)
        {
            return terrain.SpreadFireToAdjacentAgent();
        }

        //tests to ensure the fire state matches the state of the attributes in the terrain
        public FireStateEnum FireStateTest(Terrain terrain)
        {
            terrain.FireStateUpdate();
            return terrain.FireState;
        }

        //Tests the percentage of the agent on fire change 
        public double AgentOnFireTest(Terrain terrain)
        {
            terrain.AgentOnFireUpdate();
            return terrain.AgentOnFirePercentage;
        }

        //Tests the percentage of fuel reamining in the agent
        public double FuelAmountTest(Terrain terrain)
        {
            terrain.FuelAmountUpdate();
            return terrain.PercentageOfFuel;
        }

        //Returns the terrain to ensure proper values are being set
        public Terrain TerrainValues(TerrainTypesEnum type)
        {
            return new Terrain(type);
        }

        


    }
}
