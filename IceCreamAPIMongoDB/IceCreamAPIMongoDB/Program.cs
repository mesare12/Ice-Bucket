using IceCreamAPIMongoDB.Data;
using IceCreamAPIMongoDB.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<IceCreamDatabaseSettings>(builder.Configuration.GetSection("IceCreamDatabaseSettings"));
builder.Services.AddSingleton<VendorServices>();
var app = builder.Build();

app.MapGet("/", () => "IceCream API!");

app.MapGet("/api/icecream", async (VendorServices services) => await services.GetAsync());

app.MapGet("/api/icecream/{id}", async (VendorServices service, string id) =>
{
    var icecream = await service.GetAsync(id);
    return icecream is null ? Results.NotFound() : Results.Ok(icecream);
});

app.MapPost("/api/icecream", async (VendorServices service, Vendor vendor) =>
{
    await service.CreateAsync(vendor);
    return Results.Ok();
}); //Fungerar inte efter implanatation av controller; kopplat?

app.Run();
