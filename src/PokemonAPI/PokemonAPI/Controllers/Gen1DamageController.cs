﻿using DTO.DamageParameters;
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
            DateTime start;
            start = DateTime.Now;
            _logger.LogInformation($"{DateTime.Now} | An user is trying to calculate damages");
            double damageValue;
            try
            {
                damageValue = await _damageCalculator.GetDamage(parameters.ToModel());
                Console.WriteLine(DateTime.Now - start);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now} | Unexpected exception catched when calculatating damages: {ex.Message}");
                return Problem("An unexpected exception was catched. Please send a ticket on the GitHub repository with the (rough) time this request was made.");
            }
            _logger.LogInformation($"{DateTime.Now} | Damage calculated successfully !");
            damageValue = damageValue < 1 ? 1 : (int)damageValue;
            Console.WriteLine(DateTime.Now - start);
            return Ok(damageValue);
        }
    }
}
