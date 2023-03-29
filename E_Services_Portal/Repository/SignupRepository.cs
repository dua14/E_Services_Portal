using E_Services_Portal.Models;

namespace E_Services_Portal.Repository
{
    public class SignupRepository
    {
        string connString;
        Messgaes describer = new Messgaes();
        public SignupRepository()
        {
            connString = "";
        }
        public UserModel InsertData(UserModel userModel)
        {
           
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
                 }*/
             
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

        }
    }
}
