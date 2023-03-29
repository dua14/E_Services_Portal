using E_Services_Portal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace E_Services_Portal.Controllers
{
    public class DashBoardController : Controller
    {
        [HttpGet]
        public IActionResult Index(UserModel user)
        {
            return View(user);
        }
        [HttpGet]
        public IActionResult AdminDashBoard()
        {
            var userListJson = TempData["UserList"] as string;

            // Deserialize the JSON string to a List<UserModel> object
            var userList = JsonSerializer.Deserialize<List<UserModel>>(userListJson);

            return View(userList);
        }


    }
}
