using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
using System;
using backend_project.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_project
{
  public class Program
  {
      public static void Main(string[] args)
      {
            //CreateHostBuilder(args).Build().Run();

            Console.WriteLine("Applying migrations");
            var webHost = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
            using (var context = (ApplicationDbContext)webHost.Services.GetService(typeof(ApplicationDbContext)))
            {
                context.Database.Migrate();
            }
            Console.WriteLine("Done");
        }

      public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseStartup<Startup>();
              });
  }
}
