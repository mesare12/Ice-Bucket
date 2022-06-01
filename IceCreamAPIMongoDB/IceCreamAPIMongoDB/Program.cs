using IceCreamAPIMongoDB.Data;
using IceCreamAPIMongoDB.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<IceCreamDatabaseSettings>(builder.Configuration.GetSection("IceCreamDatabaseSettings"));
builder.Services.AddSingleton<IceCreamServices>();
var app = builder.Build();

app.MapGet("/", () => "IceCream API!");

app.MapGet("/api/icecream", async (IceCreamServices services) => await services.GetAsync());

app.MapGet("/api/icecream/{id}", async (IceCreamServices service, string id) =>
{
    var icecream = await service.GetAsync(id);
    return icecream is null ? Results.NotFound() : Results.Ok(icecream);
});

app.MapPost("/api/icecream", async (IceCreamServices service, IceCream icecream) =>
{
    await service.CreateAsync(icecream);
    return Results.Ok();
}); //Fungerar inte efter implanatation av controller; kopplat?

app.Run();
