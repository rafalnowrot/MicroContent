using System.Text;
using MassTransit;
using MicroContent.CompanyProduct.API.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;

namespace MicroContent.CompanyProduct.API.Services;

public class ProductConsumer : IConsumer<Product>
{
    private readonly IProductService _productService;

    public ProductConsumer(IProductService productService )
    {
        _productService = productService;

    }

    public async Task Consume(ConsumeContext<Product> context)
    {
        Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        var data = context.Message;
        if (data != null)
        {
            await _productService.Save(data);
        }
        context.Respond(data);
    }
}


//public class MessageReceiverService : BackgroundService
//{
//    private readonly ConnectionFactory _factory;
//    private readonly IServiceProvider _serviceProvider;
//    private readonly IProductService _productService;

//    public MessageReceiverService(IServiceProvider serviceProvider,IProductService productService )
//    {
//        _productService = productService;
//        _serviceProvider = serviceProvider;
//        _factory = new ConnectionFactory();
//        _factory.Uri = new Uri("rabbitmq://localhost");
//    }

//    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//    {
//        using (var connection = _factory.CreateConnection())
//        using (var channel = connection.CreateModel())
//        {
//            channel.QueueDeclare(queue: "productQueue",
//                durable: false,
//                exclusive: false,
//                autoDelete: false,
//                arguments: null);

//            var consumer = new EventingBasicConsumer(channel);

//            consumer.Received += async (model, ea) =>
//            {
//                var body = ea.Body.ToArray();
//                var receivedMessage = Encoding.UTF8.GetString(body);
                
//                if (receivedMessage != null)
//                {
//                    var data = JsonConvert.DeserializeObject<Product>(receivedMessage);

//                    await _productService.Save(data);
//                }
                
//            };

//            channel.BasicConsume(queue: "wiadomosci",
//                autoAck: true,
//                consumer: consumer);

//            await Task.CompletedTask;
//        }
//    }
//}