using Microsoft.AspNetCore.Mvc;
using WildfireSimulation.DTOs;
using WildfireSimulation.Models;
using WildfireSimulation.Services;

namespace WildfireSimulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WildFireController : ControllerBase
    {
        private readonly WildFireService _service;

        public WildFireController()
        {
            _service = new WildFireService();
        }

        /// <summary>
        /// Execute one turn of the simulation
        /// </summary>
        /// <param name="sim"></param>
        /// <returns></returns>
        [HttpPut("Turn")]
        [ProducesResponseType(typeof(SimEnvironment), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ExecuteSimulationOneTurn([FromBody] SimulationRequest sim)
        {
            try
            {
                return Ok(_service.ExecuteTurn(sim.Environment, sim.UserWeather));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Executes x turns of the simulation
        /// </summary>
        /// <param name="sim"></param>
        /// <returns></returns>
        [HttpPut("XTurns")]
        [ProducesResponseType(typeof(SimEnvironment), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ExecuteSimulationXTurn([FromBody] SimulationRequest sim)
        {
            try
            {
                if(sim.Turns == null || sim.Turns == 0)
                {
                    return BadRequest("Amount of turns not valid");
                }
                return Ok(_service.ExecuteXTurns(sim.Environment, sim.UserWeather, (int)sim.Turns));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Generates a new set of random terrain. Will be disorganized and have lots of mismatching terrain types.
        /// The input is the length and height of the terrain space.
        /// </summary>
        /// <param name="sim"></param>
        /// <returns></returns>
        [HttpPut("GenerateTerrain")]
        [ProducesResponseType(typeof(SimEnvironment), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GenerateRanndomTerrain([FromBody] int simSize)
        {
            try
            {
                if (simSize == null || simSize == 0)
                {
                    return BadRequest("Simulation size is not valid.");
                }
                
                return Ok(_service.GenerateRandomTerrain(simSize));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Test")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }
    }
}
