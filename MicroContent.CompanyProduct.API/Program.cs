using GreenPipes;
using MicroContent.CompanyProduct.API.Models;
using MicroContent.CompanyProduct.API.Services;
using Microsoft.Extensions.Configuration;
using MassTransit;
using MassTransit.AspNetCoreIntegration.HealthChecks;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Settings>(options =>
{
    options.ConnectionString = builder.Configuration.GetSection("MongoConnection:ConnectionString").Value;
    options.Database =  builder.Configuration.GetSection("MongoConnection:Database").Value;
});

builder.Services.AddTransient<IProductService, ProductService>();

//builder.Services.AddHostedService<MessageReceiverService>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ProductConsumer>();
    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        cfg.UseHealthCheck(provider);
        cfg.Host(new Uri("rabbitmq://localhost"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ReceiveEndpoint("productQueue", ep =>
        {
            ep.PrefetchCount = 16;
            ep.UseMessageRetry(r => r.Interval(2, 100));
            ep.ConfigureConsumer<ProductConsumer>(provider);
        });
    }));
});
builder.Services.AddMassTransitHostedService();


//builder.Services.AddMassTransit(busConfigurator =>
//{
//    var entryAssembly = Assembly.GetExecutingAssembly();
//    busConfigurator.AddConsumers(entryAssembly);
//    busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
//    {
//        busFactoryConfigurator.Host(new Uri("rabbitmq://localhost"), h =>
//        {
//            h.Username("guest");
//            h.Password("guest");
//        });

//        busFactoryConfigurator.ConfigureEndpoints(context);
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
