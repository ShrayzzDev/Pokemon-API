using DTO;
using DTO.DamageParameters;
using DTOExtensions.DamageParameters;
using Microsoft.AspNetCore.Mvc;
using Model.DamageParameters;
using Services;

namespace PokemonAPI.Controllers
{
    [ApiController]
    [Route("damage/gen1")]
    public class Gen1DamageController : Controller
    {
        private ILogger<Gen1DamageController> _logger;

        private IDamageCalculator<Gen1DamageInformations> _damageCalculator;

        public Gen1DamageController(ILogger<Gen1DamageController> logger,
                                IDamageCalculator<Gen1DamageInformations> damageCalculator)
        {
            _logger = logger;
            _damageCalculator = damageCalculator;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateDamage([FromBody] Gen1DamageInformationsDTO parameters)
        {
            _logger.LogInformation($"{DateTime.Now} | An user is trying to calculate damages");
            (double, double) damageValues;
            try
            {
                damageValues = await _damageCalculator.GetDamage(parameters.ToModel());
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now} | Unexpected exception catched when calculatating damages: {ex.Message}");
                return Problem("An unexpected exception was catched. \nPlease send a ticket on the GitHub repository with the (rough) time this request was made. \n If you ran this yourself, please include logs.");
            }
            _logger.LogInformation($"{DateTime.Now} | Damage calculated successfully !");
            var result = new DamageResultDTO();
            result.MinRoll = damageValues.Item1 < 1 ? 1 : (int)damageValues.Item1;
            result.MaxRoll = damageValues.Item2 < 1 ? 1 : (int)damageValues.Item2;
            return Ok(result);
        }
    }
}
