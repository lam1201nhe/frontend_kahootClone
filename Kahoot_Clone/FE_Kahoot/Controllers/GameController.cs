using BusinessObjects.Models;
using DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.impl;

namespace FE_Kahoot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IGameRepository repository = new GameRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetGames() => repository.GetGames();

        [HttpGet("Codes")]
        public ActionResult<List<string>> GetListCode() => repository.GetListCode();

        [HttpGet("pincode")]
        public ActionResult<Game> GetGameByCodePin(string pincode) => repository.GetGameByCodePin(pincode);

        [HttpPost]
        public IActionResult SaveGame(GameDTO gameDTO)
        {
            Game newGame = new Game
            {
                Name = gameDTO.Name,
                PinCode = gameDTO.PinCode,
                UserId = gameDTO.UserId,
                Publish = gameDTO.Publish
            };
            repository.SaveGame(newGame);
            return Ok(newGame);
        }

    }
}
