using System.Text.Json;
using Backend;
using DotNetEnv;
using Microsoft.OpenApi;


Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = false;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Devops8",
        Version = "v1"
    }));

builder.Services.AddSingleton(new MongoContext(Environment.GetEnvironmentVariable("ConnectionString")!, Environment.GetEnvironmentVariable("DatabaseNabe")!));
builder.Services.AddScoped<IMongoRepository, MongoRepository>();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Devops v1");
    c.RoutePrefix = string.Empty; 
});

app.MapControllers();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
app.Urls.Add("http://0.0.0.0:5000");
app.Run();
