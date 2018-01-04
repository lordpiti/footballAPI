using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using System.Threading;
using Football.API.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Services.Concrete;
using Football.Services.Concrete;
using Football.Services.Interface;

namespace footballRebuildAPI
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    var host = new WebHostBuilder()
        //        .UseKestrel()
        //        .UseContentRoot(Directory.GetCurrentDirectory())
        //        .UseIISIntegration()
        //        .UseStartup<Startup>()
        //        .UseApplicationInsights()
        //        .Build();

        //    host.Run();
        //}
        public static void Main(string[] args)
        {
            var serviceProvider = ServiceConfiguration.ConfigureConsoleServices();
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            //new Thread(() =>
            //{
            //    bool running = true;

            //    //Get DI services
            //    while (running)
            //    {
            //        try
            //        {
            //            //logger.LogInformation("Task badger services starting");
            //            Start();
            //        }
            //        catch (Exception e)
            //        {
            //            //logger.LogError("Error running task badger startup");
            //            //logger.LogInformation(e.Message);
            //            Thread.Sleep(10000);
            //        }
            //    }

            //}).Start();

            BuildWebHost(args).Run();
        }

        public static void Start()
        {
            var serviceProvider = ServiceConfiguration.ConsoleProvider;
            System.Reflection.Assembly asm = System.Reflection.Assembly.Load(new System.Reflection.AssemblyName() { Name = "Football.Services" });


            var playerService = serviceProvider.GetService<IUserService>();
            var playerService2 = serviceProvider.GetService(asm.GetType($"Services.Concrete.UserService"));

        }

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
    }
}
