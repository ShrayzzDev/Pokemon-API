﻿using DTO;
using DTOExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace PokemonAPI.Controllers
{
    [ApiController]
    [Route("move")]
    [EnableCors("AllowSpecificOrigins")]
    public class MoveController : Controller
    {

        private readonly ILogger<MoveController> _logger;

        private readonly IMoveService<Move> _moveService;

        public MoveController(IMoveService<Move> moveService,
                              ILogger<MoveController> logger
            )
        {
            _moveService = moveService;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}/")]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> GetMoveById(int id)
        {
            _logger.LogInformation($"{DateTime.Now} | An user is trying to retrive the move of id {id}");
            MoveDTO? move;
            try
            {
                move = (await _moveService.GetMoveById(id))?.ToDTO();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now} | Unexpected exception catched when requesting move of id {id}: {ex.Message}");
                return Problem("An unexpected exception was catched. \nPlease send a ticket on the GitHub repository with the (rough) time this request was made. \n If you ran this yourself, please include logs.");
            }

            if (move == null)
            {
                _logger.LogInformation($"{DateTime.Now} | The API was unable to find move of id {id}");
                return NotFound("The move was not found.");
            }

            _logger.LogInformation($"{DateTime.Now} | Move sucessfully found.");
            return Ok(move);
        }

        [HttpGet]
        [Route("{pokId}/learns/{moveId}")]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> WhichLevelPokemonLearns(int pokId, int moveId)
        {
            _logger.LogInformation($"{DateTime.Now} | An user is trying to retrive the level the pokemon of id {pokId} learns the move of id {moveId}");
            int level;
            try
            {
                level = await _moveService.GetLevelMoveLearned(pokId,moveId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now} | Unexpected exception catched when requesting the level the pokemon of id {pokId} learns the move of id {moveId}: {ex.Message}");
                return Problem("An unexpected exception was catched. \nPlease send a ticket on the GitHub repository with the (rough) time this request was made. \n If you ran this yourself, please include logs.");
            }

            if (level == -1)
            {
                _logger.LogInformation($"{DateTime.Now} | The API was unable to find if the pokemon of id {pokId} learns the move of id {moveId}");
                return NotFound("The pokemon can't learn this move");
            }

            _logger.LogInformation($"{DateTime.Now} | Level sucessfully found.");
            return Ok(level);
        }

        [HttpGet]
        [Route("{moveName}/{index}/{count}")]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> GetMovesByName(string moveName, int index, int count)
        {
            _logger.LogInformation($"{DateTime.Now} | An user is trying to retrive the move named {moveName}");
            IEnumerable<MoveDTO>? moves;
            if (index == 0)
            {
                _logger.LogWarning($"{DateTime.Now} | Page n°0 can not be retrieved");
                return BadRequest("Page 0 is invalid");
            }
            if (count == 0)
            {
                _logger.LogWarning($"{DateTime.Now} | You can't retrieve pages of size 0");
                return BadRequest("Pages of size 0 are invalid.");
            }
            try
            {
                moves = (await _moveService.GetMoveByName(moveName,index,count))?.ToDTOs();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now} | Unexpected exception catched when requesting the move {moveName}: {ex.Message}");
                return Problem("An unexpected exception was catched. \nPlease send a ticket on the GitHub repository with the (rough) time this request was made. \n If you ran this yourself, please include logs.");
            }

            if (moves == null)
            {
                _logger.LogInformation($"{DateTime.Now} | The API was unable to find moves named {moveName}");
                return NotFound("No move found.");
            }

            _logger.LogInformation($"{DateTime.Now} | Moves sucessfully found.");
            return Ok(moves);
        }
    }
}
