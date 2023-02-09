
using AllPlay.Services.Identity.Api;
using AllPlay.Services.Identity.Infrastructure;
using Messier;
using Messier.Base;
using Messier.Consul;
using Messier.Logging.Serilog;
using Messier.Messaging;
using Messier.Messaging.Interfaces;
using Messier.Messaging.RabbitMQ;
using Messier.Metrics.Prometheus;
using Messier.Observability.Jaeger;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder
    .AddMessierLogging()
    .Services
    .AddMessaging()
    .AddMessier(configuration)
    .AddRabbitmq(configuration)
    .AddLogger(configuration)
    .AddTracing(configuration)
    .AddMetrics(configuration)
    .AddConsul(configuration);

builder.Services.AddInfrastructure(configuration);
 


builder.Services
    .AddHttpClient("").AddConsulHandler();





var app = builder.Build();

app.UseMetrics();

app.MapGet("/", (AppOptions appOption) => $"{appOption.Name} - {appOption.Version}").WithTags("API").WithName("Info");

app.MapGet("/test3", async (IHttpClientFactory http) =>
{
    var builder = http.CreateClient("");
    await builder.GetAsync("http://test-service:5119/home");
});


app.MapGet("/test2", () => $"test2");

app.MapGet("/test", (IMessageBroker messageClient) =>
{
    var foo = new TestMessage();
    messageClient.SendAsync(foo, default);
    return "Poszlo";
});

app.Run();