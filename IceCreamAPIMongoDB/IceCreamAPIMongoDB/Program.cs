using IceCreamAPIMongoDB.Data;
using IceCreamAPIMongoDB.Models;

var builder = WebApplication.CreateBuilder(args);
/// Vendor Db
builder.Services.Configure<VendorDbSettings>(builder.Configuration.GetSection("VendorDbSettings"));
builder.Services.AddSingleton<VendorServices>();
// Order Db
builder.Services.Configure<OrderDbSettings>(builder.Configuration.GetSection("OrderDbSettings"));
builder.Services.AddSingleton<OrderServices>();
//Accessory db
builder.Services.Configure<AccessoryDbSettings>(builder.Configuration.GetSection("AccessoryDbSettings"));
builder.Services.AddSingleton<AccessoryServices>();
//Scoop Db
builder.Services.Configure<ScoopDbSettings>(builder.Configuration.GetSection("ScoopDbSettings"));
builder.Services.AddSingleton<ScoopServices>();
//Cup Db
builder.Services.Configure<CupDbSettings>(builder.Configuration.GetSection("CupDbSettings"));
builder.Services.AddSingleton<CupServices>();
var app = builder.Build();

app.MapGet("/", () => "IceCream API!");

app.MapGet("/api/vendor", async (VendorServices services) => await services.GetAsync());
app.MapGet("/api/order", async (OrderServices services) => await services.GetAsync());
app.MapGet("/api/accessory", async (AccessoryServices services) => await services.GetAsync());
app.MapGet("/api/scoop", async (ScoopServices services) => await services.GetAsync());
app.MapGet("/api/cup", async (CupServices services) => await services.GetAsync());


app.Run();
