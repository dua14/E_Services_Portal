using E_Services_Portal.Models;
using E_Services_Portal.Repository;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace E_Services_Portal.Services
{
    public class SignUpService
    {

        Messgaes describer = new Messgaes();
        public UserModel SignUp(UserModel user)
        {
            UserModel ReturnResponse = new UserModel();

            try
            {
                SignupRepository signupRepository = new SignupRepository();
                ReturnResponse= BussinessValidations(user);
                if (!ReturnResponse.StatusCode.Equals("0000")) { 
                return ReturnResponse;
                };
                user.password = Encryption.EncryptPassword(user.password);
                ReturnResponse = signupRepository.InsertData(user);
                Logger.Log("InsertData " + JsonConvert.SerializeObject(ReturnResponse));
            }
            catch (Exception ex)
            {
                ReturnResponse.StatusCode = "1001";
                ReturnResponse.StatusDescription = describer.Describe("1001");
                Logger.Log($"Exception Occured: LoginService.GetAllUsers {ex}");
            }
            return ReturnResponse;
        }

        private UserModel BussinessValidations(UserModel user)
        {

            
            {
                List<string> errors = new List<string>();

                if (string.IsNullOrWhiteSpace(user.username))
                {
                  
                    user.StatusCode = "1004";
                    user.StatusDescription = describer.Describe("1004");
                    return user;
                }

                if (string.IsNullOrWhiteSpace(user.password))
                {
                    
                    user.StatusCode = "1005";
                    user.StatusDescription = describer.Describe("1005");
                    return user;
                }
                if (IsAlphaNumeric(user.password)) {
                    user.StatusCode = "1006";
                    user.StatusDescription = describer.Describe("1006");
                    return user;
                }

          
                else if (!IsValidEmail(user.Email))
                {
                    user.StatusCode = "1007";
                    user.StatusDescription = describer.Describe("1007");
                    return user;
                }

                if (string.IsNullOrEmpty(user.PhoneNumber))
                {
                    errors.Add("Please enter a phone number.");
                    user.StatusCode = "1009";
                    user.StatusDescription = describer.Describe("1009");
                    return user;
                }
                else if (!long.TryParse(user.PhoneNumber, out _))
                {
                    errors.Add("Phone number should be numeric.");
                    user.StatusCode = "1008";
                    user.StatusDescription = describer.Describe("1008");
                    return user;
                }
                user.StatusCode = "0000";


            }

            static bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }

             static bool IsNumeric(string input)
            {
                return int.TryParse(input, out _);
            }
            static bool IsAlphaNumeric(string input) {
                return Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
            }
            return user;
        }
    }
}
