using Microsoft.EntityFrameworkCore;
using quiz_api.Entities;
using quiz_api.Services;
using quiz_api.Services.ActionFilters;

using NLog;
using NLog.Web;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Host.UseNLog();



builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Add Service DatabaseContext
builder.Services.AddDbContext<DatabaseContext>();

// Add log
builder.Services.AddHttpLogging(o => { });
builder.Services.AddLogging();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<QuizService>();
builder.Services.AddScoped<GroupService>();

	
builder.Services.AddScoped<LogTransactionAttribute>();

var app = builder.Build();

// Migrate database 
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseHttpLogging();

app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    app.UseSwagger(o => o.SerializeAsV2 = true);
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();