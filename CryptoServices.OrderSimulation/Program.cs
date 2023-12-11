using CryptoServices.OrderSimulation.MessageBus.Consumers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(configurator =>
{
    configurator.AddConsumer<ProceedOrderConsumer>();

    configurator.UsingRabbitMq((context, cfg) =>
    {
        var mqSection = builder.Configuration.GetSection("RabbitMQ");
        cfg.Host(new Uri(mqSection["RootUri"]), h =>
        {
            h.Username(mqSection["UserName"]);
            h.Password(mqSection["Password"]);
        });

        cfg.ReceiveEndpoint("CryptoServices.Orders.Infrastructure.MessageBus.Messages:OrderProceedMessage", e =>
        {
            e.ConfigureConsumer<ProceedOrderConsumer>(context);
        });

        cfg.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
    });

});

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
