using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingWithNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build(); // build host donebildigi icin bu ayari cekebildik.


            //GetRequiredService ile DI kullanmadan istedigimiz servisi cagirabiliyoruz. ILogger'i cagirdik.
            var logger = host.Services.GetRequiredService<ILogger<Program>>(); // kategori program olarak ayarlandý. 
            logger.LogInformation("program ayaga kalkmaya basliyor...");

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().ConfigureLogging(logging =>
                    {
                        logging.ClearProviders(); // built-in gelen loglama provider yapilari kaldirildi. built ekranýnda gozukmuyorlar artik.
                        logging.AddDebug(); // debug eklendi. sadece debug esnasinda calisacak.
                    });
                });
    }
}
