using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DoctorsOffice.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            IHostBuilder host = Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(ConfigureWebBuilder);
            return host;
        }

        private static void ConfigureWebBuilder(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseStartup<Startup>();
            webHostBuilder.UseUrls("https://localhost:5342");
        }
    }
}
