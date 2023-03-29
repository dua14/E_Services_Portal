using E_Services_Portal.Models;
using E_Services_Portal.Repository;
using E_Services_Portal.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace E_Services_Portal.Controllers
{
    public class SignupController : Controller
    {
        Messgaes describer = new Messgaes();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Signup() { 
        return View();
        }
        [HttpPost]
        public IActionResult Signup(UserModel user)
        {
            UserModel ReturnResponse = new UserModel();
            try
            {
               
                SignUpService signUpService = new SignUpService();
                ReturnResponse = signUpService.SignUp(user);
                if (ReturnResponse != null && ReturnResponse.StatusCode.Equals("0000"))
                {
                    if (ReturnResponse.is_admin) {
                        LoginRepository loginRepository=new LoginRepository();
                        List<UserModel> userModels = loginRepository.GetAllUsers();
                        var userListJson = JsonSerializer.Serialize(userModels);

                        // Store the JSON string in TempData
                        TempData["UserList"] = userListJson;
                        return RedirectToAction("AdminDashBoard", "DashBoard");
                    }
                    else
                    {
                        return RedirectToAction("Index", "DashBoard", ReturnResponse);
                    }
                }
                else
                {
                    ViewData["Error"] = ReturnResponse.StatusDescription;

                }
            }
            catch (Exception ex)
            {
                ReturnResponse.StatusCode = "1001";
                ReturnResponse.StatusDescription = describer.Describe("1001");
                Logger.Log($"Exception SignUpController.Signup: {ex}");
                ViewData["Error"] = ReturnResponse.StatusDescription;

            }
            finally
            {
                Logger.Close();
            }
            return View();
        }
    }
}
