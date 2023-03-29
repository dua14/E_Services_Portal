
namespace E_Services_Portal
{
    using Microsoft.Extensions.Configuration;

    public class AppConfig
    {
        private readonly IConfiguration _config;

        public AppConfig(IConfiguration config)
        {
            _config = config;
        }

        public string GetConnectionString(string name)
        {
            return _config.GetConnectionString(name);
        }
    }

}
