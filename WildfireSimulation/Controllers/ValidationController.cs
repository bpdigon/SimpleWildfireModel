using Microsoft.AspNetCore.Mvc;
using WildfireSimulation.DTOs;
using WildfireSimulation.Enums;
using WildfireSimulation.Models;
using WildfireSimulation.Services;


namespace WildfireSimulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        private readonly ValidationService _service;

        public ValidationController()
        {
            _service = new ValidationService();
        }
        /// <summary>
        /// Tests the probability for the fire to spread to adjacent agents
        /// </summary>
        /// <param name="terrain"></param>
        /// <returns></returns>
        [HttpPost("SpreadProbability")]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> TestSpreadProbabiilty([FromBody] Terrain terrain)
        {
            try
            {
                return Ok(_service.SpreadFireChanceTest((terrain)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// tests to ensure the fire state matches the state of the attributes in the terrain
        /// </summary>
        /// <param name="terrain"></param>
        /// <returns></returns>
        [HttpPost("FireState")]
        [ProducesResponseType(typeof(FireStateEnum), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> TestFireState([FromBody] Terrain terrain)
        {
            try
            {
                return Ok(_service.FireStateTest(terrain));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Tests the percentage of the agent on fire change 
        /// </summary>
        /// <param name="terrain"></param>
        /// <returns></returns>
        [HttpPost("PercentageOnFire")]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> TestPercentageOnFire([FromBody] Terrain terrain)
        {
            try
            {
                return Ok(_service.AgentOnFireTest(terrain));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Tests the percentage of fuel reamining in the agent
        /// </summary>
        /// <param name="terrain"></param>
        /// <returns></returns>
        [HttpPost("FuelRemaining")]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> TestFuelRemaining([FromBody] Terrain terrain)
        {
            try
            {
                return Ok(_service.FuelAmountTest(terrain));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns the terrain to ensure proper values are being set
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost("TerrainValues")]
        [ProducesResponseType(typeof(Terrain), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> TestTerrainValues([FromBody] TerrainTypesEnum type)
        {
            try
            {
                return Ok(_service.TerrainValues(type));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
