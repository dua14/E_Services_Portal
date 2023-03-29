using E_Services_Portal.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace E_Services_Portal.Repository
{
    public class LoginRepository
    {
        string connString;
        Messgaes describer = new Messgaes();
        public LoginRepository() {
            connString = "";
        }
        public List<UserModel> GetAllUsers()
        {
            List<UserModel> userModels = new List<UserModel>();
            

            try
            {
                string connectionString = "server=localhost;port=3306;user=root;password=mypassword;database=mydb";
                MySqlConnection connection = new MySqlConnection(connectionString);

                MySqlCommand command = new MySqlCommand("GetDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UserModel user = new UserModel();
                    user.id = Convert.ToInt32(reader["id"]);
                    user.username = reader["username"].ToString();
                    user.password = reader["password"].ToString();
                    user.Email = reader["email"].ToString();
                    user.PhoneNumber = reader["PhoneNumber"].ToString();
                    user.is_admin = Convert.ToBoolean(reader["is_admin"]);
                    userModels.Add(user);
                }

                connection.Close();
            
            }
            catch (Exception ex)
            {
                UserModel user = new UserModel();
                user.StatusCode = "1001";
                user.StatusDescription = describer.Describe("1001");
                Logger.Log($"Exception Occured: LoginRepository.GetAllUsers {ex}");
                userModels.Add(user);
            }

            return userModels;
        }

        /* public List<UserModel> GetAllUsers() {
             List<UserModel> userModels = new List<UserModel>();
             UserModel users = new UserModel();
             try
             {

                 /* using (var conn = new MySqlConnection(connString))
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
        UserModel user = new UserModel();
                user.id = 1;
                user.PhoneNumber = "0999";
                user.username = "Jack";
                user.password = "jack";
                user.Email = "abc@gmail.com";
                user.StatusCode = "0000";
                user.StatusDescription = describer.Describe("0000");
                user.is_admin = true;
                userModels.Add(user);
            }
            catch (Exception ex)
            {
                users.StatusCode = "1001";
                users.StatusDescription = describer.Describe("1001");
                Logger.Log($"Exception Occured: LoginRepository.GetAllUsers {ex}");
                userModels.Add(users);
            }
      
            return userModels;

        }
*/
    }
}
