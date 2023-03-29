namespace E_Services_Portal.Models
{
    public class UserModel
    {
        public string StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Boolean is_admin { get; set; }

   }
}
