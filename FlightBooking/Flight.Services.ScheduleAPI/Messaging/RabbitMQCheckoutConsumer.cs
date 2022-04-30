using Flight.Services.ScheduleAPI.Models.Dto;
using Flight.Services.ScheduleAPI.RabbitMQSender;
using Flight.Services.ScheduleAPI.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flight.Services.ScheduleAPI.Messaging
{
    public class RabbitMQCheckoutConsumer : BackgroundService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ScheduleRepository _schedule;
        private IConnection _connection;
        private IModel _channel;
        //private readonly IRabbitMQOrderMessageSender _rabbitMQOrderMessageSender;

        public RabbitMQCheckoutConsumer(IScheduleRepository scheduleRepository, IServiceProvider serviceProvider,ScheduleRepository schedule)
        {
            _scheduleRepository = scheduleRepository;
            _schedule = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ScheduleRepository>();
            //_scheduleRepository = factory.CreateScope().ServiceProvider.GetRequiredService<IScheduleRepository>();
        

        //_rabbitMQOrderMessageSender = rabbitMQOrderMessageSender;
        var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "checkoutqueue", false, false, false, arguments: null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                AirlineViewDto airlineDto = JsonConvert.DeserializeObject<AirlineViewDto>(content);
                HandleMessage(airlineDto).GetAwaiter().GetResult();

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume("checkoutqueue", false, consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(AirlineViewDto airlineDto )
        {
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
               

            await _scheduleRepository.AddOrder(airlineHeader);


            

            try
            {
                //await _messageBus.PublishMessage(paymentRequestMessage, orderPaymentProcessTopic);
                //await args.CompleteMessageAsync(args.Message);
               // _rabbitMQOrderMessageSender.SendMessage(paymentRequestMessage, "orderpaymentprocesstopic");
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
