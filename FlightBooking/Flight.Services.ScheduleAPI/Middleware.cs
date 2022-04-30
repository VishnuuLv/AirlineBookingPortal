using Flight.Services.ScheduleAPI.Models.Dto;
using Flight.Services.ScheduleAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Services.ScheduleAPI
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly IScheduleRepository _scheduleRepository;

        public Middleware(RequestDelegate next,IScheduleRepository scheduleRepository)
        {
            _next = next;
            _scheduleRepository = scheduleRepository;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            var connection = factory.CreateConnection();
            //var factory = new ConnectionFactory
            //{
            //    Uri = new Uri("amqp://guest:guest@localhost:5672")
            //};
            //using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "checkoutqueue", false, false, false, arguments: null);
            //stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                AirlineViewDto airlineDto = JsonConvert.DeserializeObject<AirlineViewDto>(content);
                //HandleMessage(airlineDto).GetAwaiter().GetResult();
                AirlineViewDto airlineHeader = new()
                {
                    FlightId = airlineDto.FlightId,
                    FlightName = airlineDto.FlightName,
                    ContactNumber = airlineDto.ContactNumber,
                    ContactAddress = airlineDto.ContactAddress,
                    LogoURL = airlineDto.LogoURL,
                    CreatedDate = airlineDto.CreatedDate,
                    UpdatedDate = airlineDto.UpdatedDate,
                    IsActive = airlineDto.IsActive
                };


                // Airline airdto = _mapper.Map<AirlineViewDto, Airline>(airlineHeader);
                _scheduleRepository.AddOrder(airlineHeader);
                //_db.Flight.Add(airdto);
                //_db.SaveChangesAsync();

                channel.BasicAck(ea.DeliveryTag, false);
            };
            channel.BasicConsume("checkoutqueue", false, consumer);
            //_scheduleRepository.AddOrder();
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            
            return builder.UseMiddleware<Middleware>();
        }
    }
}
