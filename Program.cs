using Serilog;

var builder = WebApplication.CreateBuilder(args);
var envDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var isDevelopment = envDevelopment == "Development";
if (isDevelopment)
{
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();
    builder.Host.UseSerilog();

    Log.Information("aplikasi development");
}
else
{
    Log.Logger = new LoggerConfiguration()
        .WriteTo.File("./Logs/log-.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();
    builder.Host.UseSerilog();
}


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
