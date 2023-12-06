using BE_Kahoot.Utils;
using BusinessObjects.Models;
using DataTransfer;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace BE_Kahoot.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient client = null;
        private string AccountApiUrl = "";
        private string UserApiUrl = "";

        public UserController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            AccountApiUrl = "http://localhost:5014/api/Account";
            UserApiUrl = "http://localhost:5014/api/User";
        }

        [HttpGet]
        public IActionResult Profile()
        {
            int userId = (int)HttpContext.Session.GetInt32("USERID");
            if (userId == 0)
            {
                TempData["ErrorMessage"] = "You have to login the Kahoot System";
                return RedirectToAction("Index", "Home");
            }

            if (TempData != null)
            {
                ViewData["ErrorMessage"] = TempData["ErrorMessage"];
                ViewData["SuccessMessage"] = TempData["SuccessMessage"];
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateProfile()
        {
            if (TempData != null)
            {
                ViewData["ErrorMessage"] = TempData["ErrorMessage"];
                ViewData["SuccessMessage"] = TempData["SuccessMessage"];
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfile(ProfileDTO profileDTO)
        {
            int accountId = (int)HttpContext.Session.GetInt32("USERID");
            User user = await ApiHandler.DeserializeApiResponse<User>(UserApiUrl + "/EmailExisted?email=" + profileDTO.Email, HttpMethod.Get);
            if (user != null)
            {
                TempData["ErrorMessage"] = "Email is existed";
                return RedirectToAction("CreateProfile");

            }
            profileDTO.AccountId = accountId;
            await ApiHandler.DeserializeApiResponse(UserApiUrl, HttpMethod.Post, profileDTO);
            return RedirectToAction("Profile");
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(ProfileDTO profileDTO)
        {
            int accountId = (int)HttpContext.Session.GetInt32("USERID");
            User user = await ApiHandler.DeserializeApiResponse<User>(UserApiUrl + "/EmailExisted?email=" + profileDTO.Email, HttpMethod.Get);
            if (user != null)
            {
                TempData["ErrorMessage"] = "Email is existed";
                return RedirectToAction("EditProfile");

            }
            profileDTO.AccountId = accountId;
            await ApiHandler.DeserializeApiResponse(UserApiUrl, HttpMethod.Put, profileDTO);
            TempData["ErrorMessage"] = "Edit Successfully!";
            return RedirectToAction("Profile");
        }
    }
}
