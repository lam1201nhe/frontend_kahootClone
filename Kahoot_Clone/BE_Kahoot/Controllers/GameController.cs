using BE_Kahoot.Utils;
using BusinessObjects.Models;
using DataTransfer;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace BE_Kahoot.Controllers
{
    public class GameController : Controller
    {
        private readonly HttpClient client = null;
        private string GameApiUrl = "";
        private string UserApiUrl = "";
        private string QuestionApiUrl = "";

        public GameController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            GameApiUrl = "http://localhost:5014/api/Game";
            UserApiUrl = "http://localhost:5014/api/User";
            QuestionApiUrl = "http://localhost:5014/api/Question";
        }

        [HttpGet]
        public IActionResult Create()
        {
            Random random = new Random();
            int codePin = random.Next(100000, 999999);
            if (TempData != null)
            {
                ViewData["SuccessMessage"] = TempData["SuccessMessage"];
                ViewData["ErrorMessage"] = TempData["ErrorMessage"];
            }

            ViewData["Pin"] = codePin;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GameDTO gameDTO)
        {
            //int userId = (int)HttpContext.Session.GetInt32("USERID");
            List<string> listCode = await ApiHandler.DeserializeApiResponse<List<string>>(GameApiUrl + "/Codes", HttpMethod.Get);
            string newCode = gameDTO.PinCode;
            foreach (var item in listCode)
            {
                if(item == newCode)
                {
                    Random random = new Random();
                    int codePin = random.Next(100000, 999999);
                    newCode = codePin.ToString();
                }
            }
            gameDTO.UserId = 1;
            await ApiHandler.DeserializeApiResponse(GameApiUrl, HttpMethod.Post, gameDTO);
            HttpContext.Session.SetString("CODE", newCode);
            return RedirectToAction("List");

        }

        [HttpGet]
        public async Task<IActionResult> List(int questionId)
        {
            string PinCode = HttpContext.Session.GetString("CODE");

            Game game = await ApiHandler.DeserializeApiResponse<Game>(GameApiUrl + "/pincode?pincode=" + PinCode, HttpMethod.Get);
            List<Question> listQuestions = await ApiHandler.DeserializeApiResponse<List<Question>>(QuestionApiUrl + "/GameId=" + game.GameId, HttpMethod.Get);
            Question question = await ApiHandler.DeserializeApiResponse<Question>(QuestionApiUrl + "/id?id=" + questionId, HttpMethod.Get);

            ViewData["Question"] = question;
            ViewData["PinCode"] = PinCode;

            return View(listQuestions);
        }

        [HttpGet]
        public async Task<IActionResult> ListGame()
        {
            List<string> listCode = await ApiHandler.DeserializeApiResponse<List<string>>(GameApiUrl + "/Codes", HttpMethod.Get);
            return View(listCode);
        }

        public IActionResult Transfer()
        {
            return RedirectToAction("List");
        }
    }
}
