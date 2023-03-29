using Microsoft.EntityFrameworkCore;

namespace E_Services_Portal.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        // Define your DbSets here
        public DbSet<UserModel> Users { get; set; }

        // Call your stored procedure here
        public void GetDetails(int userId)
        {
            this.Database.ExecuteSqlRaw("CALL GetDetails({0})", userId);
        }
        public async Task<UserModel> GetUserDetails(int userId)
        {
            var user = await Users.FromSqlRaw("CALL GetDetails({0})", userId).FirstOrDefaultAsync();
            return user;
        }

    }
}
