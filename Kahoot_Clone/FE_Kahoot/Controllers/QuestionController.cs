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
    public class QuestionController : ControllerBase
    {
        private IQuestionRepository repository = new QuestionRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Question>> GetUsers() => repository.GetQuestions();

        [HttpGet("id")]
        public ActionResult<Question> GetQuestionByID(int id) => repository.GetQuestion(id);

        [HttpGet("GameId={gameId}")]
        public ActionResult<IEnumerable<Question>> GetQuestionsByGameId(int gameId) => repository.GetQuestionsByGameID(gameId);

        [HttpPost]
        public IActionResult SaveQuestion(QuestionDTO questionDTO)
        {
            var newQuestion = new Question
            {
                QuestionContent = questionDTO.QuestionContent,
                Type = questionDTO.Type,
                Point = questionDTO.Point,
                TimeLimit = questionDTO.TimeLimit,
                GameId = questionDTO.GameId
            };
            repository.SaveQuestion(newQuestion);
            return Ok(newQuestion);
        }

        //[HttpPut("id")]
        //public IActionResult UpdateUser(int userId, RegisterDTO user)
        //{
        //    var newUser = new User
        //    {
        //        FullName = user.FullName,
        //        Email = user.Email,
        //        AccountId = user.AccountId,
        //        Dob = user?.Dob,
        //        Image = user?.Image,
        //        Description = user?.Description,
        //        Phone = user.Phone,
        //        Gender = user?.Gender
        //    };
        //    repository.SaveUser(newUser);
        //    return Ok(newUser);
        //}
    }
}
