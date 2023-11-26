using BE_Kahoot.Models;
using BE_Kahoot.Utils;
using BusinessObjects.Models;
using DataTransfer;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BE_Kahoot.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient client = null;
        private string AccountApiUrl = "";
        private string UserApiUrl = "";

        public HomeController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            AccountApiUrl = "http://localhost:5014/api/Account";
            UserApiUrl = "http://localhost:5014/api/User";
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (TempData != null)
            {
                ViewData["SuccessMessage"] = TempData["SuccessMessage"];
                ViewData["ErrorMessage"] = TempData["ErrorMessage"];
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDTO loginDTO)
        {
            Account account = await ApiHandler.DeserializeApiResponse<Account>(AccountApiUrl + "/username=" + loginDTO.Username, HttpMethod.Get);

            if (account != null)
            {
                HttpContext.Session.SetInt32("USERID", account.AccountId);
                HttpContext.Session.SetString("USERNAME", account.Username);
                return RedirectToAction("Profile", "User");
            }
            else
            {
                ViewData["ErrorMessage"] = "Username or Password is invalid.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            //string username = HttpContext.Session.GetString("USERNAME");
            //if(username != null)
            //    return RedirectToAction("Profile", "User");

            //TempData nhan du lieu tu controller nay sang controller khac
            if (TempData != null)
            {
                ViewData["SuccessMessage"] = TempData["SuccessMessage"];
                ViewData["ErrorMessage"] = TempData["ErrorMessage"];
            }

            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterDTO registerDTO)
        //{
        //    User user = await ApiHandler.DeserializeApiResponse<User>(UserApiUrl + "/Email/" + customerRequest.Email, HttpMethod.Get);
        //    if (customerRequest.Email.Equals("admin@flowerbouquetsystem.com") || (customer != null && customer.CustomerID != 0))
        //    {
        //        ViewData["ErrorMessage"] = "Email already exists.";
        //        return View("Register");
        //    }

        //    await ApiHandler.DeserializeApiResponse(CustomerApiUrl, HttpMethod.Post, customerRequest);

        //    ViewData["SuccessMessage"] = "Register new account successfully.";
        //    return View("Index");
        //}

        //[HttpGet]
        //public IActionResult Logout()
        //{
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("Index");
        //}
    }
}