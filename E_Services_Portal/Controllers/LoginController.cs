using E_Services_Portal.Models;
using E_Services_Portal.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;
namespace E_Services_Portal.Controllers
{
    public class LoginController : Controller
    {
        Messgaes describer = new Messgaes();
         public IActionResult Index()
         {
             return View();
         }
 
        [HttpGet]
        public IActionResult UserLogin()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult UserLogin(UserModel user)
        {
            List<UserModel> ReturnResponse =new List<UserModel>();
            try
            {
                LoginService loginService = new LoginService();
                    ReturnResponse = loginService.Login(user);
                if (ReturnResponse.Count > 1 || ReturnResponse.ElementAt(0).is_admin)
                { //admin
                    var userListJson = JsonSerializer.Serialize(ReturnResponse);

                    // Store the JSON string in TempData
                    TempData["UserList"] = userListJson;
                    return RedirectToAction("AdminDashBoard", "DashBoard");
                }
                else
                {
                    if (ReturnResponse.ElementAt(0).StatusCode.Equals("0000"))
                    {
                        return RedirectToAction("Index", "DashBoard", ReturnResponse.ElementAt(0));
                    }
                    else
                    {
                        ViewData["Error"] = ReturnResponse.ElementAt(0).StatusDescription;

                    }
                }

            }
            catch (Exception ex)
            {
                ReturnResponse.ElementAt(0).StatusCode = "1001";
                ReturnResponse.ElementAt(0).StatusDescription = describer.Describe("1001");
                Logger.Log($"Exception LoginController.UserLoginAsync: {ex}");
                ViewData["Error"] = ReturnResponse.ElementAt(0).StatusDescription;
          
            }
            finally { 
            Logger.Close();
            }
            return View(ReturnResponse.ElementAt(0));
        }
   
    }
}
