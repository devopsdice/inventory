using InventoryService.HostedService;
using InventoryService.Repository;
using InventoryService.Repository.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<IMessageBrokerService, RabbitMQService>();
builder.Services.AddSingleton<IDapperContext, DapperContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
//builder.Services.AddResponseCompression
//builder.Services.AddHostedService<BackgroundService1>();



/*builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MyConsumer>();
    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        //cfg.UseHealthCheck(provider);
        cfg.Host(new Uri("amqp://guest:guest@localhost:5672/"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ReceiveEndpoint("Inventorary_Queue", ep =>
        {
            //ep.PrefetchCount = 16;
            //ep.UseMessageRetry(r => r.Interval(2, 100));
            ep.ConfigureConsumer<MyConsumer>(provider);
        });
    }));
});
*/






//builder.Services.AddMassTransitHostedService();
builder.Services.AddHostedService<InventoraryProcessor>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
