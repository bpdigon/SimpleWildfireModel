using Microsoft.AspNetCore.Mvc;
using WildfireSimulation.DTOs;
using WildfireSimulation.Models;
using WildfireSimulation.Services;

namespace WildfireSimulation.Controllers
{
    public class WildFire : ControllerBase
    {
        private readonly WildFireService _service;

        public WildFire()
        {
            _service = new WildFireService();
        }

        //one turn
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

        //x turns
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
    }
}
