using Flight.Services.ScheduleAPI.DbContexts;
using Flight.Services.ScheduleAPI.Messaging;
using Flight.Services.ScheduleAPI.Models;
using Flight.Services.ScheduleAPI.Models.Dto;
using Flight.Services.ScheduleAPI.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Flight.Services.ScheduleAPI
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();   
            
            
        }
        


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
