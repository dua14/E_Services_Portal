using E_Services_Portal.Models;
using E_Services_Portal.Repository;
using Newtonsoft.Json;

namespace E_Services_Portal.Services
{
    public class LoginService
    {
        Messgaes describer = new Messgaes();
        public List<UserModel> Login(UserModel user) {
            UserModel ReturnResponse = new UserModel();
            List<UserModel> userModel = new List<UserModel>();
            try
            {
                LoginRepository loginRepository = new LoginRepository();
                List<UserModel> userModels = loginRepository.GetAllUsers();
             
                foreach (UserModel u in userModels)
                {
                    if (u.username == user.username && VerifyPassword(user.password,u.password)
                        )
                    {

                        ReturnResponse.StatusCode = "0000";
                        ReturnResponse.StatusDescription = describer.Describe("0000");
                        ReturnResponse.id = u.id;
                        ReturnResponse.password = u.password;
                        ReturnResponse.username = u.username;
                        ReturnResponse.Email = u.Email;
                        ReturnResponse.PhoneNumber = u.PhoneNumber;
                        ReturnResponse.is_admin = u.is_admin;
                        Logger.Log("GetAllUsers " + JsonConvert.SerializeObject(ReturnResponse));
                        if (ReturnResponse.is_admin)
                        {
                            return userModels;
                        }
                        else {
                            userModel.Add(ReturnResponse);
                            return userModel;
                        }
             

                    }
                }
               
                    ReturnResponse.StatusCode = "1003";
                    ReturnResponse.StatusDescription = describer.Describe("1003");
                
            }
            catch (Exception ex) {
                ReturnResponse.StatusCode = "1001";
                ReturnResponse.StatusDescription = describer.Describe("1001");
                Logger.Log($"Exception Occured: LoginService.GetAllUsers {ex}");
            }
            userModel.Add(ReturnResponse);
            return userModel;
        }
        public static bool VerifyPassword(string inputPassword, string storedPassword)
        {
            string hashedInputPassword = Encryption.EncryptPassword(inputPassword);
            return hashedInputPassword.Equals(storedPassword);
        }
    }
}
