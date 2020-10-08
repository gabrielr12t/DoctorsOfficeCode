using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DoctorsOffice.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            IHostBuilder host = Host.CreateDefaultBuilder(args)
                                    .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

            return host;
        }
    }
}
