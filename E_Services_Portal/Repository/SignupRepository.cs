using E_Services_Portal.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Xml.Linq;

namespace E_Services_Portal.Repository
{
    public class SignupRepository
    {
    
        Messgaes describer = new Messgaes();
        public UserModel InsertData(UserModel userModel)
        {
            List<UserModel> userModels = new List<UserModel>();
           
            try {
                string connectionString = "server=localhost;port=3306;user=root;password=mypassword;database=mydb";
                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand command = new MySqlCommand("InsertDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@username", userModel.username);
                command.Parameters.AddWithValue("@password", userModel.password);
                command.Parameters.AddWithValue("@name", userModel.username);
                command.Parameters.AddWithValue("@Email", userModel.Email);
                command.Parameters.AddWithValue("@PhoneNumber", userModel.PhoneNumber);
                command.Parameters.AddWithValue("@is_admin", userModel.is_admin);
   


                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();


                userModel.StatusCode = "0000";
                userModel.StatusDescription = describer.Describe("0000");
                connection.Close();
                userModels.Add(userModel);
            }
            catch (Exception ex) {
                userModel.StatusCode = "1001";
                userModel.StatusDescription = describer.Describe("1001");
                Logger.Log($"Exception Occured: SignupRepository.InsertData {ex}");
            }
            return userModel;
        }
            /*
            public UserModel InsertData(UserModel userModel)
            {

                UserModel users = new UserModel();
                try
                {

                     using (var conn = new MySqlConnection(connString))
                     {
                         conn.Open();

                         using (var cmd = new MySqlCommand("login", conn))
                         {
                             cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@p_username", username);
                             cmd.Parameters.AddWithValue("@p_password", password);

                             cmd.Parameters.Add("@p_userid", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                             cmd.Parameters.Add("@p_username", MySqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                             cmd.ExecuteNonQuery();

                              users.id = (int)cmd.Parameters["@p_userid"].Value;
                             users.username = (string)cmd.Parameters["@p_username"].Value;

                             return userModels;
                         }
                     }

                    users.id = 1;
                    users.PhoneNumber = "0999";
                    users.username = "Jack";
                    users.password = "jack";
                    users.Email = "abc@gmail.com";
                    users.StatusCode = "0000";
                    users.StatusDescription = describer.Describe("0000");

                }
                catch (Exception ex)
                {
                    users.StatusCode = "1001";
                    users.StatusDescription = describer.Describe("1001");
                    Logger.Log($"Exception Occured: SignupRepository.InsertData {ex}");

                }

                return users;

            }*/
        }
    }
