namespace E_Services_Portal
{
    using System.Security.Cryptography;
    using System.Text;
    public class Encryption
    {
public static string EncryptPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // Convert the plain text password to a byte array
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Convert the byte array to a string and return it
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

}
}
